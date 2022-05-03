using Gartner.Service.Enums;
using Gartner.Service.ImportStrategies;

namespace Gartner.Service
{
    public class ImportStrategyFactory : IImportStrategyFactory
    {
        /// <summary>
        /// Dynamically fetch Site Strategy based on the passed Site
        /// </summary>
        /// <param name="site"></param>
        /// <returns>IImportStrategy</returns>
        public IImportStrategy GetImportStrategy(Sites site)
        {
            // Return the Site Strategy based on the pased Site 
            return site switch
            {
                Sites.capterra => new CapterraStrategy(),
                Sites.softwareadvice => new SoftwareAdviceStrategy(),
                Sites.unknown => null,
                _ => null,
            };
        }
    }
}
