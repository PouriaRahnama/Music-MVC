using System.ComponentModel.DataAnnotations;

namespace Music.Data
{
    public abstract class baseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
