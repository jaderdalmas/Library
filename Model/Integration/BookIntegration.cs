using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class BookIntegration
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public string ISBN { get; set; }

        public string URL { get; set; }
    }
}
