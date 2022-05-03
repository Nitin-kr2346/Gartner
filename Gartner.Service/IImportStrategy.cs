using Gartner.Service.Models;
using System.Collections.Generic;

namespace Gartner.Service
{
    /// <summary>
    /// Common Strategy for multiple Sites, This Interface to be inherit to implement new site
    /// </summary>
    public interface IImportStrategy
    {
        /// <summary>
        /// This method to be defined whenever a site is added, Method to fetch and process the data
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>List of ProductOutput</returns>
        public List<ProductOutput> ProcessImport(string filePath);
    }
}
