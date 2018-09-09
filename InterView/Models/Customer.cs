using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InterView.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [DisplayName("Ad")]
        public string FIRSTNAME { get; set; }

        [DisplayName("Soyad")]
        public string LASTNAME { get; set; }

        [DisplayName("Ata adı")]
        public string FATHERNAME { get; set; }
        
        [DisplayName("Doğum tarixi")]
        public DateTime BIRTHDAY { get; set; }

        public Customer()
        {
        }

        public Customer(int id, string name, string surname,string fathername, DateTime birthday)
        {
            Id = id;
            FIRSTNAME = name;
            LASTNAME = surname;
            FATHERNAME = fathername;
            BIRTHDAY = birthday;
        }

        
    }
}