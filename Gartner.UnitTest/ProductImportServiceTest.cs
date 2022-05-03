using Gartner.Service;
using NUnit.Framework;
using System.Linq;

namespace Gartner.UnitTest
{
    [TestFixture]
    public class ProductImportServiceTest
    {
        #region Variables
        private IProductImportService _productImportService;
        #endregion

        #region Setup

        /// <summary>
        /// Initializes test.
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            _productImportService = new ProductImportService();
        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// Test empty inputs
        /// </summary>
        [Test]
        public void ProcessProduct_EmptySiteNameAndPath_Test()
        {
            var result = _productImportService.ProcessProduct(null, null);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Any(), false);
        }

        /// <summary>
        /// Test empty path
        /// </summary>
        [Test]
        public void ProcessProduct_EmptyPath_Test()
        {
            var result = _productImportService.ProcessProduct("Capterra", null);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Any(), false);
        }

        /// <summary>
        /// Test empty SiteName
        /// </summary>
        [Test]
        public void ProcessProduct_EmptySiteName_Test()
        {
            var result = _productImportService.ProcessProduct(null, "feed-products/capterra.yaml");
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Any(), false);
        }

        /// <summary>
        /// Valid Capterra inputs
        /// </summary>
        [Test]
        public void ProcessProduct_ValidCapterraInput_Test()
        {
            var result = _productImportService.ProcessProduct("Capterra", "feed-products/capterra.yaml");
            Assert.IsNotNull(result);
            string capterraResponse = "importing: Name: GitGHub;  Categories: Bugs & Issue Tracking,Development Tools; Twitter: github\r\n" +
                "importing: Name: Slack;  Categories: Instant Messaging & Chat,Web Collaboration,Productivity; Twitter: slackhq\r\n" +
                "importing: Name: JIRA Software;  Categories: Project Management,Project Collaboration,Development Tools; Twitter: jira\r\n";
            Assert.AreEqual(result.ToString(), capterraResponse);
        }

        /// <summary>
        /// Valid SoftwareAdvice inputs
        /// </summary>
        [Test]
        public void ProcessProduct_ValidSoftwareAdviceInput_Test()
        {
            var result = _productImportService.ProcessProduct("SoftwareAdvice", "feed-products/softwareadvice.json");
            Assert.IsNotNull(result);
            string softwareAdviceResponse = "importing: Name: Freshdesk;  Categories: Customer Service, Call Center; Twitter: @freshdesk\r\n" +
                "importing: Name: Zoho;  Categories: CRM, Sales Management; Twitter: \r\n";
            Assert.AreEqual(result.ToString(), softwareAdviceResponse);
        }

        #endregion 

        #region TearDown

        /// <summary>
        /// Dispose test.
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            _productImportService = null;
        }

        #endregion
    }
}
