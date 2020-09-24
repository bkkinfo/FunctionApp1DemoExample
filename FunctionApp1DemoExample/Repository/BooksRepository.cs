using FunctionApp1DemoExample.Data;
using FunctionApp1DemoExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionApp1DemoExample.Repository
{
    public class BooksRepository
    {
        public List<Book> GetBooks()
        {
            using (var context = new LibraryDbContext())
            {
                List<Book> books = context.Books.ToList();
                return books;
            }
        }
        public Book GetBookById(int id)
        {
            using (var context = new LibraryDbContext())
            {
                List<Book> books = (List<Book>)context.Books.//FirstOrDefault();
                    Where(x=>x.BookId==id);
                return books.FirstOrDefault();
            }
        }
    }
}
