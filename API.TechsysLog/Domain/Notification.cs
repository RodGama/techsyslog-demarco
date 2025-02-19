using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.TechsysLog.Domain
{
    [Table("notification")]
    public class Notification
    {
        public Notification(int deliveryId, DateTime notifiedDate)
        {
            DeliveryId = deliveryId;
            NotifiedDate = notifiedDate;
        }

        [Key]
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public DateTime NotifiedDate { get; set; }
        public DateTime ReadDate { get; set; }
    }
}
