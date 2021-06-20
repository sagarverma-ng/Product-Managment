using System;
using System.Collections.Generic;

#nullable disable

namespace ProductManagment.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductSets = new HashSet<ProductSet>();
        }

        public int Id { get; set; }
        public string NameData { get; set; }

        public virtual ICollection<ProductSet> ProductSets { get; set; }
    }
}
