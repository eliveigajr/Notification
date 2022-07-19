namespace DomainNotification.Domain.Interfaces.Alerts
{
    public interface ILevel
    {
        string Description { get; }

        string ToString();
    }
}
