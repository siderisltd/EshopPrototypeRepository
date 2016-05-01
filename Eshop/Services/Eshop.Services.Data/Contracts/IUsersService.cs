namespace Eshop.Services.Data.Contracts
{
    using Base;
    using Eshop.Data.Models;

    public interface IUsersService : IBaseService<User>
    {
        string GetUserCulture(string userId);

        string SetUserCulture(string userId, string cultureName);
    }
}
