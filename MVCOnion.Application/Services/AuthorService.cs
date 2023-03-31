using MVCOnion.Application.DTOs.AuthorDtos;
using MVCOnion.Application.IServices;
using MVCOnion.Domain.Entities;
using MVCOnion.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<bool> AuthorCreate(AuthorCreateDto authorCreateDto)
        {
            Author author = new Author()
            {
                FirstName = authorCreateDto.FirstName,
                LastName = authorCreateDto.LastName,
                CreatedDate = authorCreateDto.CreateDate,
                IsActive = authorCreateDto.IsActive
            };

            return await _authorRepository.Create(author);
        }

        public async Task<bool> AuthorDelete(int authorId)
        {
            Author author = await _authorRepository.GetById(authorId);

            return await _authorRepository.Delete(author);

        }

        public async Task<IEnumerable<AuthorListDto>> AuthorLists(Expression<Func<Author, bool>> filter = null)
        {
            List<Author> authorList = _authorRepository.GetFilteredAll(filter).Result.ToList();

            List<AuthorListDto> authorLists = authorList.Select(x => new AuthorListDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();

            return authorLists;  // List döndüğümüz için 
        }

        public async Task<bool> AuthorUpdate(AuthorUpdateDto authorUpdateDto)
        {
            Author author = await _authorRepository.GetById(authorUpdateDto.Id);

            author.FirstName = authorUpdateDto.FirstName;
            author.LastName = authorUpdateDto.LastName;
            author.UpdateDate = authorUpdateDto.UpdateDate;

            return await _authorRepository.Update(author);

        }

        public async Task<AuthorCreateDto> GetByAuthorId(int aouthorId)
        {
            Author author = await _authorRepository.GetById(aouthorId);

            AuthorCreateDto authorCreateDto = new AuthorCreateDto()
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
        
            };

            return authorCreateDto;
        }


        public async Task<int> GetIdByAuthorNameAndLastName(string name, string lastName)
        {
            return await _authorRepository.GetIdByNameAndLastName(name, lastName);
        }

     
    }
}
