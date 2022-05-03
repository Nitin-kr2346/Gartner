using Gartner.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace Gartner.Service.Utilities
{
    /// <summary>
    /// Mapper Static class for conversion of fetched data into common model
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Convert the SoftwareAdvice Model to common List of ProductOutput
        /// </summary>
        /// <param name="softwareAdviceCollection"></param>
        /// <returns>List of ProductOutput</returns>
        public static List<ProductOutput> SoftwareAdviceOuptutConversion(SoftwareAdviceCollection softwareAdviceCollection)
        {
            List<ProductOutput> products = new List<ProductOutput>();

            // Check for Valid parameter/data
            if (softwareAdviceCollection != null && softwareAdviceCollection.Products.Any())
            {
                // Traverse the data to convert to desired output
                foreach (var product in softwareAdviceCollection?.Products)
                {
                    // Adding the SoftwareAdvice Site data to the Response Model
                    products.Add(new ProductOutput
                    {
                        Name = product.Title,
                        Twitter = product.Twitter,
                        // Joining Multiple Categories from SoftwareAdvice Site data into desired single string Category Field
                        Categories = string.Join(", ", product.Categories)
                    });
                }
            }

            // Return the formed List of ProductOutput data 
            return products;
        }

        /// <summary>
        /// Convert the Capterra Model to common List of ProductOutput
        /// </summary>
        /// <param name="capterraCollection"></param>
        /// <returns>List of ProductOutput</returns>
        public static List<ProductOutput> CapterraOuptutConversion(List<Capterra> capterraCollection)
        {
            List<ProductOutput> products = new List<ProductOutput>();

            // Check for Valid parameter/data
            if (capterraCollection != null && capterraCollection.Any())
            {
                // Traverse the data to convert to desired output
                foreach (var product in capterraCollection)
                {
                    // Adding the Capterra Site data to the Response Model
                    products.Add(new ProductOutput
                    {
                        Name = product.Name,
                        Twitter = product.Twitter,
                        Categories = product.Tags
                    });
                }
            }

            // Return the formed List of ProductOutput data 
            return products;
        }
    }
}
