namespace Eshop.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
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


        [OutputCache(Duration = 1, VaryByParam = "none")]
        public ActionResult GetCategories()
        {
            var categories = this.categoriesService.GetAllCategories().To<CategoryViewModel>().ToList();
            CategoriesTreeModel model = new CategoriesTreeModel { Seed = null, Categories = categories };

            return this.PartialView("_Categories", model);
        }
    }
}