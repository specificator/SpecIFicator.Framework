namespace SpecIFicator.Framework.Configuration.DataModels
{
    public abstract class DynamicComponentConfiguration
    {
        public string DefaultType { get; set; }

        public Dictionary<string, string> SpecificTypes { get; set; } = new Dictionary<string, string>();
    }
}
