namespace Eshop.Web.Models.Home
{
    using System.Collections.Generic;
    using Categories;
    using Items;

    public class HomeIndexViewModel
    {
        public ICollection<CategoryViewModel> Categories { get; set; }

        public ICollection<ItemViewModel> NewestItems { get; set; }
    }
}