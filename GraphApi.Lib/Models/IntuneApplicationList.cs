using System.Collections.Generic;
using Newtonsoft.Json;

namespace GraphApi.Core.Models
{
    public class IntuneApplicationList
    {
        [JsonProperty(PropertyName = "value")]
        public List<IntuneApplication> List { get; set; }
    }
}