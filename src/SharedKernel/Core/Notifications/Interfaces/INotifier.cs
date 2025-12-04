using Core.Notifications.Model;

namespace Core.Notifications.Interfaces
{
    public interface INotifier
    {
        bool HasNotifications();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
