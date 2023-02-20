using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;

namespace SpecIFicator.Framework.PluginManagement
{
    public class PluginLoadContext : AssemblyLoadContext
    {
        private AssemblyDependencyResolver _resolver;
        private AssemblyDependencyResolver _hostResolver;

        public PluginLoadContext(string pluginPath, string hostPath)
        {
            _resolver = new AssemblyDependencyResolver(pluginPath);
            _hostResolver= new AssemblyDependencyResolver(hostPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            Assembly result = null;

            string assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);

            if (assemblyPath != null)
            {
                result = LoadFromAssemblyPath(assemblyPath);
            }
            else
            {
                Debug.WriteLine(assemblyName.FullName);
            }
            
            return result;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            string libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);

            if(libraryPath == null) 
            {
                libraryPath = _hostResolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            }

            if (libraryPath != null)
            {
                return LoadUnmanagedDllFromPath(libraryPath);
            }
            else
            {
                Debug.WriteLine(unmanagedDllName);
            }


            return IntPtr.Zero;
        }
    }
}
