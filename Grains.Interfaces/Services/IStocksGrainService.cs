using Orleans.Services;

namespace Grains.Interfaces.Services
{
    public interface IStocksGrainService : IGrainService
    {
        Task<string> GetPriceQuota();
    }
}
