namespace Eshop.Web.Models.Items
{
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class ItemViewModel : IMapFrom<Item>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public int Rating { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPercentage { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Item, ItemViewModel>()
                .ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Rating.Any() ? (x.Rating.Sum(y => y.Value) / x.Rating.Count) : 0))
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}