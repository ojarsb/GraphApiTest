using Newtonsoft.Json;

namespace GraphApi.Core.Models
{
    public class RunSchedule
    {
        [JsonProperty(PropertyName = "@odata.type")]
        public string Datatype { get; set; }
    }
}