using System;
using System.Collections.Generic;
using System.Text;

namespace session14C_
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        // Foreign Key + Navigation Property: Many-to-One (Order -> Customer)
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        // Many-to-Many with Product (through OrderDetail)
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
