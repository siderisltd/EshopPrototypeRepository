namespace Eshop.Web.Models.Items
{
    using System.ComponentModel.DataAnnotations;

    public class ItemFeatureBindingModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }
    }
}