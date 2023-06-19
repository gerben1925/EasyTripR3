using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EasyTripR3.Interface;
using EasyTripR3.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EasyTripR3.Services
{
    public class UserServices : IUser
    {
        public IConfiguration _configuration;
        public string strConnect { get; set; }
        public UserServices(IConfiguration configuration)
        {
            _configuration = configuration;
            strConnect = _configuration.GetConnectionString("DbConn").ToString();
        }

        public DataSet PostUserReg(UserRegistration user)
        {
            try
            {
                DataSet dsReturn = new DataSet();
                using (SqlConnection sqlconn = new SqlConnection(strConnect))
                {
                    sqlconn.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SPR_POST_INSERTUSER", sqlconn))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@LASTNAME", user.Lastname);
                        sqlCommand.Parameters.AddWithValue("@FIRSTNAME", user.Firstname);
                        sqlCommand.Parameters.AddWithValue("@MIDDLENAME", user.Middlename);
                        sqlCommand.Parameters.AddWithValue("@USERNAME", user.Username);
                        sqlCommand.Parameters.AddWithValue("@PASSWORD", user.Password);
                        sqlCommand.Parameters.AddWithValue("@ROLEID", user.RoleId);
                        sqlCommand.Parameters.AddWithValue("@EMAIL", user.Email);
                        sqlCommand.Parameters.AddWithValue("@CONTACT_NO", user.ContactNo);
                        
                        sqlCommand.Parameters.AddWithValue("@FORCECHANGEPASS", user.ForceChangePassword);
                        sqlCommand.Parameters.AddWithValue("@CREATEDBY", user.CreatedBy);
                        sqlCommand.Parameters.AddWithValue("@DATECREATED", user.DateCreated);
                        sqlCommand.Parameters.AddWithValue("@UPDATEDBY", user.UpdatedBy);
                        sqlCommand.Parameters.AddWithValue("@DATEUPDATED", user.DateUpdated);

                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        adapter.Fill(dsReturn);
                        sqlconn.Close();
                    }
                }
                return dsReturn;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ReturnID> GetUserLogin(UserLogin u_login)
        {
            try
            {
                List<ReturnID> ret = new List<ReturnID>();
                using (SqlConnection sqlconn = new SqlConnection(strConnect))
                {
                    sqlconn.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SPR_GET_USERLOGIN", sqlconn))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@USERNAME", u_login.Username);
                        sqlCommand.Parameters.AddWithValue("@PASSWORD", u_login.Password);
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataSet dsReturn = new DataSet();
                        adapter.Fill(dsReturn);
                        sqlconn.Close();
                        DataTable dtRes = dsReturn.Tables[0];
                        foreach (DataRow odr in dtRes.Rows)
                        {
                            ReturnID a_list = new ReturnID();
                            a_list.Id = int.Parse(odr["ID"].ToString());

                            ret.Add(a_list);
                        }

                    }
                    return ret;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}
