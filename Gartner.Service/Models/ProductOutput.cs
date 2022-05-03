namespace Gartner.Service.Models
{
    /// <summary>
    /// Response Model/possibly the Entity which could be saved in the DB
    /// </summary>
    public class ProductOutput
    {
        public string Categories { get; set; }
        public string Name { get; set; }
        public string Twitter { get; set; }
    }
}
