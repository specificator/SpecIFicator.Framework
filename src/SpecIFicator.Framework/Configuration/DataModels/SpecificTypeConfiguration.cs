using MDD4All.SpecIF.DataModels;
using Newtonsoft.Json;

namespace SpecIFicator.Framework.Configuration.DataModels
{
    public class SpecificTypeConfiguration
    {
        [JsonProperty("key")]
        public Key Key { get; set; }

        [JsonProperty("typeName")]
        public string TypeName { get; set; }
    }
}
