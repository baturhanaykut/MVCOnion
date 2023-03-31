using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Application.DTOs.BookDtos
{
    public class BookCreateDto
    {
        public string BookName { get; set; }

        public DateTime CreatedDate => DateTime.Now;

        public bool IsActive => true;


        public int AuthorId { get; set; }
    }
}
