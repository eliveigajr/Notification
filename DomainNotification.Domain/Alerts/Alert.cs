using System.Collections.Generic;
using System.Linq;
using DomainNotification.Domain.Notifications;

namespace DomainNotification.Domain.Alerts
{
    public class Alert : Notification
    {
        public IList<AlertDescription> Alerts => List.Cast<AlertDescription>().Where(x => x.Level is Critical).ToList();
        public IList<AlertDescription> Informations => List.Cast<AlertDescription>().Where(x => x.Level is Information).ToList();
        public bool HasAlerts => List.Cast<AlertDescription>().Any(x => x.Level is Critical);
        public bool HasInformations => List.Cast<AlertDescription>().Any(x => x.Level is Information);
    }
}