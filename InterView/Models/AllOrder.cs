using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterView.Models
{
    public class AllOrder
    {
        public List<Order> ListOrder { get; set; }
        public Order Order { get; set; }
    }
}