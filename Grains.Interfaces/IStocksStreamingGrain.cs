namespace Grains.Interfaces
{
    public interface IStocksStreamingGrain : IGrainWithStringKey
    {
        Task<string> GetPrice();
    }
}
