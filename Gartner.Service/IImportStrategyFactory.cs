using Gartner.Service.Enums;

namespace Gartner.Service
{
    /// <summary>
    /// Strategy Factory to define which Strategy to use based on the input
    /// </summary>
    public interface IImportStrategyFactory
    {
        /// <summary>
        /// Dynamically fetch Site Strategy based on the passed Site
        /// </summary>
        /// <param name="site"></param>
        /// <returns>IImportStrategy</returns>
        public IImportStrategy GetImportStrategy(Sites site);
    }
}
