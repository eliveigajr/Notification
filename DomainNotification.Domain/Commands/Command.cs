using DomainNotification.Domain.Entities;
using DomainNotification.Domain.Alerts;

namespace DomainNotification.Domain.Commands
{
    public abstract class Command
    {
        protected Command(Entity entity)
        {
            Entity = entity;
        }

        protected Entity Entity;
        protected Alert Alerts => Entity.Alerts;
    }
}