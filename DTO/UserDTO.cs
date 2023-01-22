using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class UserDTO
    {

        public int Userid { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
   
       
        public string? Nameuser { get; set; }
        [MaxLength(30)]
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
