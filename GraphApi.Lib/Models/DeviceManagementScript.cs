using System;
using Newtonsoft.Json;

namespace GraphApi.Core.Models
{
    public class DeviceManagementScript
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "@odata.type")]
        public string Datatype { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "runSchedule")]
        public RunSchedule RunSchedule { get; set; }

        [JsonProperty(PropertyName = "scriptContent")]
        public string ScriptContent { get; set; }

        [JsonProperty(PropertyName = "createdDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedDateTime { get; set; }

        [JsonProperty(PropertyName = "lastModifiedDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastModifiedDateTime { get; set; }

        /// <summary>
        ///     Possible values are: system, user.
        /// </summary>
        [JsonProperty(PropertyName = "runAsAccount")]
        public string RunAsAccount { get; set; }

        [JsonProperty(PropertyName = "enforceSignatureCheck")]
        public bool EnforceSignatureCheck { get; set; }

        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }
    }
}