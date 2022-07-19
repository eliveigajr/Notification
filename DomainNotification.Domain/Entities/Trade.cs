using DomainNotification.Domain.Interfaces;
using System;

namespace DomainNotification.Domain.Entities
{
    public class Trade : Entity, ITrade
    {
        public Guid TradeId { get; private set; }
        public DateTime ReferenceDate { get; private set; }
        public short NumberTrades { get; private set; }
        public double Value { get; private set; }
        public string ClientSector { get; private set; }
        public DateTime NextPaymentDate { get; private set; }
        public bool IsPoliticallyExposed { get; private set; }

        public Trade(Guid tradeId, DateTime referenceDate, short numberTrades, double value, string clientSector, DateTime nextPaymentDate, bool isPoliticallyExposed)
        {
            TradeId = tradeId;
            ReferenceDate = referenceDate;
            NumberTrades = numberTrades;
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
            IsPoliticallyExposed = isPoliticallyExposed;
            Validate();
        }

        public sealed override void Validate()
        {
            IsInvalidGuid(TradeId, InvalidId);
            IsHighRisk(Value, ClientSector, HighRisk);
            IsMediumRisk(Value, ClientSector, MediumRisk);
            IsExpired(ReferenceDate, NextPaymentDate, Expired);
            IsPoliticallyExposedPerson(IsPoliticallyExposed, PEP);
        }
    }
}
