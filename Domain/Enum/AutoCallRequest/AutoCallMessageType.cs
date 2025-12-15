namespace Domain.Enum.AutoCallRequest
{
    public enum AutoCallMessageType : byte
    {
        CheckNotAckedOrders = 0,
        CheckDelayedOrders = 1,
        OpenApplication = 2,
        LackOfService = 3,
        OrderNFCCancel = 4,
        OrderNFCReminder = 5

    }

}
