using Gartner.Service.Enums;
using Gartner.Service.Models;
using Gartner.Service.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gartner.Service
{
    /// <summary>
    /// Product Import Service used to import the Site data
    /// </summary>
    public class ProductImportService : IProductImportService
    {
        #region Private Variables
        private IImportStrategyFactory _importStategyFactory;
        private IProductDatabase _productDatabase;
        #endregion Private Variables


        #region Constructors
        public ProductImportService()
        {
            _importStategyFactory = new ImportStrategyFactory();
            _productDatabase = new MySQLDatabase();
        }
        #endregion Constructors

        /// <summary>
        /// Method to process/transform/retrieve data
        /// </summary>
        /// <param name="siteName"></param>
        /// <param name="filePath"></param>
        /// <returns>Data in string format</returns>
        public string ProcessProduct(string siteName, string filePath)
        {
            List<ProductOutput> productOutput = new List<ProductOutput>();

            // This check is used to enable/disable save
            bool isSaveEnabled = false;

            // Check for Valid Site name and File path
            if (!string.IsNullOrWhiteSpace(siteName) && !string.IsNullOrWhiteSpace(filePath))
            {
                // Enum Utility used to fetch the Enum for the shared string Site Name
                Sites site = EnumUtility.GetEnum<Sites>(siteName.ToLower());

                // Define the Site Strategy to be used based on the Site 
                IImportStrategy importStrategy = _importStategyFactory.GetImportStrategy(site);

                // Check for Valid Site Strategy
                if (importStrategy != null)
                {
                    // Using the strategy import/process data from the file given in the file path
                    productOutput = importStrategy.ProcessImport(filePath);
                }

                // Check for Save Enable
                if (isSaveEnabled)
                {
                    // This will save the List of Entity, once DB Implementation
                    _productDatabase.Save(productOutput);
                }
            }

            // Convert the data into string and return to Main
            return ProcessProductImport(productOutput);
        }

        /// <summary>
        /// Convert the data into string to display on the Console
        /// </summary>
        /// <param name="productOutput"></param>
        /// <returns>Converted string from Data</returns>
        private string ProcessProductImport(List<ProductOutput> productOutput)
        {
            StringBuilder output = new StringBuilder();

            // Traversing the Product Output List to form desired String
            foreach (var product in productOutput)
            {
                // Appending the product data in the String Builder
                output.AppendLine("importing: Name: " + product.Name + ";  Categories: " + product.Categories + "; Twitter: " + product.Twitter);
            }

            //Returns the converted string
            return output.ToString();
        }
    }
}
