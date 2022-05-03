namespace Gartner.Service.Models
{
    /// <summary>
    /// Captera Model inheriting the Base Product Info Model having properties specific to Capterra Site
    /// </summary>
    public class Capterra : BaseProductInfo
    {
        public string Tags { get; set; }
        public string Name { get; set; }
    }
}
