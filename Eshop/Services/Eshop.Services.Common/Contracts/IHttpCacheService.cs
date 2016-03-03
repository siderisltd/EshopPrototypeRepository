namespace Eshop.Services.Common.Contracts
{
    using System;

    public interface IHttpCacheService
    {
        T Get<T>(string itemName, Func<T> getDataFunc, int durationInSeconds);

        void Remove(string itemName);
    }
}
