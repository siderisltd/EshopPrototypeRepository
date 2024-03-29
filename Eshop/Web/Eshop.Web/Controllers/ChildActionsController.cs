﻿namespace Eshop.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping.Contracts;
    using Models.Categories;
    using Services.Data.Contracts;

    [ChildActionOnly]
    public class ChildActionsController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public ChildActionsController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [OutputCache(Duration = 5 * 60, VaryByCustom = "culture")]
        public ActionResult GetCategoriesTree()
        {
            var categories = this.categoriesService.GetAllCategories().To<CategoryViewModel>().ToList();
            CategoriesTreeModel model = new CategoriesTreeModel { Seed = null, Categories = categories };

            return this.PartialView("_Categories", model);
        }
    }
}