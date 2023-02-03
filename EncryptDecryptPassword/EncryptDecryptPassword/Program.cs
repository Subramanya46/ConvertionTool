using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecuLib; //Reference SecuLib DLL
using System.Security.Cryptography;

namespace EncryptDecryptPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes("addsfsf"));
            EncDec objCrypt = new EncDec();//Creating Instance of SecuLib Class
            string EncriptMessage, DecryptMessage, Message;
            Console.WriteLine("Enter Text to Encrypt");
            Message = Console.ReadLine();
            EncriptMessage = objCrypt.EncryptMessage(Message, "Subbu");
            Console.WriteLine("Encrypted Message is {0}", EncriptMessage);
            DecryptMessage = objCrypt.DecryptMessage(EncriptMessage, "Subbu");
            Console.WriteLine("Decrypted Message is {0}", DecryptMessage);
            Console.ReadLine();

           
           


        }
    }
}
