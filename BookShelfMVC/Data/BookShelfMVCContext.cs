using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookShelfMVC.Models
{
    public class BookShelfMVCContext : DbContext
    {
        public BookShelfMVCContext (DbContextOptions<BookShelfMVCContext> options)
            : base(options)
        {
        }

        public DbSet<BookShelfMVC.Models.Book> Book { get; set; }
    }
}
