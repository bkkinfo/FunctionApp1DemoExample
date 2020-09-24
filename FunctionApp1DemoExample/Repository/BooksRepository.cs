using FunctionApp1DemoExample.Data;
using FunctionApp1DemoExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionApp1DemoExample.Repository
{
    public class BooksRepository : IBookRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BooksRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public List<Book> GetBooks()
        {
            //using (var context = new LibraryDbContext())
            //{
                List<Book> books = _libraryDbContext.Books.ToList();
                return books;
            //}
        }
        public Book GetBookById(int id)
        {
            //using (var context = new LibraryDbContext())
            //{
                List<Book> books = (List<Book>)_libraryDbContext.Books.//FirstOrDefault();
                    Where(x=>x.BookId==id);
                return books.FirstOrDefault();
            //}
        }

    }
}
