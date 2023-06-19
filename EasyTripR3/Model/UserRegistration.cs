using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTripR3.Model
{
    public class UserRegistration
    {
        [Required]
        [StringLength(32)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(32)]
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        [Required]
        [StringLength(200)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int RoleId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ContactNo { get; set; }

        [Required]
        public int ForceChangePassword { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public string DateCreated { get; set; }
        public int UpdatedBy { get; set; }
        public string DateUpdated { get; set; }
    }
}
