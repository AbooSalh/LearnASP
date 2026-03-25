using System.ComponentModel.DataAnnotations;

namespace ECommerceOrders.Models
{
    public class Order
    {
        public int? OrderNo { get; set; }
        [Required(ErrorMessage ="{0} is requeird")]
        public DateTime? OrderDate { get; set; }
        [Required(ErrorMessage = "Invoice price is required.")]
        public double InvoicePrice { get; set; }
        [Required(ErrorMessage = "Products are required.")]
        public List<Product>? Products { get; set; }
    }
}
