using Newtonsoft.Json;
using ReportPortal.Business.Interfaces;

namespace ReportPortal.Business.Structures.DataModels.Responses
{
    public class LaunchResponseDTO : IDataTransferObject
    {
        [JsonProperty("owner")]
        public string Owner { get; set; }
        [JsonProperty("share")]
        public bool Share { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("number")]
        public long Number { get; set; }
        [JsonProperty("startTime")]
        public long StartTime { get; set; }
        [JsonProperty("endTime")]
        public long EndTime { get; set; }
        [JsonProperty("lastModified")]
        public long LastModified { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("statistics")]
        public Statistics Statistics { get; set; }
        [JsonProperty("attributes")]
        public List<Attribute> Attributes { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("analysing")]
        public List<object> Analysing { get; set; }
        [JsonProperty("approximateDuration")]
        public double ApproximateDuration { get; set; }
        [JsonProperty("hasRetries")]
        public bool HasRetries { get; set; }
        [JsonProperty("rerun")]
        public bool Rerun { get; set; }
    }

    public class Statistics
    {
        [JsonProperty("executions")]
        public Executions Executions { get; set; }
        [JsonProperty("defects")]
        public Defects Defects { get; set; }
    }

    public class Executions
    {
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("failed")]
        public long? Failed { get; set; }
        [JsonProperty("passed")]
        public long Passed { get; set; }
        [JsonProperty("skipped")]
        public long? Skipped { get; set; }
    }

    public class Defects
    {
        [JsonProperty("system_issue")]
        public SystemIssue SystemIssue { get; set; }
        [JsonProperty("to_investigate")]
        public ToInvestigate ToInvestigate { get; set; }
        [JsonProperty("automation_bug")]
        public AutomationBug AutomationBug { get; set; }
        [JsonProperty("product_bug")]
        public ProductBug ProductBug { get; set; }
    }

    public class AutomationBug
    {
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("ab001")]
        public long Ab001 { get; set; }
    }

    public class ProductBug
    {
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("pb001")]
        public long Pb001 { get; set; }
    }

    public class SystemIssue
    {
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("si001")]
        public long Si001 { get; set; }
    }

    public class ToInvestigate
    {
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("ti001")]
        public long Ti001 { get; set; }
    }

    public class Attribute
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
