namespace API.TechsysLog.DTOs
{
    public class OrderDTO
    {
        public string Description { get; set; }
        public long OrderNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
