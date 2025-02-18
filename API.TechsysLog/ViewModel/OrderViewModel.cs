namespace API.TechsysLog.ViewModel
{
    public class OrderViewModel 
    {
        public string Description { get; set; }
        public long OrderNumber { get; set; }
        public float Price { get; set; }
        public int CEP { get; set; }
        public int AddressNumber { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
