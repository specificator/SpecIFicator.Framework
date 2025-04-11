using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.DataModels;
using System.Reflection;

namespace SpecIFicator.Framework.Pages
{
    public partial class AppInfoPage
    {
        [Inject]
        IStringLocalizer<AppInfoPage> L { get; set; }

        private List<AssemblyInformation> CurrentAssemblies
        {
            get
            {
                List<AssemblyInformation> result = new List<AssemblyInformation>();

                foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    try
                    {
                        result.Add(new AssemblyInformation
                        {
                            AssemblyName = assembly.GetName(),
                            Location = assembly.Location
                        });
                    }
                    catch { }
                }

                //result = result.OrderBy(x => x.AssemblyName).ToList();

                return result;
            }
        }


    }
}