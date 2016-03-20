namespace Eshop.Web.Controllers
{
    using Infrastructure.Mapping.Contracts;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    [Authorize]
    public class CategoriesController : BaseController
    {
        private ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService service)
        {
            this.categoriesService = service;
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            var allCategories = this.categoriesService
                                            .GetAllCategories()
                                            .To<CategoryViewModel>()
                                            .ToList();

            return View(allCategories);
        }

    }
}