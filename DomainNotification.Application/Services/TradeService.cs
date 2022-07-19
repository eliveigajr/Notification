using DomainNotification.Domain.Commands;
using DomainNotification.Domain.Entities;
using System;

namespace DomainNotification.Application.Services
{
    public class TradeService : Service
    {
        private readonly Trade _entity;

        public TradeService(Guid tradeId, DateTime referenceDate, short numberTrades, double value, string clientSector, DateTime nextPaymentDate, bool isPoliticallyExposed)
        {
            _entity = new Trade(tradeId, referenceDate, numberTrades, value, clientSector, nextPaymentDate, isPoliticallyExposed);
            NotificationEntity = _entity;
        }

        public void SaveTrade(Guid tradeId, DateTime referenceDate, short numberTrades, double value, string clientSector, DateTime nextPaymentDate, bool isPoliticallyExposed)
        {
            var cmd = new SaveTrade(_entity);
            cmd.Run();
        }
    }
}