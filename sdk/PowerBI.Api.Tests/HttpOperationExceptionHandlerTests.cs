using System;
using Microsoft.PowerBI.Api.V2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api.Extensions.V2;
using Microsoft.Rest;

namespace PowerBI.Api.Tests
{
    [TestClass]
    public class HttpOperationExceptionHandlerTests
    {
        private const string AccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        [TestMethod]
        public async Task NoPowerBIHttpOperationExceptionHandler()
        {
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                try
                {

                    await client.Imports.PostImportWithFileAsync(stream, "name");
                }
                catch (Exception exception)
                {
                    Assert.AreEqual("Operation returned an invalid status code 'Forbidden'", exception.Message);
                }
            }
        }

        [TestMethod]
        public async Task PowerBIHttpOperationExceptionHandler()
        {
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler, new HttpOperationExceptionHandler()))
            using (var stream = new MemoryStream())
            {
                try
                {

                    await client.Imports.PostImportWithFileAsync(stream, "name");
                }
                catch (Exception exception)
                {
                    Assert.AreEqual("Power BI operation returned an error code 'ADGraphGroupOperationFailedResourceNotFound'", exception.Message);
                }
            }
        }

        // {"error":{"code":"InvalidRequest","message":"datasetId is null or empty"}}
        // {"error":{"code":"GeneralException","message":"Failed to process dataset PostDataset","target":"PostDataset","details":[{"message":"SQL operation failed: The Database operation reached a timeout of '00:01:30'"}]}}
        // {"error":{"code":"DM_GWPipeline_UnknownError","pbi.error":{"code":"DM_GWPipeline_UnknownError","parameters":{},"details":[]}}}
        // {"error":{"code":"FeatureNotAvailableError","pbi.error":{"code":"FeatureNotAvailableError","parameters":{},"details":[]}}}
        // {"error":{"code":"UnknownError","pbi.error":{"code":"UnknownError","parameters":{},"details":[],"exceptionCulprit":1}}}
        // {"error":{"code":"ResourceLimitsPackageCountExceeded","pbi.error":{"code":"ResourceLimitsPackageCountExceeded","parameters":{"CountPermitted":"200"},"details":[]}}}
        // {"error":{"code":"ADGraphGroupOperationFailedResourceNotFound","pbi.error":{"code":"ADGraphGroupOperationFailedResourceNotFound","parameters":{},"details":[],"exceptionCulprit":1}}}
        private static HttpResponseMessage CreateSampleImportResponse()
        {
            return new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                Content = new StringContent(@"{""error"":{""code"":""ADGraphGroupOperationFailedResourceNotFound"",""pbi.error"":{""code"":""ADGraphGroupOperationFailedResourceNotFound"",""parameters"":{},""details"":[],""exceptionCulprit"":1}}}")
            };
        }

        private IPowerBIClient CreatePowerBIClient(HttpClientHandler handler, params DelegatingHandler[] handlers)
        {
            var credentials = new TokenCredentials(AccessKey);
            return new PowerBIClient(credentials, handler, handlers);
        }
    }
}
