namespace WISSEN.EDA.Data
{
    public class Enums
    {
        public enum AppCode
        {
            EA,
            DA,
            ALL
        }

        public enum CustomerStatus
        {
            Approved,
            Completed,
            Draft,
            InProgress,
            Rejected,
            Submitted
        }

        public enum AddressType
        {
            BillTo,
            Bank,
            Broker,
            Company,
            Document,
            NotifyParty,
            ShipTo,
            User
        }
    }
}
