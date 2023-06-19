using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyTripR3.Model
{
    public class Md5Hash
    {

        public string ComputeMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
