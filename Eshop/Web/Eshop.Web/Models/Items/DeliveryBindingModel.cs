namespace Eshop.Web.Models.Items
{
    using System.Collections.Generic;

    public class DeliveryBindingModel
    {
        private ICollection<DeliveryOptionBindingModel> domesticDelivery;
        private ICollection<DeliveryOptionBindingModel> worldwideDelivery;
        private ICollection<DeliveryOptionBindingModel> europeDelivery;
    }
}