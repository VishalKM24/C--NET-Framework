using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFHandsOn1.Entity
{
    public class Phone
    {
        public long PhoneId { get; set; }
        public string PhoneDescripion { get; set; }

        public float Price { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public string BrandName { get; set; }
        public int InStock { get; set; }
    }

    public class OrderedPhone
    {
        public long OrderedPhoneId { get; set; }
        public Phone Phone { get; set; }
        public float Quantity { get; set; }
    }

    public class Customer
    {
        [Key]
        public long CustomerId { get; set; }
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [Required]
        // Convert to Email type
        public string EmailId { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string PinCode { get; set; }
        public long MobileNo { get; set; }
        public virtual List<CustomerOrder> Orders { get; set; } = new List<CustomerOrder>();
    }

    public class CustomerOrder
    {
        [Key]
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public float OrderTotal { get; set; }
        public List<OrderedPhone> OrderedPhones { get; set; } = new List<OrderedPhone>();
    }
}
