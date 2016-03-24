namespace Eshop.Services.Data
{
    using System.Linq;
    using Base;
    using Contracts;
    using Eshop.Data.Models;
    using Eshop.Data.Repositories;

    public class ItemsService : BaseService<Item>, IItemsService
    {
        public ItemsService(IRepository<Item> repo)
            : base(repo)
        {
        }

        public Item AddItem(Item itemToAdd)
        {
            return itemToAdd;
        }

        public IQueryable<Item> GetNewestItems(int count)
        {
            return this.repo.All().OrderByDescending(x => x.CreatedOn).Take(count);
        }
    }
}
