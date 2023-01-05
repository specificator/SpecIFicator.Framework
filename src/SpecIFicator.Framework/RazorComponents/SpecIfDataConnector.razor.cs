using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.PluginManagement;
using SpecIFicator.Framework.Contracts;
using Microsoft.Extensions.Localization;
using MDD4All.Configuration.Contracts;
using SpecIFicator.Framework.Configuration;
using MDD4All.Configuration;
using MDD4All.SpecIF.ViewModels;

namespace SpecIFicator.Framework.RazorComponents
{
    public partial class SpecIfDataConnector
    {
        [Inject]
        IStringLocalizer<SpecIfDataConnector> L { get; set; }

        [CascadingParameter]
        private DataConnectorViewModel DataContext { get; set; }

        private List<Type> _connectorTypes = new List<Type>();

        private IConfigurationReaderWriter<DataConnectorConfiguration> _configurationReaderWriter;

        private DataConnectorConfiguration _configuration;

        private string ActiveTypeName
        {
            get
            {
                return ActiveType?.FullName;
            }
            set
            {
                foreach(var type in _connectorTypes)
                {
                    if(type.FullName == value)
                    {
                        ActiveType = type;
                        break;
                    }
                }
            }
        }

        private Type ActiveType 
        { 
            get; 
            set; 
        }

        protected override void OnInitialized()
        {
            _configurationReaderWriter = new FileConfigurationReaderWriter<DataConnectorConfiguration>();

            _configuration = _configurationReaderWriter.GetConfiguration();

            if (_configuration == null)
            {
                _configuration = new DataConnectorConfiguration();
            }

            _connectorTypes = PluginManager.GetTypes(typeof(ISpecIfDataConnector)).ToList();
            if(_connectorTypes.Count > 0)
            {
                int count = 0;

                ActiveTypeName = _connectorTypes[0].FullName;

                foreach (Type connectorType in _connectorTypes)
                {
                    if(connectorType.FullName == _configuration.LastUsedTypeName)
                    {
                        ActiveType = _connectorTypes[count];
                        break;
                    }
                    count++;
                }

                
            }
            
        }

        private void OnTypeSelectionChange(ChangeEventArgs arguments)
        {
            string fullTypeName = arguments.Value.ToString();


            if (_connectorTypes.Any())
            {
                ActiveTypeName = _connectorTypes.Find(type => type.FullName == fullTypeName).FullName;

                _configuration.LastUsedTypeName = ActiveType.FullName;

                _configurationReaderWriter.StoreConfiguration(_configuration);
            }
        }


    }
}