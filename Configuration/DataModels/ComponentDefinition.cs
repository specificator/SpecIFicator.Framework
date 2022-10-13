using Newtonsoft.Json;

namespace SpecIFicator.Framework.Configuration.DataModels
{
    public class ComponentDefinition
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("default")]
        public string DefaultType { get; set; }

        [JsonProperty("specificTypes")]
        public List<SpecificTypeConfiguration> SpecificTypes { get; set; } = new List<SpecificTypeConfiguration>();

        [JsonProperty("configurations")]
        List<DynamicComponentConfiguration> Configurations { get; set; }
    }
}
