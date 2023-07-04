using Newtonsoft.Json;
using ReportPortal.Business.Interfaces;

namespace ReportPortal.Business.Structures.DataModels.Responses
{
    public class ErrorResponseDTO : IDataTransferObject
    {
        [JsonProperty("errorCode")]
        public long ErrorCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
