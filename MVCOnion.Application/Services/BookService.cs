using MVCOnion.Application.DTOs.BookDtos;
using MVCOnion.Application.IServices;
using MVCOnion.Domain.Entities;
using MVCOnion.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> BookCreate(BookCreateDto bookCreateDto)
        {
            Book book = new Book()
            {
                BookName = bookCreateDto.BookName,
                CreatedDate = bookCreateDto.CreatedDate,
                IsActive = bookCreateDto.IsActive,
                AuthorId = bookCreateDto.AuthorId

            };

            return await _bookRepository.Create(book);
        }

        public async Task<bool> BookCreateRange(List<BookCreateDto> bookCreateDto)
        {
            List<Book> books = bookCreateDto.Select(x => new Book
            {
                BookName = x.BookName,
                CreatedDate = x.CreatedDate,
                IsActive = x.IsActive,
                AuthorId = x.AuthorId

            }).ToList();

            return await  _bookRepository.CreateRange(books);
        }

        public async Task<bool> BookDelete(int bookId)
        {
            Book book = await _bookRepository.GetById(bookId);

            return await _bookRepository.Delete(book);
        }

        public async Task<bool> BookUpdate(BookUpdateDto bookUpdateDto)
        {
            Book book = await _bookRepository.GetById(bookUpdateDto.BookId);

            book.UpdateDate = bookUpdateDto.UpdateDate;
            book.BookName = bookUpdateDto.BookName;

            return await _bookRepository.Update(book);
        }

        public async Task<List<BookListDto>> GetBooksAuthorId(int authorId)
        {
            return _bookRepository.GetFilteredAll(x => x.AuthorId == authorId && x.IsActive).Result.Select(x => new BookListDto
            {
                BookId = x.Id,
                BookName = x.BookName
            }).ToList();

        }
    }
}
