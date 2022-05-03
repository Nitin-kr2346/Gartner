using Gartner.Service.Models;
using System.Collections.Generic;

namespace Gartner.Service
{
    /// <summary>
    /// Interface to inherit while introducing new/different RDBMS
    /// </summary>
    public interface IProductDatabase
    {
        /// <summary>
        /// Method to Save the Entity, This method to be implemented when a new/different RDBMS will be introduced
        /// </summary>
        /// <param name="products"></param>
        /// <returns>true/false</returns>
        public bool Save(List<ProductOutput> products);
    }
}
