using Grains.Interfaces.Services;
using Orleans.Runtime.Services;

namespace Grains.Services
{
    public class StocksGrainServiceClient : GrainServiceClient<IStocksGrainService>, IStocksGrainServiceClient
    {
        public StocksGrainServiceClient(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<string> GetPriceQuota() => GetGrainService(CurrentGrainReference.GrainId).GetPriceQuota();
    }
}
