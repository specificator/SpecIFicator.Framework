using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.Contracts;
using SpecIFicator.Framework.PluginManagement;

namespace SpecIFicator.Framework.RazorComponents
{
    public partial class SpecIfDataStreamConnector
    {
        [Inject]
        IStringLocalizer<SpecIfDataStreamConnector> L { get; set; }

        private List<Type> _connectorTypes = new List<Type>();

        private Type ActiveType
        {
            get;
            set;
        }

        private string ActiveTypeName
        {
            get
            {
                return ActiveType?.FullName;
            }
            set
            {
                foreach (var type in _connectorTypes)
                {
                    if (type.FullName == value)
                    {
                        ActiveType = type;
                        break;
                    }
                }
            }

        }

        protected override void OnInitialized()
        {
            //_configurationReaderWriter = new FileConfigurationReaderWriter<DataConnectorConfiguration>();

            //_configuration = _configurationReaderWriter.GetConfiguration();

            //if (_configuration == null)
            //{
            //    _configuration = new DataConnectorConfiguration();
            //}

            _connectorTypes = PluginManager.GetTypes(typeof(ISpecIfDataStreamConnector)).ToList();
            if (_connectorTypes.Count > 0)
            {
                int count = 0;

                ActiveTypeName = _connectorTypes[0].FullName;

                //foreach (Type connectorType in _connectorTypes)
                //{
                //    if (connectorType.FullName == _configuration.LastUsedTypeName)
                //    {
                //        ActiveType = _connectorTypes[count];
                //        break;
                //    }
                //    count++;
                //}


            }

        }

        private void OnTypeSelectionChange(ChangeEventArgs arguments)
        {
            string fullTypeName = arguments.Value.ToString();


            if (_connectorTypes.Any())
            {
                ActiveTypeName = _connectorTypes.Find(type => type.FullName == fullTypeName).FullName;

                //_configuration.LastUsedTypeName = ActiveType.FullName;

                //_configurationReaderWriter.StoreConfiguration(_configuration);
            }
        }
    }
}