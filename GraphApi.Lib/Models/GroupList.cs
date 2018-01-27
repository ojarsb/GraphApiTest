using System.Collections.Generic;
using Newtonsoft.Json;

namespace GraphApi.Core.Models
{
    public class GroupList
    {
        [JsonProperty(PropertyName = "value")]
        public List<Group> List { get; set; }
    }
}