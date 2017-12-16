using Newtonsoft.Json;

namespace GraphApi.Core.Models
{
    public class ContentFile
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }

        [JsonProperty(PropertyName = "sizeEncrypted")]
        public int SizeEncrypted { get; set; }

        [JsonProperty(PropertyName = "manifest")]
        public string Manifest { get; set; }

        [JsonProperty(PropertyName = "@odata.type")]
        public string DataType { get; set; }
    }
}