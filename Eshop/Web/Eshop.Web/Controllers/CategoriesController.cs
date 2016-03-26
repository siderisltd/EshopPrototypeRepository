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

        [HttpGet]
        public ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        [AjaxActionFilter]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Manage", model);
            }
            var category = new Category { Name = model.Name, ParentId = model.ParentId };
            this.categoriesService.AddCategory(category);
            this.TempData["Notification"] = "Category added";
            return this.JavaScript("window.location = '/Home/Index'");
        }

        [HttpDelete]
        [AjaxActionFilter]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Manage", model);
            }

            bool success = this.categoriesService.DeleteCategory(model.Id);
            if (success)
            {
                this.TempData["Notification"] = "Category deleted";
                return this.JavaScript("window.location = '/Home/Index'");
            }
            else
            {
                return this.View("Manage", model);
            }

        }

    }
}