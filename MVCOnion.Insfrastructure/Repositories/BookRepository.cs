using MVCOnion.Domain.Entities;
using MVCOnion.Domain.IRepositories;
using MVCOnion.Insfrastructure.ModelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Insfrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book, ApplicationDbContext>,IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _db = context;
        }

        public async Task<bool> CreateRange(List<Book> books)
        {
            await _db.AddRangeAsync(books);
            return await  _db.SaveChangesAsync() > 0;
        }
    }
}
