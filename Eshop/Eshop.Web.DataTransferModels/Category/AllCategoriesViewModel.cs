namespace Eshop.Web.DataTransferModels.Category
{
    using System;
    using AutoMapper;
    using Eshop.Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class AllCategoriesViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            //not working and dont know why..?
            configuration.CreateMap<Category, AllCategoriesViewModel>()
                .ForMember(x => x.ParentId, opts => opts.MapFrom(p => (p.ParentId == null) ? -1 : p.ParentId));
        }
    }
}
