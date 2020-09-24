using FunctionApp1DemoExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp1DemoExample.Data
{
    public class LibraryDbContext : DbContext
    {
        //public LibraryDbContext()
        //{
        //}

        public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions): base(dbContextOptions)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
