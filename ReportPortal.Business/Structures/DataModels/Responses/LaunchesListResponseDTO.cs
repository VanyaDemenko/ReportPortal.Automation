using Newtonsoft.Json;
using ReportPortal.Business.Interfaces;

namespace ReportPortal.Business.Structures.DataModels.Responses
{
    public class LaunchesListResponseDTO : IDataTransferObject
    {
        [JsonProperty("content")]
        public List<LaunchResponseDTO> Content { get; set; }
        [JsonProperty("page")]
        public Page Page { get; set; }
    }
    
    public class Page
    {
        [JsonProperty("number")]
        public long Number { get; set; }
        [JsonProperty("size")]
        public long Size { get; set; }
        [JsonProperty("totalElements")]
        public long TotalElements { get; set; }
        [JsonProperty("totalPages")]
        public long TotalPages { get; set; }
    }
}
