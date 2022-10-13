using MDD4All.SpecIF.DataModels;
using Newtonsoft.Json;

namespace SpecIFicator.Framework.Configuration.DataModels
{
    public class DynamicComponentConfiguration
    {
        [JsonProperty("appliesTo")]
        public string AppliesTo { get; set; }


        [JsonProperty("components")]
        public List<ComponentDefinition> Components { get; set; }
    }
}
