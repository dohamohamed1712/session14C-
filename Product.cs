using System;
using System.Collections.Generic;
using System.Text;

namespace session14C_
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Foreign Key + Navigation Property: Many-to-One (Product -> Category)
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // Many-to-Many with Order (through OrderDetail)
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
