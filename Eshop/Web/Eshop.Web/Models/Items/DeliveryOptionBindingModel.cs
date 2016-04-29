namespace Eshop.Web.Models.Items
{
    public class DeliveryOptionBindingModel
    {
        public string Name { get; set; }

        public int MinDays { get; set; }

        public int MaxDays { get; set; }

        public decimal Price { get; set; }
    }
}