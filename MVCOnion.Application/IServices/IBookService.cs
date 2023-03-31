using MVCOnion.Application.DTOs.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Application.IServices
{
    public interface IBookService
    {
        Task<bool> BookCreate(BookCreateDto bookCreateDto);

        Task<bool> BookUpdate(BookUpdateDto bookUpdateDto);

        Task<bool> BookDelete(int bookId);

        Task<List<BookListDto>> GetBooksAuthorId(int authorId);

        Task<bool>BookCreateRange(List<BookCreateDto> bookCreateDto); 

    }
}
