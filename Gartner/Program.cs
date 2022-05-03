using Gartner.Service;
using System;

namespace Gartner
{
    class Program
    {
        /// <summary>
        /// Main Method - Command Line Interactivity
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool endApp = false;

            while (!endApp)
            {
                // Declare variables and set to empty.
                Console.Write("Please enter valid command to Import Products: \n");
                string input = "";

                // Read the command
                input = Console.ReadLine();

                // Split the command using ' ' separator to get Site and path details
                var words = input.Split(new char[] { ' ' });

                // Check for valid command
                while (words == null || words.Length != 3 || words[0] != "import")
                {
                    // If not provided with valid input, prompt error and request the valid input again
                    Console.Write("This is not valid input. Please enter valid command: ");
                    input = Console.ReadLine();
                    words = input.Split(new char[] { ' ' });
                }

                try
                {
                    // Calling the Product Import Service to fetch the Data from given path and Site
                    IProductImportService _productImportService = new ProductImportService();
                    string products = _productImportService.ProcessProduct(siteName: words[1], filePath: words[2]);

                    // Print the Imported Data
                    Console.WriteLine(products);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}
