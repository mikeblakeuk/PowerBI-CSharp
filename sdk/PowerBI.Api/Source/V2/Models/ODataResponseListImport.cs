// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.PowerBI.Api.V2.Models
{
    using Microsoft.PowerBI;
    using Microsoft.PowerBI.Api;
    using Microsoft.PowerBI.Api.V2;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Odata response wrapper for a Power BI Import collection
    /// </summary>
    public partial class ODataResponseListImport
    {
        /// <summary>
        /// Initializes a new instance of the ODataResponseListImport class.
        /// </summary>
        public ODataResponseListImport()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ODataResponseListImport class.
        /// </summary>
        /// <param name="odatacontext">OData context</param>
        /// <param name="value">The imports collection</param>
        public ODataResponseListImport(string odatacontext = default(string), IList<Import> value = default(IList<Import>))
        {
            Odatacontext = odatacontext;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets oData context
        /// </summary>
        [JsonProperty(PropertyName = "odata.context")]
        public string Odatacontext { get; set; }

        /// <summary>
        /// Gets or sets the imports collection
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<Import> Value { get; set; }

    }
}
