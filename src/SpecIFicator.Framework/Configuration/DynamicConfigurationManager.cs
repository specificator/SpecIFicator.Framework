﻿using MDD4All.SpecIF.DataModels;
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
            if (specIFicatorConfiguration != null)
            {
                _specIFicatorConfiguration = specIFicatorConfiguration;
            }
        }

        public static List<ComponentDefinition> GetMainComponents()
        {
            return _specIFicatorConfiguration.Components;
        }

        public static Type GetComponentTypeByID(string id)
        {
            Type result = null;

            string typeName = "";

            foreach(ComponentDefinition component in _specIFicatorConfiguration.Components)
            {
                if(component.ID != null && component.ID == id)
                {
                    typeName = component.DefaultType;
                    break;
                }
            }

            if(!string.IsNullOrEmpty(typeName))
            {
                result = PluginManager.GetType(typeName);
            }

            return result;
        }

        public static Type GetComponentType(string title, string appliesTo, Key classKey)
        {
            Type result = null;

            string typeName = "";

            ComponentDefinition componentDefinition = FindComponentDefinitionRecursively(_specIFicatorConfiguration,
                                                                                         title,
                                                                                         appliesTo);

            if(componentDefinition != null)
            {
                foreach (SpecificTypeConfiguration specificType in componentDefinition.SpecificTypes)
                {
                    if (specificType.Key.ID == classKey.ID)
                    {
                        if (string.IsNullOrEmpty(specificType.Key.Revision))
                        {
                            typeName = specificType.TypeName;
                            break;
                        }
                        else
                        {
                            if(specificType.Key.Revision == classKey.Revision)
                            {
                                typeName = specificType.TypeName;
                                break;
                            }
                        }
                    }
                }
                if (typeName == "")
                {
                    typeName = componentDefinition.DefaultType;
                }
                
            }

            if (!string.IsNullOrEmpty(typeName))
            {
                result = PluginManager.GetType(typeName);
            }

            return result;
        }

        public static DynamicComponentConfiguration GetDynamicComponentConfiguration(string appliesTo)
        {
            return FindDynamicComponentConfigurationRecursively(appliesTo, _specIFicatorConfiguration);
        }

        private static DynamicComponentConfiguration FindDynamicComponentConfigurationRecursively(string appliesTo, 
                                                                                                  DynamicComponentConfiguration currentNode)
        {
            DynamicComponentConfiguration result = null;

            if(currentNode.AppliesTo == appliesTo)
            {
                result = currentNode;
            }
            else
            {
                foreach(ComponentDefinition componentDefinition in currentNode.Components)
                {
                    foreach(DynamicComponentConfiguration childNode in componentDefinition.Configurations)
                    {
                        result = FindDynamicComponentConfigurationRecursively(appliesTo, childNode);
                        if (result != null)
                        {
                            break;
                        }
                    }
                    if (result != null)
                    {
                        break;
                    }
                }
            }


            return result;
        }

        private static ComponentDefinition FindComponentDefinitionRecursively(DynamicComponentConfiguration currentNode,                              
                                                                              string title,
                                                                              string appliesTo)
        {
            ComponentDefinition result = null;

            if(currentNode.AppliesTo == appliesTo)
            {
                foreach (ComponentDefinition componentDefinition in currentNode.Components)
                {
                    if(componentDefinition.Title == title)
                    {
                        result = componentDefinition;
                        break;
                    }
                }
            }
            else
            {
                foreach(ComponentDefinition componentDefinition in currentNode.Components)
                {
                    if (componentDefinition.Configurations != null)
                    {
                        foreach (DynamicComponentConfiguration childConfigration in componentDefinition.Configurations)
                        {
                            result = FindComponentDefinitionRecursively(childConfigration, title, appliesTo);
                            if (result != null)
                            {
                                break;
                            }
                        }
                    }
                    if (result != null)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        //public static Type GetHierarchyEditorType(Key rootResourceClassKey)
        //{
        //    Type result = null;

        //    string typeName = "";

        //    if (_specIFicatorConfiguration != null)
        //    {
        //        ComponentDefinition componentDefinition = _specIFicatorConfiguration.Components.First(cd => cd.Title == "HierarchyEditor");

        //        if (componentDefinition != null)
        //        {
        //            foreach (SpecificTypeConfiguration specificType in componentDefinition.SpecificTypes)
        //            {
        //                if (specificType.Key.ID == rootResourceClassKey.ID &&
        //                    specificType.Key.Revision == rootResourceClassKey.Revision)
        //                {
        //                    typeName = specificType.TypeName;
        //                }
        //            }
        //            if (typeName == "")
        //            {
        //                typeName = componentDefinition.DefaultType;
        //            }
        //        }

        //    }

        //    if (!string.IsNullOrEmpty(typeName))
        //    {
        //        result = PluginManager.GetType(typeName);
        //    }

        //    return result;
        //}
    }
}
