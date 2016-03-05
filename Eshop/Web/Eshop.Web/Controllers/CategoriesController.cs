namespace Eshop.Web.Controllers
{
    using DataTransferModels.Category;
    using Infrastructure.Mapping.Contracts;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;

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
            //does not map with the custom mapping
            //var modelToReturn = this.categoriesService
            //                                .GetAllCategories()
            //                                .To<AllCategoriesViewModel>()
            //                                .ToList();
            var modelToReturn = this.categoriesService
                                            .GetAllCategories()
                                            .Select(x => new AllCategoriesViewModel
                                            {
                                                Id = x.Id,
                                                Name = x.Name,
                                                ParentId = (x.ParentId == null) ? -1 : x.ParentId
                                            })
                                            .ToList();
            return View(modelToReturn);
        }

    }
}