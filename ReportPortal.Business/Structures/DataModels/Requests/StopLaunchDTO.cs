using Newtonsoft.Json;
using ReportPortal.Business.Interfaces;

namespace ReportPortal.Business.Structures.DataModels.Requests
{
    public class StopLaunchDTO : IDataTransferObject
    {
        [JsonProperty("endTime")]
        public string EndTime { get; set; }
    }
}
