using SpecIFicator.Framework.Contracts;
using System.Reflection;

namespace SpecIFicator.Framework.PluginManagement
{
    public class PluginLoader
    {
        public static Assembly LoadPlugin(string path)
        {
            Console.WriteLine($"Loading commands from: {path}");
            PluginLoadContext loadContext = new PluginLoadContext(path);
            return loadContext.LoadFromAssemblyName(AssemblyName.GetAssemblyName(path));
        }

        public static IEnumerable<Type> CreateTypes(Assembly assembly)
        {
            int count = 0;

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IMainPage).IsAssignableFrom(type))
                {
                    count++;
                    yield return type;
                    //IMainPage result = Activator.CreateInstance(type) as IMainPage;
                    //if (result != null)
                    //{
                    //    count++;
                    //    yield return result;
                    //}
                }
            }

            if (count == 0)
            {
                string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
                throw new ApplicationException(
                    $"Can't find any type which implements IMainPage in {assembly} from {assembly.Location}.\n" +
                    $"Available types: {availableTypes}");
            }
        }

    }
}
