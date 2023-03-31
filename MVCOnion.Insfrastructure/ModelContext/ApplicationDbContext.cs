using Microsoft.EntityFrameworkCore;
using MVCOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Insfrastructure.ModelContext
{
    public class ApplicationDbContext:DbContext
    {
        public const string _connectionString = "ApplicationDbConnection";
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }



    }
}
