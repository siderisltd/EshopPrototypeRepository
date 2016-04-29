namespace Eshop.Web.Models.Items
{
    using System.Web;

    public class ImageBindingModel
    {
        public string Title { get; set; }

        public bool IsMain { get; set; }

        public HttpPostedFileBase Content { get; set; }
    }
}