namespace Model.Pattern
{
    public class Notification
    {
        public Notification(string text, ENotification level = ENotification.Information)
        {
            Text = text;
            Level = level;
        }

        public string Text { get; private set; }
        public ENotification Level { get; private set; }
    }
}
