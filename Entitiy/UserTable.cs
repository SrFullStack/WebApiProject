using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace Entitiy
{
    public partial class UserTable
    {
        public UserTable()
        {
            Orders = new HashSet<Order>();
        }

        public int Userid { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Nameuser { get; set; }
        [Required]
        
        public int? Password { get; set; }
        [MaxLength(30)]
        public string? Firstname { get; set; }
        [MaxLength(30)]
        public string? Lastname { get; set; }
       
        public virtual ICollection<Order> Orders { get; set; }
    }
}
