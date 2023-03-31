using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Application.DTOs.AuthorDtos
{
    public class AuthorUpdateDto : AuthorListDto
    {
        
        public DateTime UpdateDate { get { return DateTime.Now; } }


    }
}
