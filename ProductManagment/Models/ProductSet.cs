using System;
using System.Collections.Generic;

#nullable disable

namespace ProductManagment.Models
{
    public partial class ProductSet
    {
        public int Id { get; set; }
        public string Nameinfo { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
