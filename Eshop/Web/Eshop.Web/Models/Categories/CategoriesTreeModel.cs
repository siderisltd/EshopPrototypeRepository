namespace Eshop.Web.Models.Categories
{
    using System.Collections.Generic;

    public class CategoriesTreeModel
    {
        public int? Seed { get; set; }

        public IList<CategoryViewModel> Categories { get; set; }
    }
}