using SpecIFicator.Framework.PluginManagement;

namespace SpecIFicator.Framework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PluginManager.LoadPlugins();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
    }
}
