using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTripR3.Model
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public int ContactNo { get; set; }
        public string ForceChangePassword { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public string DateUpdated { get; set; }
    }
}
