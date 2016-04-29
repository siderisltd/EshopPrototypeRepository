namespace Eshop.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using GlobalConstants;
    using Infrastructure.Mapping.Contracts;
    using Models.Items;
    using Services.Data.Contracts;

    public class ItemsController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IItemsService itemsService;

        public ItemsController(ICategoriesService categoriesService, IItemsService itemsService)
        {
            this.categoriesService = categoriesService;
            this.itemsService = itemsService;
        }

        [HttpGet]
        public ActionResult ByCategory(string name, int page = CommonConstants.DEFAULT_PAGE, int pageSize = CommonConstants.DEFAULT_PAGE_SIZE)
        {
            var foundItems = this.itemsService.FindByCategory(name).To<ItemViewModel>().ToList();

            // TODO: define how the results will be displayed
            return null;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ItemBindingModel model)
        {
            return null;
        }
    }
}