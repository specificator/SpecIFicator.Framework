using Newtonsoft.Json;

namespace SpecIFicator.Framework.PluginManagement.DataModels
{
    /// <summary>
    /// Definition of the data model for SpecIFicatorPlugin.json
    /// </summary>
    public class PluginManifest
    {
        [JsonProperty("title")]
        public string Title { get; set; } = "";

        [JsonProperty("description")]
        public string Description { get; set; } = "";

        [JsonProperty("assemblies")]
        public List<string> Assemblies { get; set; } = new List<string>();
    }
}
