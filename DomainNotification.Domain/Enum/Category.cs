using System.ComponentModel;

namespace DomainNotification.Domain.Enum
{
    public enum Category
    {
        [Description("EXPIRED")]
        Expired = 1,

        [Description("HIGHRISK")]
        HighRisk = 2,

        [Description("MEDIUMRISK")]
        MediumRisk = 3,

        [Description("Politically Exposed Person")]
        PEP = 4
    }
}
