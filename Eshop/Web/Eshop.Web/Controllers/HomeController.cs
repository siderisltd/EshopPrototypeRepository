﻿using Eshop.Services.Data.Contracts;
using System.Web.Mvc;

namespace Eshop.Web.Controllers
{
    using System.Linq;
    using Infrastructure.Mapping.Contracts;
    using Models.Categories;
    using Models.Home;
    using Models.Items;

    public class HomeController : BaseController
    {
        private readonly IItemsService itemsService;
        private readonly ICategoriesService categoriesService;

        public HomeController(IItemsService itemsService, ICategoriesService categoriesService)
        {
            this.itemsService = itemsService;
            this.categoriesService = categoriesService;
        }

        public ActionResult Index()
        {
            var newestItems = this.Cache.Get("newestItems",
                () => this.itemsService.GetNewestItems(10).To<ItemViewModel>().ToList(), 10);

            var categories = this.Cache.Get("mainCategories",
                () => this.categoriesService.GetMainCategories().To<CategoryViewModel>().ToList(), 10);


            var model = new HomeIndexViewModel();
            model.NewestItems = newestItems;
            model.Categories = categories;
        
            return this.View(model);
        }
    }
}