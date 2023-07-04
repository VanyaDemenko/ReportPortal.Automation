using Newtonsoft.Json;
using ReportPortal.Business.Interfaces;

namespace ReportPortal.Business.Structures.DataModels.Requests
{
    public class AddLaunchDTO : IDataTransferObject
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("startTime")]
        public string StartTime { get; set; }
    }
}
