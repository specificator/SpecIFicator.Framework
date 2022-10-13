using Newtonsoft.Json;

namespace SpecIFicator.Framework.Configuration.DataModels
{
    public class SpecIFicatorConfiguration
    {

        [JsonProperty("components")]
        public List<ComponentDefinition> Components { get; set; } = new List<ComponentDefinition>();
    }
}
