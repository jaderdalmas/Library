using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class BookDTO
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [StringLength(1000, MinimumLength = 1)]
        public string Description { get; set; }

        public long ISBN { get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string Language { get; set; }
    }
}
