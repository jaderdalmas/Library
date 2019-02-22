using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class BookDto : IValidatableObject
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [StringLength(1000, MinimumLength = 1)]
        public string Description { get; set; }

        [StringLength(13, MinimumLength = 13)]
        public string ISBN { get; set; } = "Unavailable";

        [StringLength(2, MinimumLength = 2)]
        public string Language { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (ISBN < 1000000000000 || ISBN > 9999999999999) { yield return new ValidationResult($"Invalid {nameof(ISBN)}", new[] { "ISBN" }); }
        }
    }
}
