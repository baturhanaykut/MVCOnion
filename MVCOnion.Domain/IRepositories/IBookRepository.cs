using MVCOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Domain.IRepositories
{
    public interface IBookRepository:IBaseRepository<Book>
    {
        Task<bool> CreateRange(List<Book> books);
    }
}
