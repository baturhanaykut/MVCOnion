using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Application.DTOs.AuthorDtos
{
    public class AuthorCreateDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreateDate => DateTime.Now;

        public bool IsActive => true;
    }
}
