using Orleans.Services;

namespace Grains.Interfaces.Services
{
    public interface IStocksGrainServiceClient : IGrainServiceClient<IStocksGrainService>, IStocksGrainService
    {
    }
}
