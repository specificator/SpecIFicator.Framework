using MDD4All.SpecIF.DataModels;
using Newtonsoft.Json;
using SpecIFicator.Framework.Configuration.DataModels;
using SpecIFicator.Framework.PluginManagement;

namespace SpecIFicator.Framework.Configuration
{
    public class DynamicConfigurationManager
    {

        private static DynamicComponentConfiguration _specIFicatorConfiguration;

        public static void LoadConfiguration()
        {
            string json = System.IO.File.ReadAllText("SpecIFicatorSettings.json");

            DynamicComponentConfiguration specIFicatorConfiguration = JsonConvert.DeserializeObject<DynamicComponentConfiguration>(json);
            if(specIFicatorConfiguration != null)
            {
                _specIFicatorConfiguration = specIFicatorConfiguration;
            }
        }

        public static Type GetHierarchyEditorType(Key rootResourceClassKey)
        {
            Type result = null;

            string typeName = "";

            if (_specIFicatorConfiguration != null)
            {
                ComponentDefinition componentDefinition = _specIFicatorConfiguration.Components.First(cd => cd.Title == "HierarchyEditor");

                if (componentDefinition != null)
                {
                    foreach (SpecificTypeConfiguration specificType in componentDefinition.SpecificTypes)
                    {
                        if (specificType.Key.ID == rootResourceClassKey.ID &&
                            specificType.Key.Revision == rootResourceClassKey.Revision)
                        {
                            typeName = specificType.TypeName;
                        }
                    }
                    if (typeName == "")
                    {
                        typeName = componentDefinition.DefaultType;
                    }
                }
                
            }

            if (!string.IsNullOrEmpty(typeName))
            {
                result = PluginManager.GetType(typeName);
            }

            return result;
        }
    }
}
