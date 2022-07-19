using DomainNotification.Domain.Interfaces.Alerts;

namespace DomainNotification.Domain.Alerts
{
    public class Critical : ILevel
    {
        public Critical(string description = "Critical")
        {
            Description = description;
        }

        public string Description { get; }

        public override string ToString()
        {
            return Description;
        }
    }
}