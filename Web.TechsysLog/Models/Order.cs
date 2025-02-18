using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.TechsysLog.Models
{
    public class Order
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }
        public long OrderNumber { get; set; }
    }
}