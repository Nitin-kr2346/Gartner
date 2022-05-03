using System.Collections.Generic;

namespace Gartner.Service.Models
{
    /// <summary>
    /// SoftwareAdvice Model inheriting the Base Product Info Model having properties specific to SoftwareAdvice Site
    /// </summary>
    public class SoftwareAdvice : BaseProductInfo
    {
        public string[] Categories { get; set; }
        public string Title { get; set; }
    }
}
