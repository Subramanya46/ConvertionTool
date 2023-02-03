using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Hashing
{
    internal class Program
    {
        static void Main(string[] args)
        {
          string a= QuickHash_SHA256("Subramanya");
            /*Hashing Values using Defferent Hashing Algorithms using SQL'*/
            //declare @Values varchar(100) = 'This Message is Hashed Values'
            //select LEN(HASHBYTES('MD2 ',@Values)),HASHBYTES('SHA  ', @Values)
            //select LEN(HASHBYTES('MD4 ',@Values)),HASHBYTES('SHA  ', @Values)
            //select LEN(HASHBYTES('MD5 ',@Values)),HASHBYTES('SHA  ', @Values)
            //select LEN(HASHBYTES('SHA ',@Values)),HASHBYTES('SHA  ', @Values)
            //select LEN(HASHBYTES('SHA1',@Values)),HASHBYTES('SHA  ', @Values)
            //select LEN(HASHBYTES('SHA2 ',@Values)),HASHBYTES('SHA ', @Values)
            //select LEN(HASHBYTES('SHA2_256 ',@Values)),HASHBYTES('SHA ', @Values)
            //select LEN(HASHBYTES('SHA2_512 ',@Values)),HASHBYTES('SHA ', @Values)
           /* SHA256 uses UTF8 Encoding, while in your example you used Unicode Encoding. They are two different encodings, so you don't get the same result.*/
        }
        public static string QuickHash_SHA256(string secret)
        {
            using (var sha256 = SHA256.Create())
            {
                var secretBytes = Encoding.UTF8.GetBytes(secret);
                var secretHash = sha256.ComputeHash(secretBytes);
                string str = Encoding.Default.GetString(secretHash);
                return str;
            }
        } public static string QuickHash_SHA1(string secret)
        {
            using (var sha256 = SHA1.Create())
            {
                var secretBytes = Encoding.UTF8.GetBytes(secret);
                var secretHash = sha256.ComputeHash(secretBytes);
                string str = Encoding.Default.GetString(secretHash);
                return str;
            }
        }

    }
}
