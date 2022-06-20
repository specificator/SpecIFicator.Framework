using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDD4All.SpecIF.DataProvider.Contracts;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.Framework.Pages
{
    public partial class TestComponent
    {
        [Inject]
        ISpecIfDataProviderFactory dataProviderFactory { get; set; }

        public string Test
        {
            get
            {
                string result = "data type count " + dataProviderFactory.MetadataReader.GetAllDataTypes().Count.ToString();
                return result;
            }
        }
    }
}