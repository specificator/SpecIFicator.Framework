using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace SpecIFicator.Framework.Pages
{
    public partial class AppInfoPage
    {
        [Inject]
        IStringLocalizer<AppInfoPage> L { get; set; }

        private List<AssemblyName> CurrentAssemblies
        {
            get
            {
                List<AssemblyName> result = new List<AssemblyName>();

                foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    result.Add(assembly.GetName());
                }

                result = result.OrderBy(x => x.Name).ToList();

                return result;
            }
        }


    }
}