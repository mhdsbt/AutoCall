namespace Domain.Enum.AutoCallRequest
{
    public enum AutoCallRequestStatus : byte
    {
        Inserted = 0,
        Queued = 1,
        Consumed = 2,
        Dispatched = 3,
        WatingForStatus = 4,
        Success = 5,
        UserWasBusy = 6,
        UserWasNotReachable = 7
    }

}
