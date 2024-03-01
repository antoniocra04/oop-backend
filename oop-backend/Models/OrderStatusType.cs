namespace oop_backend.Models
{
    /// <summary>
    /// Статусы заказа.
    /// </summary>
    public enum OrderStatusType
    {
        New,
        Processing,
        Assembly,
        Sent,
        Delivered,
        Returned,
        Abandoned
    }
}
