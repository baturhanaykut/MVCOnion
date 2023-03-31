using MVCOnion.Application.DTOs.AuthorDtos;
using MVCOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Application.IServices
{
    public interface IAuthorService
    {
        Task<bool> AuthorCreate(AuthorCreateDto authorCreateDto);
        Task<bool> AuthorUpdate(AuthorUpdateDto authorUpdateDto);
        Task<bool> AuthorDelete(int authorId);

        Task<IEnumerable<AuthorListDto>> AuthorLists(Expression<Func<Author, bool>> filter = null!);

        Task<AuthorCreateDto> GetByAuthorId(int aouthorId);

        Task<int> GetIdByAuthorNameAndLastName(string name, string lastName);
    }
}
