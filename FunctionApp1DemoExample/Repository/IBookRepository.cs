using FunctionApp1DemoExample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp1DemoExample.Repository
{
    public interface IBookRepository 
    {
        public List<Book> GetBooks();
        public Book GetBookById(int id);
    }
}
