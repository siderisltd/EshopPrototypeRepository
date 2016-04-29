namespace Eshop.Web.Models.Items
{
    using System.Resources;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources;
    using Microsoft.VisualStudio.Modeling.Design;

    public class ItemBindingModel
    {
        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPercentage { get; set; }

        public int DeliveryId { get; set; }

        public DeliveryBindingModel Delivery { get; set; }

        public ICollection<ItemFeatureBindingModel> ItemFeatures { get; set; }

        public ICollection<ImageBindingModel> Images { get; set; }
    }
}