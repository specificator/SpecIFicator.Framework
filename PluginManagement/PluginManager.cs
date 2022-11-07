using Newtonsoft.Json;
using SpecIFicator.Framework.PluginManagement.DataModels;
using System.Diagnostics;
using System.Reflection;

namespace SpecIFicator.Framework.PluginManagement
{
    public class PluginManager
    {

        private static Dictionary<PluginManifest, List<Assembly>> _pluginCache = new Dictionary<PluginManifest, List<Assembly>>();

        public static void LoadPlugins(string basePath = @"d:\work\github\SpecIFicator.Framework\src\plugins\")
        {
            _pluginCache.Clear();

            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(basePath);

            if (baseDirectoryInfo.Exists)
            {

                foreach (DirectoryInfo pluginDirectory in baseDirectoryInfo.GetDirectories())
                {
                    string pluginManifestPath = pluginDirectory.FullName + "/SpecIFicatorPlugin.json";

                    if (File.Exists(pluginManifestPath))
                    {
                        string json = File.ReadAllText(pluginManifestPath);

                        PluginManifest pluginManifest = JsonConvert.DeserializeObject<PluginManifest>(json);

                        if (pluginManifest != null)
                        {
                            List<Assembly> assemblies = new List<Assembly>();

                            foreach (string assemblyName in pluginManifest.Assemblies)
                            {
                                string assemblyPath = Path.Combine(pluginDirectory.FullName, assemblyName);

                                if (File.Exists(assemblyPath))
                                {
                                    try
                                    {
                                        PluginLoadContext pluginLoadContext = new PluginLoadContext(assemblyPath);

                                        Assembly pluginAssembly = pluginLoadContext.LoadFromAssemblyName(AssemblyName.GetAssemblyName(assemblyPath));

                                        assemblies.Add(pluginAssembly);

                                    }
                                    catch (Exception exception)
                                    {
                                        Debug.WriteLine("Unable to load plugin assembly " + assemblyPath);
                                    }
                                }
                            }

                            if (!_pluginCache.ContainsKey(pluginManifest))
                            {
                                _pluginCache.Add(pluginManifest, assemblies);
                            }
                        }
                    }
                }
            }

        }

        public static IEnumerable<Type> GetTypes(Type interfaceType)
        {
            int count = 0;

            foreach (KeyValuePair<PluginManifest, List<Assembly>> plugin in _pluginCache)
            {
                foreach (Assembly assembly in plugin.Value)
                {
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (interfaceType.IsAssignableFrom(type))
                        {

                            count++;
                            yield return type;
                        }
                    }
                }
            }

            //if (count == 0)
            //{
            //    string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
            //    Debug.WriteLine(
            //        $"Can't find any type which implements {interfaceType.Name} in {assembly} from {assembly.Location}.\n" +
            //        $"Available types: {availableTypes}");
            //}
        }

        public static Type GetType(string typeName)
        {
            Type result = null;

            foreach (KeyValuePair<PluginManifest, List<Assembly>> plugin in _pluginCache)
            {
                foreach (Assembly assembly in plugin.Value)
                {
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.FullName == typeName)
                        {

                            result = type;
                        }
                    }
                }
            }

            return result;
        }

        public static List<string> GetStylesheetNames()
        {
            List<string> result = new List<string>();

            foreach (KeyValuePair<PluginManifest, List<Assembly>> plugin in _pluginCache)
            {
                foreach (Assembly assembly in plugin.Value)
                {
                    string stylesheetName = assembly.GetName().Name + ".bundle.scp.css";
                    result.Add(stylesheetName);
                }
            }
            return result;
        }
    }
}
