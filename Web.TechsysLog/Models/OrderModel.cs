using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.TechsysLog.Models
{
    public class OrderModel
    {
        public OrderModel(string description, long orderNumber, float price, int cEP, int addressNumber, string street, string neighborhood, string city, string state)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            OrderNumber = orderNumber;
            Price = price;
            AddressNumber = addressNumber;
            Street = street ?? throw new ArgumentNullException(nameof(street));
            Neighborhood = neighborhood ?? throw new ArgumentNullException(nameof(neighborhood));
            City = city ?? throw new ArgumentNullException(nameof(city));
            State = state ?? throw new ArgumentNullException(nameof(state));
            CEP = cEP;
        }

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