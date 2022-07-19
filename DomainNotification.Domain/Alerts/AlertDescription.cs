using DomainNotification.Domain.Interfaces.Alerts;
using DomainNotification.Domain.Notifications;

namespace DomainNotification.Domain.Alerts
{
    public class AlertDescription : Description
    {
        public ILevel Level { get; }

        public AlertDescription(string message, ILevel level, params string[] args)
            : base(message, args)
        {
            Level = level;
        }
    }
}