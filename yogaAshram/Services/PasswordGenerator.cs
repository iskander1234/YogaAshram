using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Services
{
    public class PasswordGenerator
    {
        private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string Generate(int size = 8)
        {
            Random rndm = new Random();
            string psw = "";
            for (int i = 0; i < size; i++)
            {
                if (rndm.Next(3) == 0)
                {
                    psw += rndm.Next(10);
                }
                else
                {
                    if (rndm.Next(2) == 0)
                    {
                        psw += letters[rndm.Next(letters.Length)].ToString().ToLower();
                    }
                    else
                    {
                        psw += letters[rndm.Next(letters.Length)];
                    }
                }
            }
            return psw;
        }
        
    }
}
