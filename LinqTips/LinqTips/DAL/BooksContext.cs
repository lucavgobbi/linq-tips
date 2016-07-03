using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LinqTips.Models;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LinqTips.DAL
{
    public class BooksContext : DbContext
    {
        public BooksContext() : base("BooksContext")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
