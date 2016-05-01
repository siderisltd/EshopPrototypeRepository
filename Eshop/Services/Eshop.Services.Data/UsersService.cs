namespace Eshop.Services.Data
{
    using Base;
    using Contracts;
    using Eshop.Data.Models;
    using Eshop.Data.Repositories;

    public class UsersService : BaseService<User>, IUsersService
    {
        public UsersService(IRepository<User> repo)
            : base(repo)
        {
        }

        public string GetUserCulture(string userId)
        {
            return this.repo.GetById(userId).Culture;
        }

        public string SetUserCulture(string userId, string cultureName)
        {
            this.repo.GetById(userId).Culture = cultureName;
            this.repo.SaveChanges();
            return cultureName;
        }
    }
}
