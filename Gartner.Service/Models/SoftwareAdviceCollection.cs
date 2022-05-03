using System.Collections.Generic;

namespace Gartner.Service.Models
{
    /// <summary>
    /// Collection of SoftwareAdvice Model to correspond the structure which Site shared in the JSON file
    /// </summary>
    public class SoftwareAdviceCollection
    {
        public List<SoftwareAdvice> Products { get; set; }
    }
}
