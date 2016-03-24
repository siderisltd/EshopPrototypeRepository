namespace Eshop.Web.Models.Categories
{
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }
    }
}
