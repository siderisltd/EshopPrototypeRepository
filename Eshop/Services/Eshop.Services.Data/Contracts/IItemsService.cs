namespace Eshop.Services.Data.Contracts
{
    using System.Linq;
    using Base;
    using Eshop.Data.Models;

    public interface IItemsService : IBaseService<Item>
    {
        Item AddItem(Item itemToAdd);

        IQueryable<Item> GetNewestItems(int count);
    }
}
