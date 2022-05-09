using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public static class MD5encrypt
    {
        public static string MD5Pass(string text)
        {
            MD5CryptoServiceProvider xx = new MD5CryptoServiceProvider();
            xx.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = xx.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
