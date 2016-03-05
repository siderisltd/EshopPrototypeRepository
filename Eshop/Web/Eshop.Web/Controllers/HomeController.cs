using Eshop.Services.Data.Contracts;
using System.Web.Mvc;

namespace Eshop.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IItemsService itemsService;

        public HomeController(IItemsService itemsService)
        {
            this.itemsService = itemsService;
        }

        public ActionResult Index()
        {

            //TODO: Inherit BaseController in every controller this is a sample usage of the cache service 

            //var newestPosts = this.Cache.Get(
            //"newestPosts",
            //() => this.articlesService.GetNewestPosts(16).To<ArticleViewModel>().ToList(), 10);

            //And you have this.Mapper also and you can map objects with it...

            return this.View();
        }
    }
}