namespace Model
{
    public class ResultEntity
    {
        public long Result { get; set; }
        public string ErrorMessage { get; set; }

        public bool IsSuccess { get { return ErrorMessage.Equals("Success"); } }
    }
}
