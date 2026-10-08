using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace session14C_2
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Borrower> Borrowers => Set<Borrower>();
        public DbSet<Loan> Loans => Set<Loan>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=LibraryManagementDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(e =>
            {
                e.Property(a => a.Name).IsRequired().HasMaxLength(100);
            });

            // Book (Many-to-One with Author)
            modelBuilder.Entity<Book>(e =>
            {
                e.Property(b => b.Title).IsRequired().HasMaxLength(200);
                e.Property(b => b.ISBN).IsRequired().HasMaxLength(20);

                e.HasOne(b => b.Author)
                 .WithMany(a => a.Books)
                 .HasForeignKey(b => b.AuthorId);
            });

            modelBuilder.Entity<Borrower>(e =>
            {
                e.Property(b => b.Name).IsRequired().HasMaxLength(100);
            });

            // Loan (Many-to-Many between Book and Borrower)
            modelBuilder.Entity<Loan>(e =>
            {
                e.HasKey(l => new { l.BookId, l.BorrowerId, l.LoanDate });

                e.HasOne(l => l.Book)
                 .WithMany(b => b.Loans)
                 .HasForeignKey(l => l.BookId);

                e.HasOne(l => l.Borrower)
                 .WithMany(b => b.Loans)
                 .HasForeignKey(l => l.BorrowerId);
            });
        }
    }
}
