using System;
using Newtonsoft.Json;

namespace GraphApi.Core.Models
{
    public class IntuneApplication
    {
        //[JsonProperty(PropertyName = "@odata.context")]
        //public string DataContext { get; set; }

        [JsonProperty(PropertyName = "@odata.type")]
        public string Datatype { get; set; }

        [JsonProperty(PropertyName = "categories", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] Categories { get; set; }
        
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        [JsonProperty(PropertyName = "largeIcon", NullValueHandling = NullValueHandling.Ignore)]
        public LargeIcon LargeIcon { get; set; }

        [JsonProperty(PropertyName = "createdDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedDateTime { get; set; }

        [JsonProperty(PropertyName = "lastModifiedDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastModifiedDateTime { get; set; }

        [JsonProperty(PropertyName = "isFeatured")]
        public bool IsFeatured { get; set; }

        [JsonProperty(PropertyName = "privacyInformationUrl")]
        public string PrivacyInformationUrl { get; set; }

        [JsonProperty(PropertyName = "informationUrl")]
        public string InformationUrl { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }

        [JsonProperty(PropertyName = "developer")]
        public string Developer { get; set; }

        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

        [JsonProperty(PropertyName = "uploadState", NullValueHandling = NullValueHandling.Ignore)]
        public int? UploadState { get; set; }

        [JsonProperty(PropertyName = "committedContentVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string CommittedContentVersion { get; set; }

        [JsonProperty(PropertyName = "fileName", NullValueHandling = NullValueHandling.Ignore)]
        public string FileName { get; set; }

        [JsonProperty(PropertyName = "size", NullValueHandling = NullValueHandling.Ignore)]
        public int? Size { get; set; }

        [JsonProperty(PropertyName = "identityVersion")]
        public string IdentityVersion { get; set; }

        [JsonProperty(PropertyName = "commandLine")]
        public string CommandLine { get; set; }

        [JsonProperty(PropertyName = "productCode")]
        public string ProductCode { get; set; }

        [JsonProperty(PropertyName = "productVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductVersion { get; set; }
    }
}