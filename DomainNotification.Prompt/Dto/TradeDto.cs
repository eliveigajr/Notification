using System;

namespace DomainNotification.Prompt.Dto
{
    public class TradeDto
    {
        public TradeDto(Guid tradeId, DateTime referenceDate, short numberTrades, double value, string clientSector, DateTime nextPaymentDate, bool isPoliticallyExposed)
        {
            TradeId = tradeId;
            ReferenceDate = referenceDate;
            NumberTrades = numberTrades;
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
            IsPoliticallyExposed = isPoliticallyExposed;
        }

        public Guid TradeId { get; }
        public DateTime ReferenceDate { get; }
        public short NumberTrades { get; }
        public double Value { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }
        public bool IsPoliticallyExposed { get; }
    }
}
