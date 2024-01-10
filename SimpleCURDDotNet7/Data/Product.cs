namespace SimpleCURDDotNet7.Data
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string? ProductDesc { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
