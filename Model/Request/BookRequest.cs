using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class BookRequest : IValidatableObject
    {
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
            if (!long.TryParse(ISBN, out long intISBN)) { yield return new ValidationResult($"Invalid {nameof(ISBN)} not numeric", new[] { "ISBN" }); }
        }

        public BookDto GetBookDTO()
        {
            return new BookDto()
            {
                Title = Title,
                Description = Description,
                ISBN = ISBN,
                Language = Language
            };
        }
    }
}
