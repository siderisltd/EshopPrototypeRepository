namespace Eshop.Web.Models.Items
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using App_GlobalResources.Items;

    public class ItemBindingModel
    {
        public int CategoryId { get; set; }

        [Display(ResourceType =typeof(ItemsResources), Name= "Title")]
        public string Title { get; set; }

        [Display(ResourceType = typeof(ItemsResources), Name = "Description")]
        public string Description { get; set; }

        [Display(ResourceType = typeof(ItemsResources), Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(ResourceType = typeof(ItemsResources), Name = "Price")]
        [UIHint("DecimalPrice")]
        public decimal Price { get; set; }

        [Display(ResourceType = typeof(ItemsResources), Name = "DiscountPercentage")]
        [UIHint("DecimalPercentage")]
        public decimal DiscountPercentage { get; set; }

        public int DeliveryId { get; set; }

        public DeliveryBindingModel Delivery { get; set; }

        public ICollection<ItemFeatureBindingModel> ItemFeatures { get; set; }

        public ICollection<ImageBindingModel> Images { get; set; }
    }
}