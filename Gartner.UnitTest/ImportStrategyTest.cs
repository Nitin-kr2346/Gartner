using Gartner.Service;
using Gartner.Service.ImportStrategies;
using Gartner.Service.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Gartner.UnitTest
{
    [TestFixture]
    public class ImportStrategyTest
    {
        #region Variables
        private IImportStrategy _capterraStrategy;
        private IImportStrategy _softwareAdviceStrategy;
        #endregion

        #region Setup

        /// <summary>
        /// Initializes test.
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            _capterraStrategy = new CapterraStrategy();
            _softwareAdviceStrategy = new SoftwareAdviceStrategy();
        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// Test ProcessImport for CapterraStrategy
        /// </summary>
        [Test]
        public void ProcessImport_CapterraStrategy_Return_Expected()
        {
            var result = _capterraStrategy.ProcessImport("feed-products/capterra.yaml");
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<ProductOutput>>(result);
        }

        /// <summary>
        /// Test ProcessImport for CapterraStrategy Invalid Path
        /// </summary>
        [Test]
        public void ProcessImport_CapterraStrategy_Invalid_Path()
        {
            var result = _capterraStrategy.ProcessImport("feed-products/softwareAdvice.json");
            Assert.IsNull(result);
        }

        /// <summary>
        /// Test ProcessImport for SoftwareAdviceStrategy
        /// </summary>
        [Test]
        public void ProcessImport_SoftwareAdviceStrategy_Return_Expected()
        {
            var result = _softwareAdviceStrategy.ProcessImport("feed-products/softwareAdvice.json");
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<ProductOutput>>(result);
        }

        /// <summary>
        /// Test ProcessImport for SoftwareAdviceStrategy Invalid Path
        /// </summary>
        [Test]
        public void ProcessImport_SoftwareAdviceStrategy_Invalid_Path()
        {
            var result = _softwareAdviceStrategy.ProcessImport("feed-products/capterra.yaml");
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
            _capterraStrategy = null;
            _softwareAdviceStrategy = null;
        }

        #endregion
    }
}
