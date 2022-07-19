using System.Collections;
using DomainNotification.Domain.Entities;

namespace DomainNotification.Application.Services
{
    public abstract class Service
    {
        protected Entity NotificationEntity;

        public bool HasNotifications => NotificationEntity != null && NotificationEntity.Alerts.HasNotifications;
        public bool HasAlerts => NotificationEntity != null && NotificationEntity.Alerts.HasAlerts;
        public bool HasInformations => NotificationEntity != null && NotificationEntity.Alerts.HasInformations;

        public IEnumerable Alerts()
        {
            return NotificationEntity?.Alerts.Alerts;
        }

        public IEnumerable Informations()
        {
            return NotificationEntity?.Alerts.Informations;
        }
    }
}