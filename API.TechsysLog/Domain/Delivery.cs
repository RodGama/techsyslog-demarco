using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.TechsysLog.Domain
{
    [Table("delivery")]
    [Index(nameof(OrderNumber))]

    public class Delivery
    {
        public Delivery() { }
        public Delivery(long orderNumber)
        {
            OrderNumber = orderNumber;
        }
        [Key]
        public int Id { get; private set; }
        [ForeignKey(nameof(Order.OrderNumber))]
        public long OrderNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
