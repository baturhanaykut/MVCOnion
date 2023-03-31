using Microsoft.EntityFrameworkCore;
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
    public class AuthorRepository : BaseRepository<Author, ApplicationDbContext>, IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<int> GetIdByNameAndLastName(string name, string lastName)
        {
            Author? author = await _context.Set<Author>().FirstOrDefaultAsync(x => x.IsActive && x.FirstName == name && x.LastName == lastName);

            return author!.Id;
        }
    }
}
