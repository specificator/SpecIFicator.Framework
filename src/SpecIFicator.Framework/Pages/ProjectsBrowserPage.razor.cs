using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using SpecIFicator.Framework;
using SpecIFicator.Framework.Shared;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.PluginManagement;

namespace SpecIFicator.Framework.Pages
{
    public partial class ProjectsBrowserPage
    {
        private Type _projectBrowserType { get; set; }

        protected override void OnInitialized()
        {
            Type type = PluginManager.GetType("SpecIFicator.DefaultPlugin.BlazorComponents.ProjectsBrowser");
            _projectBrowserType = type;
        }
    }
}