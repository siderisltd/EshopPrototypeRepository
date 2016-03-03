namespace Eshop.Web.Controllers
{
    using System.Web.Mvc;

    [ChildActionOnly]
    public class ChildActionsController : BaseController
    {
        //TODO: Sample usage and you call it with @Html.Action in the view -> This is useful for the sidebar and the other parts that can be cached safely

        //[OutputCache(Duration = 5 * 60, VaryByParam = "none")]
        //public ActionResult GetSlider()
        //{
        //    var model = this.articlesService.GetTopCountPostsByRatingInEveryCategory(4).To<CategoryAndPostsViewModel>().ToList();
        //    return this.PartialView("_Slider", model);
        //}
    }
}