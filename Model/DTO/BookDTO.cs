namespace Model
{
    public class BookDto
    {
        public long ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; } = "Unavailable";

        public string Language { get; set; }
    }
}
