using Gartner.Service.Models;
using Gartner.Service.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization.NamingConventions;

namespace Gartner.Service.ImportStrategies
{
    public class CapterraStrategy : IImportStrategy
    {
        /// <summary>
        /// Method to fetch and process the data from Capterra Site
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>List of ProductOutput</returns>
        public List<ProductOutput> ProcessImport(string filePath)
        {
            List<ProductOutput> result = new List<ProductOutput>();
            try
            {
                // Instantiating the deserializer to fetch the YAML Data from file
                // YamlDotNet Utility used to manipulate the YAML file in the given path
                var deserializer = new YamlDotNet.
                                       Serialization.
                                       DeserializerBuilder().
                                       WithNamingConvention(CamelCaseNamingConvention.Instance).
                                       Build();

                // Retrieving the data from the File at the shared path and deserializing into List of Capterra Model
                List<Capterra> products = deserializer.
                                          Deserialize<List<Capterra>>
                                          (File.ReadAllText(filePath));

                // Check if the data is available
                if (products != null)
                {
                    // Convert and Assigning the List of Capterra type data to the List of ProductOutput
                    result = Mapper.CapterraOuptutConversion(products);
                }

                // Return List of ProductOutput
                return result;
            }
            catch (Exception ex)
            {
                // Displaying the Error on console 
                Console.WriteLine("Problem reading file. Detailed Error: " + ex.Message);
                return null;
            }
        }
    }
}
