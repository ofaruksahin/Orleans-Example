using Grains.Interfaces;
using Grains.Interfaces.Services;

namespace Grains
{
    public class StocksStreamingGrain : Grain, IStocksStreamingGrain
    {
        private IStocksGrainServiceClient _grainServiceClient;

        private string price = string.Empty;

        public StocksStreamingGrain(IStocksGrainServiceClient grainServiceClient)
        {
            _grainServiceClient = grainServiceClient;
        }

        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            var ticker = this.GetPrimaryKeyString();

            await UpdatePrice(ticker);

            RegisterTimer(
                UpdatePrice,
                ticker,
                TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(10));

            await base.OnActivateAsync(cancellationToken);
        }

        private async Task UpdatePrice(object stock)
        {
            price = await _grainServiceClient.GetPriceQuota();

            Console.WriteLine(price);
        }

        public Task<string> GetPrice()
        {
            return Task.FromResult(price);
        }
    }
}
