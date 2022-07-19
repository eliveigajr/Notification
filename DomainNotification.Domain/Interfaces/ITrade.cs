using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainNotification.Domain.Interfaces
{
    internal interface ITrade
    {
        Guid TradeId { get; }
        DateTime ReferenceDate { get; }
        short NumberTrades { get; }
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
        bool IsPoliticallyExposed { get; }
    }
}
