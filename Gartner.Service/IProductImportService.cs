namespace Gartner.Service
{
    /// <summary>
    /// Product processing Service
    /// </summary>
    public interface IProductImportService
    {
        /// <summary>
        /// Method to process/transform/retrieve data
        /// </summary>
        /// <param name="siteName"></param>
        /// <param name="filePath"></param>
        /// <returns>Data in string format</returns>
        public string ProcessProduct(string siteName, string filePath);
    }
}
