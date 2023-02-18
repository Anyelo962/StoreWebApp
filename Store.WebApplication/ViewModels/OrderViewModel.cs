using Store.WebApplication.Entities;
using System;
using System.Collections.Generic;

namespace Store.WebApplication.ViewModels
{
    public class OrderViewModel
    {
        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }
        public List<Orders> Orders { get; set; }

        public int idClient { get; set; }
        public string nameClient { get; set; }
        public string nameProduct { get; set; }
    }
}
