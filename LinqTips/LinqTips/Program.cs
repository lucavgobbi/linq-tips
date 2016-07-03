using LinqTips.DAL;
using LinqTips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTips
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BooksContext())
            {
                //var authors = db.Authors.ToList();
                var author = new Author
                {
                    Name = "Guy Kawasaki",
                    BirthDate = new DateTime(1954, 8, 30)
                };
                db.Authors.Add(author);

                db.SaveChanges();
            }

            Example3();
                
            Console.ReadKey();
        }

        public static void Example1()
        {
            using (var db = new BooksContext())
            {
                var condition1 = true;
                var condition2 = false;
                
                // Don't do or at least avoid
                var asList = (from book in db.Books where book.Year >= 1990 select book).ToList();
                var asList2 = db.Books.Where(w => w.Year >= 1990).ToList();

                // Good!Tip 2
                var iQueryable = from book in db.Books where book.Year >= 1990 select book;
                var iQueryable2 = db.Books.Where(w => w.Year >= 1990);

                if (condition1)
                {
                    iQueryable = iQueryable.Where(w => w.Name.Contains("criteria"));
                }
                if (condition2)
                {
                    iQueryable = iQueryable.Where(w => w.Year <= 2010);
                }
            }
        }
        

        public static void Example2()
        {
            using (var db = new BooksContext())
            {
                var withDynamic = db.Books.Where(w => w.Year > 2000).Select(s => new {Id = s.Id, Name = s.Name});

                foreach (var item in withDynamic)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        public static void Example3()
        {
            using (var db = new BooksContext())
            {
                var withInclude = db.Books.Include("Author").Where(w => w.Year > 2000);

                foreach (var item in withInclude)
                {
                    Console.WriteLine(item.Author.Name);
                }
            }
        }
    }
}
