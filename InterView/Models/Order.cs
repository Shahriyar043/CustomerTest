using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InterView.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CUSTOMERID { get; set; }

        [DisplayName("Sifarış adı")]
        public string ORDERNAME { get; set; }

        [DisplayName("Qiyməti")]
        public decimal SALARY { get; set; }

       

        public Order()
        {
        }

        public Order(int id, int customerid, string ordername, decimal salary)
        {
            Id = id;
            CUSTOMERID = customerid;
            ORDERNAME = ordername;
            SALARY = salary;
        }

    }
}