using MDD4All.SpecIF.DataProvider.Contracts;

namespace SpecIFicator.Framework.CascadingValues
{
    public class SpecIfDataConnectorContext
    {
        public Action ConnectAction { get; set; }

        public ISpecIfDataProviderFactory SpecIfDataProviderFactory { get; set; }
    }
}
