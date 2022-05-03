using Gartner.Service.Models;
using Gartner.Service.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace Gartner.Service.ImportStrategies
{
    public class SoftwareAdviceStrategy : IImportStrategy
    {
        /// <summary>
        /// Method to fetch and process the data from SoftwareAdvice Site
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>List of ProductOutput</returns>
        public List<ProductOutput> ProcessImport(string filePath)
        {
            List<ProductOutput> result = new List<ProductOutput>();

            // Newtonsoft.Json Utility used to manipulate the JSON file in the given path
            using (StreamReader file = new StreamReader(filePath))
            {
                try
                {
                    // Reading the JSON file 
                    string json = file.ReadToEnd();

                    // Instantiating the SerializerSettings to Deserialize Object 
                    var serializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    };

                    // Deserializing the JSON into the SoftwareAdvice Collection
                    SoftwareAdviceCollection products = JsonConvert.DeserializeObject<SoftwareAdviceCollection>(json, serializerSettings);

                    // Check if the data is available
                    if (products != null)
                    {
                        // Convert and Assigning the SoftwareAdviceCollection type data to the List of ProductOutput
                        result = Mapper.SoftwareAdviceOuptutConversion(products);
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
}
