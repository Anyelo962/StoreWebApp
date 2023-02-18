using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.WebApplication.Entities
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int? IdProduct { get; set; }
        public int? IdClient { get; set; }
        public DateTime? OrdersDate { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
