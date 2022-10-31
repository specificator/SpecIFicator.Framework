using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.DataProvider.Contracts.DataStreams;
using MDD4All.SpecIF.DataProvider.MockupDataStream;
using SpecIFicator.Framework.Configuration;
using SpecIFicator.Framework.PluginManagement;
using System.Globalization;

namespace SpecIFicator.Framework
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddLocalization(options =>
            {
                
                options.ResourcesPath = "Resources";
            });

            List<CultureInfo> supportedCultures = new List<CultureInfo>
            {
               new CultureInfo("en"),
               new CultureInfo("de")
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture =
                   new Microsoft.AspNetCore.Localization.RequestCulture("de");
                options.SupportedUICultures = supportedCultures;
            });

            services.AddSingleton<ISpecIfDataProviderFactory>(factory =>
            {
                return new SpecIfDataProviderFactory();
            });

            //services.AddScoped<ISpecIfMetadataReader>(dataProvider =>
            //{
                
            //});

            //services.AddScoped<ISpecIfMetadataWriter>(dataProvider => specIfDataProviderFactory.SpecIfMetadataWriter);

            //services.AddScoped<ISpecIfDataReader>(dataProvider => specIfDataProviderFactory.SpecIfDataReader);

            //services.AddScoped<ISpecIfDataWriter>(dataProvider => specIfDataProviderFactory.SpecIfDataWriter);

            services.AddScoped<ISpecIfDataSubscriber>(dataSubscriber =>
            {
                return new MockupDataSubscriber();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {

            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            app.UseRequestLocalization();

            // SpecIFicator framework initialization
            DynamicConfigurationManager.LoadConfiguration();
            PluginManager.LoadPlugins(@"c:\Users\olli\Documents\work\github\SpecIFicator.Framework\src\plugins\");
        }
    }
}
