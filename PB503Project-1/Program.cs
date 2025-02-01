using PB503Project_1.Models;
using PB503Project_1.Services.Implementation;
using PB503Project_1.Services.Interface;
using System.Net.Http.Headers;

namespace PB503Project_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Menu = true;

            do
            {

                Console.WriteLine(@"1. Author actions.
2. Book Actions.");

                string inputMenu = Console.ReadLine();

                switch (inputMenu)
                {
                    case "0":
                        Menu = false;
                        break;
                        case "1":
                        Console.WriteLine("Author menu");

                        break;



                }



            } while (Menu);




        }
    }
}
