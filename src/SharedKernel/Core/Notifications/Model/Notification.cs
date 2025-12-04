namespace Core.Notifications.Model
{
    public class Notification(string message)
    {
        public string Message { get; } = message;
    }
}
