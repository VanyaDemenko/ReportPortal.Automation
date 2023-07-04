using Newtonsoft.Json;
using ReportPortal.Business.Interfaces;

namespace ReportPortal.Business.Structures.DataModels.Responses
{
    public class AddLaunchResponseDTO : IDataTransferObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("number")]
        public long Number { get; set; }
    }
}
