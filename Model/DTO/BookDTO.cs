namespace Model
{
    public class BookDto
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; } = "Unavailable";

        public string Language { get; set; }
    }
}
