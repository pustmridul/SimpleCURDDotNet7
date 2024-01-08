using System.ComponentModel.DataAnnotations;

namespace SimpleCURDDotNet7.Data
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string CreateByName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateByName { get; set; }
    }
}
