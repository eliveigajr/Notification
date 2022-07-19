using DomainNotification.Domain.Enum;
using DomainNotification.Domain.Alerts;
using System;
using System.Threading.Tasks;

namespace DomainNotification.Domain.Entities
{
    public class Entity
    {
        public Alert Alerts { get; } = new Alert();

        public virtual void Validate() { }

        protected void Fail(bool condition, AlertDescription description)
        {
            if (condition)
                Alerts.Add(description);
        }

        public bool IsValid() => !Alerts.HasAlerts;

        #region Validations

        protected void IsInvalidGuid(Guid guid, AlertDescription alert)
        {
            Fail(guid == Guid.Empty, alert);
        }

        protected void IsHighRisk(double value, string clientSector, AlertDescription alert)
        {
            Fail(value > 1000000 && clientSector == Enumerators.GetDescription(Sector.Private), alert);
        }
        protected void IsMediumRisk(double value, string clientSector, AlertDescription alert)
        {
            Fail(value > 1000000 && clientSector == Enumerators.GetDescription(Sector.Public), alert);
        }
        protected void IsExpired(DateTime referenceDate, DateTime nextPaymentDate, AlertDescription alert)
        {
            Fail(referenceDate.AddDays(30) > nextPaymentDate, alert);
        }
        protected void IsPoliticallyExposedPerson(bool isPoliticallyExposed, AlertDescription alert)
        {
            Fail(isPoliticallyExposed, alert);
        }

        #endregion

        #region Alerts

        public static AlertDescription InvalidId = new AlertDescription("Invalid Id", new Critical());
        public static AlertDescription HighRisk = new AlertDescription(Enumerators.GetDescription(Category.HighRisk), new Critical());
        public static AlertDescription MediumRisk = new AlertDescription(Enumerators.GetDescription(Category.MediumRisk), new Critical());
        public static AlertDescription Expired = new AlertDescription(Enumerators.GetDescription(Category.Expired), new Critical());
        public static AlertDescription PEP = new AlertDescription(Enumerators.GetDescription(Category.PEP), new Critical());

        #endregion
    }
}