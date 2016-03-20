namespace Eshop.Web.Models
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
    }
}
