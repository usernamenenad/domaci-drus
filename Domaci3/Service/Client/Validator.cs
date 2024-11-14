using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Validator
    {
        public static void ValidateFirstAndLastName(ref string FirstName, ref string LastName)
        {
            // Validacija za ime
            Console.WriteLine("------------------------");
            Console.WriteLine("Unesite ime...");
            while (true)
            {
                FirstName = Console.ReadLine();
                if (ValidateString(ref FirstName))
                {
                    break;
                }
            }

            // Validacija za prezime
            Console.WriteLine("------------------------");
            Console.WriteLine("Unesite prezime...");
            while (true) { 
                LastName = Console.ReadLine();
                if (ValidateString(ref LastName))
                {
                    break;
                }
            }
        }

        public static void ValidateIdCardNumber(ref int IdCardNumber)
        {
            // Validacija za Id
            Console.WriteLine("------------------------");
            Console.WriteLine("Unesite broj lične karte...");
            while (true)
            {
                string Str = Console.ReadLine();
                if(ValidateIsInt(Str, ref IdCardNumber))
                {
                    // Pretpostavimo da broj lične karte može samo biti numerički
                    // i između 0 i 10000
                    if(ValidateIsIntInLimits(IdCardNumber, 0, 10000))
                    {
                        break;
                    }
                }
            }
        }

        public static void ValidateFirstAndSecondNumber(ref int FirstNumber, ref int SecondNumber)
        {
            // Validacija za prvi broj
            Console.WriteLine("------------------------");
            Console.WriteLine("Unesite prvi broj...");
            while (true)
            {
                string Str = Console.ReadLine();
                if (ValidateIsInt(Str, ref FirstNumber))
                {
                    if(ValidateIsIntInLimits(FirstNumber, 0, 10))
                    {
                        break;
                    }
                }
            }

            // Validacija za drugi broj
            Console.WriteLine("------------------------");
            Console.WriteLine("Unesite drugi broj...");
            while (true) 
            { 
                string Str = Console.ReadLine();
                if(ValidateIsInt(Str, ref SecondNumber))
                {
                    if (ValidateIsIntInLimits(SecondNumber, 0, 10))
                    {
                        break;
                    }
                }
            }
        }

        public static void ValidateInvestedMoney(ref int InvestedMoney)
        {
            // Validacija za investirani novac
            Console.WriteLine("------------------------");
            Console.WriteLine("Koliko ulažete novca?");
            while (true)
            {
                string Str = Console.ReadLine();    
                if(ValidateIsInt(Str, ref InvestedMoney))
                {
                    if(ValidateIsIntInLimits(InvestedMoney, 0, int.MaxValue))
                    {
                        break;
                    }
                }
            }
        }
        private static bool ValidateString(ref string Str)
        {
            if(Str is null || Str.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1 ili više karaktera potrebno! Pokušajte opet!");
                Console.ResetColor();
                return false;
            }
            return true;
        }

        private static bool ValidateIsInt(string Str, ref int Num)
        {
            if (!int.TryParse(Str, out Num)) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Broj nije validan! Pokušajte opet!");
                Console.ResetColor();
                return false;
            }
            return true;
        }

        private static bool ValidateIsIntInLimits(int Num, int LowerLimit, int UpperLimit)
        {
            if(Num < LowerLimit || Num > UpperLimit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Broj nije u granicama! Pokušajte opet!");
                Console.ResetColor();
                return false;
            }
            return true;
        }
    }
}
