namespace Eshop.Services.Data.Contracts
{
    using System.Linq;
    using Base;
    using Eshop.Data.Models;
    using GlobalConstants;

    public interface IItemsService : IBaseService<Item>
    {
        Item AddItem(Item itemToAdd);

        IQueryable<Item> GetNewestItems(bool paged, int? count = null, int page = CommonConstants.DEFAULT_PAGE, int pageSize = CommonConstants.DEFAULT_PAGE_SIZE);

        IQueryable<Item> FindByCategory(string name, int page = CommonConstants.DEFAULT_PAGE, int pageSize = CommonConstants.DEFAULT_PAGE_SIZE);
    }
}
