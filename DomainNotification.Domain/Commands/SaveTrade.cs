using DomainNotification.Domain.Entities;
using DomainNotification.Domain.Alerts;

namespace DomainNotification.Domain.Commands
{
    public class SaveTrade : Command
    {
        private readonly Trade _trade;

        public SaveTrade(Trade trade) : base(trade)
        {
            _trade = trade;
            var description = new AlertDescription("\nRegistration contains risks.", new Information());
            _trade.Alerts.Add(description);
        }

        public void Run()
        {
            if (!Alerts.HasAlerts)
            {
                SaveTradeInBackendSystems();
            }
        }

        private void SaveTradeInBackendSystems()
        {
            var message = new AlertDescription("\nRegistration contains no risks.", new Information());
            _trade.Alerts.Add(message);
        }
    }
}