using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppCSharpCallingAPIDemo1.BusinessLogic;
using ConsoleAppCSharpCallingAPIDemo1.Models;

namespace ConsoleAppCSharpCallingAPIDemo1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Initialize our http client to get ready for our API call
            ApiHelper.InitializeClient();

            Console.WriteLine("Please enter a string to search for TV shows containing that string.");
            string searchText = Console.ReadLine();

            TvShowBL tvShowBL = new TvShowBL();
            List<TvShowModel> tvShowInformation = await tvShowBL.LoadTvShowInfo(searchText);

            //We'll get a list back, so loop through and show the items
            foreach(TvShowModel show in tvShowInformation)
            {
                Console.WriteLine("**********************************************");
                try
                {
                    Console.WriteLine($"Show Name: {show.show.name}");
                    Console.WriteLine($"Network: {show.show.network.name}");
                    Console.WriteLine($"Show Language: {show.show.language}");
                }
                catch (Exception)
                {
                    Console.WriteLine("** Invalid data encountered for Show. **");
                }
               
                Console.WriteLine("**********************************************");
            }

            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }        
    }
}
