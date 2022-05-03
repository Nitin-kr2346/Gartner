using Gartner.Service.Models;
using System;
using System.Collections.Generic;

namespace Gartner.Service
{
    /// <summary>
    /// My SQL Db Class inheriting Product database interface
    /// </summary>
    public class MySQLDatabase : IProductDatabase
    {
        /// <summary>
        /// Dummy implementation of MySQL DB, to give an insight about implementing different RDBMS
        /// </summary>
        /// <param name="products"></param>
        /// <returns>bool</returns>
        public bool Save(List<ProductOutput> products)
        {
            throw new NotImplementedException();
        }
    }
}
