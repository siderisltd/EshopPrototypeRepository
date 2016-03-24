namespace Eshop.Web.Controllers
{
    using Services.Data.Contracts;
    using System.Web.Mvc;
    using Data.Common.Roles;
    using Data.Models;
    using Helpers.Filters;
    using Models.Categories;

    [AuthorizeRoles(AppRoles.ADMIN_ROLE, AppRoles.CLIENT_ROLE, AppRoles.ULTIMATE_ROLE)]
    public class CategoriesController : BaseController
    {
        private ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService service)
        {
            this.categoriesService = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AjaxActionFilter]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Index", model);
            }
            var category = new Category { Name = model.Name, ParentId = model.ParentId };
            this.categoriesService.AddCategory(category);
            this.TempData["Notification"] = "Category added";
            return this.JavaScript("window.location = '/Home/Index'");
        }


        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    var allCategories = this.categoriesService
        //                                    .GetAllCategories()
        //                                    .To<CategoryViewModel>()
        //                                    .ToList();

        //    return View(allCategories);
        //}

    }
}