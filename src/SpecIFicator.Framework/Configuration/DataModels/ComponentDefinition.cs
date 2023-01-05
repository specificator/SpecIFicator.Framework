using Newtonsoft.Json;

namespace SpecIFicator.Framework.Configuration.DataModels
{
    public class ComponentDefinition
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("id")]
        public string? ID { get; set; }

        [JsonProperty("titleKey")]
        public string? TitleKey { get; set; }

        [JsonProperty("icon")]
        public string? Icon { get; set; }

        [JsonProperty("showInMainMenu")]
        public bool? ShowInMainMenu { get; set; } = null;

        [JsonProperty("default")]
        public string DefaultType { get; set; }

        [JsonProperty("specificTypes")]
        public List<SpecificTypeConfiguration> SpecificTypes { get; set; } = new List<SpecificTypeConfiguration>();

        [JsonProperty("configurations")]
        public List<DynamicComponentConfiguration> Configurations { get; set; }
    }
}
