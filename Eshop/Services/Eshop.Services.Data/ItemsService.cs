namespace Eshop.Services.Data
{
    using System.Linq;
    using Base;
    using Contracts;
    using Eshop.Data.Models;
    using Eshop.Data.Repositories;
    using GlobalConstants;

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

        public IQueryable<Item> GetNewestItems(bool paged, int? count = null, int page = CommonConstants.DEFAULT_PAGE, int pageSize = CommonConstants.DEFAULT_PAGE_SIZE)
        {
            var query = this.repo
                            .All()
                            .OrderByDescending(x => x.CreatedOn);

            if (count != null)
            {
                int countAsInt = (int)count;
                var newQuery = query.Take(countAsInt);
                return newQuery;
            }

            if (paged)
            {
                var pagedQuery = query
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);

                return pagedQuery;
            }

            return query;
        }

        public IQueryable<Item> FindByCategory(string name, int page = CommonConstants.DEFAULT_PAGE, int pageSize = CommonConstants.DEFAULT_PAGE_SIZE)
        {
            var query = this.repo
                            .All()
                            .Where(x => x.Category.Name == name)
                            .OrderByDescending(x => x.CreatedOn)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize);

            return query;
        }
    }
}
