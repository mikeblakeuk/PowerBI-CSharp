using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;

namespace Microsoft.PowerBI.Api.Extensions.V2
{
    /// <inheritdoc />
    public class HttpOperationExceptionHandler : DelegatingHandler
    {
        const string XPowerBIErrorDetailsHeaderKey = "X-PowerBI-Error-Details";
        const string XPowerBIErrorInfoHeaderKey = "X-PowerBI-Error-Info";
        const string RequestIdHeaderKey = "RequestId";

        /// <inheritdoc />
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            string responseContent = null;
            if (response.Content != null)
            {
                responseContent = response.Content.ReadAsStringAsync().Result;
            }
            var message = $"Power BI operation returned an invalid status code '{response.StatusCode}'";

            var errorBody = ErrorInHeader(response, XPowerBIErrorDetailsHeaderKey);
            var errorInfo = ErrorInHeader(response, XPowerBIErrorInfoHeaderKey);
            errorBody = errorBody ?? responseContent;

            var errorTypeSafe = ConvertBodyToPowerBIError(errorBody);
            if (!string.IsNullOrEmpty(errorTypeSafe?.Message))
            {
                message = errorTypeSafe.Message;
            }
            else if (!string.IsNullOrEmpty(errorTypeSafe?.Code))
            {
                message = $"Power BI operation returned an error code '{errorTypeSafe.Code}'";
            }

            if (!string.IsNullOrEmpty(errorInfo))
            {
                message += $" ({errorInfo})";
            }

            var ex = new PowerBIOperationException(message)
            {
                Code = errorTypeSafe?.Code ?? errorInfo,
                Body = errorBody,
                Request = new HttpRequestMessageWrapper(request, null),
                Response = new HttpResponseMessageWrapper(response, responseContent)
            };

            if (response.Headers.Contains(RequestIdHeaderKey))
            {
                ex.RequestId = response.Headers.GetValues(RequestIdHeaderKey).FirstOrDefault();
            }

            response.Dispose();
            throw ex;
        }

        static string ErrorInHeader(HttpResponseMessage response, string key)
        {
            if (response.Headers == null)
            {
                return null;
            }

            IEnumerable<string> errorHeaderValues;
            if (response.Headers.TryGetValues(key, out errorHeaderValues))
            {
                var xHeaderErrorDetails = errorHeaderValues?.FirstOrDefault();
                if (xHeaderErrorDetails != null)
                {
                    return xHeaderErrorDetails;
                }
            }
            return null;
        }

        static PowerBIError ConvertBodyToPowerBIError(string body)
        {
            try
            {
                if (!string.IsNullOrEmpty(body))
                {
                    var json = SafeJsonConvert.DeserializeObject<PowerBIErrorBody>(body);
                    return json?.Error;
                }
            }
            catch (JsonException)
            {
            }
            return null;
        }

        public class PowerBIOperationException : HttpOperationException
        {
            public PowerBIOperationException(string message)
                : base(message)
            {
            }

            public string RequestId { get; set; }

            public string Code { get; set; }
        }

        public class PowerBIErrorBody
        {
            [JsonProperty(PropertyName = "error")]
            public PowerBIError Error { get; set; }
        }

        public class PowerBIError
        {
            [JsonProperty(PropertyName = "code")]
            public string Code { get; set; }

            [JsonProperty(PropertyName = "details")]
            public IEnumerable<PowerBIExceptionDetails> Details { get; set; }

            [JsonProperty(PropertyName = "message")]
            public string Message { get; set; }

            [JsonProperty(PropertyName = "target")]
            public string Target { get; set; }
        }

        public class PowerBIExceptionDetails
        {
            [JsonProperty(PropertyName = "message")]
            public string Message { get; set; }
        }
    }
}
