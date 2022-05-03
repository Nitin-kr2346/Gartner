using Gartner.Service;
using Gartner.Service.Enums;
using Gartner.Service.ImportStrategies;
using NUnit.Framework;

namespace Gartner.UnitTest
{
    [TestFixture]
    public class ImportStrategyFactoryTest
    {
        #region Private Variables
        private IImportStrategyFactory _importStategyFactory;
        #endregion Private Variables

        #region Setup
        /// <summary>
        /// Initializes test.
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            _importStategyFactory = new ImportStrategyFactory();
        }
        #endregion

        #region Unit Tests

        /// <summary>
        /// Test GetImportStrategy for CapterraStrategy
        /// </summary>
        [Test]
        public void GetImportStrategy_CapterraStrategy_Return_Expected()
        {
            var result = _importStategyFactory.GetImportStrategy(Sites.capterra);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CapterraStrategy>(result);
        }

        /// <summary>
        /// Test GetImportStrategy for SoftwareAdviceStrategy
        /// </summary>
        [Test]
        public void GetImportStrategy_SoftwareAdviceStrategy_Return_Expected()
        {
            var result = _importStategyFactory.GetImportStrategy(Sites.softwareadvice);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<SoftwareAdviceStrategy>(result);
        }

        /// <summary>
        /// Test GetImportStrategy for unknown type 
        /// </summary>
        [Test]
        public void GetImportStrategy_Null_Expected()
        {
            var result = _importStategyFactory.GetImportStrategy(Sites.unknown);
            Assert.IsNull(result);
        }

        #endregion

        #region TearDown

        /// <summary>
        /// Dispose test.
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            _importStategyFactory = null;
        }

        #endregion
    }
}
