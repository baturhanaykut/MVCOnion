using MVCOnion.Application.DTOs.AuthorDtos;
using MVCOnion.Application.DTOs.BookDtos;

namespace MVCOnion.Presentation.ViewModels.AuthorVms
{
    public class AuthorDetailVm
    {
        public AuthorDetailVm(AuthorCreateDto authorCreateDto, List<BookListDto> bookList)
        {
            AuthorName = authorCreateDto.FirstName;
            AuthorLastName = authorCreateDto.LastName;
            BookList = bookList;
        }

        public string AuthorName { get; set; }

        public string AuthorLastName { get; set; }

        public List<BookListDto> BookList { get; set; }
    }
}
