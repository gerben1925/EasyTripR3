using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EasyTripR3.Model;
using EasyTripR3.Services;

namespace EasyTripR3.Interface
{
    public interface IUser
    {
        public DataSet PostUserReg(UserRegistration user);
        public List<ReturnID> GetUserLogin(UserLogin u_login);
    }
}
