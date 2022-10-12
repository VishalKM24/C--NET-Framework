using EFHandsOn1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFHandsOn1.UI
{
    public interface IPhoneReository
    {
        long SavePhone(Phone phone);
        long SaveCustomer(Customer customer);
        long SaveOrder(CustomerOrder order);
        long SaveOrderedPhone(OrderedPhone phone, long OrderId);
        List<CustomerOrder> GetCustomerOrders(long CustomerId);
        List<CustomerOrder> GetAllCustomerOrders();
    }
}
