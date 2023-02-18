using Grains.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Orleans.Runtime;

namespace Grains.Services
{
    public class StocksGrainService : GrainService, IStocksGrainService
    {
        readonly IGrainFactory _grainFactory;

        int lastPrice = 0;

        public StocksGrainService(
            IServiceProvider services,
            GrainId id,
            Silo silo,
            ILoggerFactory loggerFactory,
            IGrainFactory grainFactory)
            : base(id, silo, loggerFactory)
        {
            _grainFactory = grainFactory;
        }

        public override Task Init(IServiceProvider serviceProvider)
        {
            return base.Init(serviceProvider);
        }

        public Task<string> GetPriceQuota()
        {
            lastPrice++;
            return Task.FromResult(lastPrice.ToString());
        }
    }
}
