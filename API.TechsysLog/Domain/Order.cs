using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.TechsysLog.Domain
{
    [Table("order")]
    public class Order
    {
        public Order(string description, long orderNumber, float price, string address, int cEP)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            OrderNumber = orderNumber;
            Price = price;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            CEP = cEP;
        }

        [Key]
        public int Id { get; private set; }
        public string Description { get; private set; }
        public long OrderNumber { get; private set; }
        public float Price { get; private set; }
        public string Address  { get; private set; }
        public int CEP { get; private set; }

        
    }
}
