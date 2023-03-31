using MVCOnion.Application.DTOs.AuthorDtos;

namespace MVCOnion.Presentation.ViewModels.AuthorVms
{
    public class AuthorListVm
    {
        public AuthorListVm(AuthorListDto authorListDto)
        {
            AuthorId = authorListDto.Id;
            AuthorFirstName = authorListDto.FirstName;
            AuthorLastName = authorListDto.LastName;
        }

        public int AuthorId { get; set; }

        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
