// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.PowerBI.Api.V2.Models
{
    using Microsoft.PowerBI;
    using Microsoft.PowerBI.Api;
    using Microsoft.PowerBI.Api.V2;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A Power BI Report
    /// </summary>
    public partial class Report
    {
        /// <summary>
        /// Initializes a new instance of the Report class.
        /// </summary>
        public Report()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Report class.
        /// </summary>
        /// <param name="id">The report id</param>
        /// <param name="name">The report name</param>
        /// <param name="webUrl">The report web url</param>
        /// <param name="embedUrl">The report embed url</param>
        /// <param name="datasetId">The dataset id</param>
        public Report(string id = default(string), string name = default(string), string webUrl = default(string), string embedUrl = default(string), string datasetId = default(string))
        {
            Id = id;
            Name = name;
            WebUrl = webUrl;
            EmbedUrl = embedUrl;
            DatasetId = datasetId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the report id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the report name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the report web url
        /// </summary>
        [JsonProperty(PropertyName = "webUrl")]
        public string WebUrl { get; set; }

        /// <summary>
        /// Gets or sets the report embed url
        /// </summary>
        [JsonProperty(PropertyName = "embedUrl")]
        public string EmbedUrl { get; set; }

        /// <summary>
        /// Gets or sets the dataset id
        /// </summary>
        [JsonProperty(PropertyName = "datasetId")]
        public string DatasetId { get; set; }

    }
}
