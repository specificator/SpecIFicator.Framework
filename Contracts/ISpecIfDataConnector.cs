using MDD4All.SpecIF.DataProvider.Contracts;

namespace SpecIFicator.Framework.Contracts
{
    public interface ISpecIfDataConnector
    {
        public string Title { get; }

        public ISpecIfDataProviderFactory SpecIfDataProviderFactory { get; }
    }
}
