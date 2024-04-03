namespace Model.Enum
{
    public class Enums
    {

    }

    public enum EnumRStatus
    {
        Active = 1,
        Deleted = 2
    }

    public enum OrderStatus
    {
        Ordered = 1,
        Packaging = 2,
        HandOvered = 3,
        Delivered = 4
    }

    public enum PaymentType
    {
        CashOnDelivery = 1,
        Bkash = 2
    }
    public enum PaymentStatus
    {
        Due = 1,
        Receive = 2
    }
}
