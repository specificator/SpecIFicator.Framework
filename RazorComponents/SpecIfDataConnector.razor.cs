using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.CascadingValues;
using SpecIFicator.Framework.PluginManagement;
using SpecIFicator.Framework.Contracts;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.Framework.RazorComponents
{
    public partial class SpecIfDataConnector
    {
        [Inject]
        IStringLocalizer<SpecIfDataConnector> L { get; set; }

        [CascadingParameter]
        private SpecIfDataConnectorContext _dataContext { get; set; }

        private List<Type> _connectorTypes = new List<Type>();

        private int _typeIndex { 
            get; 
            set; 
        }

        private Type _activeType 
        { 
            get; 
            set; 
        }

        protected override void OnInitialized()
        {
            _connectorTypes = PluginManager.GetTypes(typeof(ISpecIfDataConnector)).ToList();
            if(_connectorTypes.Count > 0)
            {
                _activeType = _connectorTypes[0];
                _typeIndex = 0;
            }
            
        }

        private void OnTypeSelectionChange(ChangeEventArgs arguments)
        {
            string indexAsString = arguments.Value.ToString();

            int index = int.Parse(indexAsString);

            _activeType = _connectorTypes[index];
        }


    }
}