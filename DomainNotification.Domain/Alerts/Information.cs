using DomainNotification.Domain.Interfaces.Alerts;

namespace DomainNotification.Domain.Alerts
{
    public class Information : ILevel
    {
        public Information(string description = "Information")
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