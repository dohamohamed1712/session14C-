using System;
using System.Collections.Generic;
using System.Text;

namespace session14C_2
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;

        // Many-to-One (Book -> Author)
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        // Many-to-Many with Borrower (through Loan)
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
