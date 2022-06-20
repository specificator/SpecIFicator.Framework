namespace SpecIFicator.Framework.Configuration.DataModels
{
    public class ProjectManagerConfiguration : DynamicComponentConfiguration
    {
        public HierarchyEditorConfiguration HierarchyEditor { get; set; } = new HierarchyEditorConfiguration();
    }
}
