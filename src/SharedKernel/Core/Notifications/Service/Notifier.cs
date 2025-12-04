using Core.Notifications.Interfaces;
using Core.Notifications.Model;

namespace Core.Notifications.Service
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;
        public Notifier()
        {
            _notifications = new List<Notification>();
        }
        public List<Notification> GetNotifications()
        {
           return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}
