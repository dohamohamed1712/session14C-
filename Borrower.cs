using System;
using System.Collections.Generic;
using System.Text;

namespace session14C_2
{
    public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime MembershipDate { get; set; }

        // Many-to-Many with Book (through Loan)
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
