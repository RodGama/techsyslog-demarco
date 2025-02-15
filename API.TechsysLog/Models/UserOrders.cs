using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.TechsysLog.Models
{
    [Table("user_order")]
    [Index(nameof(OrderNumber), nameof(UserId))]
    public class UserOrders
    {
        [Key]
        public int Id { get; set; }
        public long OrderNumber { get; set; }
        public long UserId { get; set; }
    }
}
