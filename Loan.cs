using System;
using System.Collections.Generic;
using System.Text;

namespace session14C_2
{
    public class Loan
    {
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        public int BorrowerId { get; set; }
        public Borrower Borrower { get; set; } = null!;

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; } // nullable: the book may not be returned yet
    }
}
