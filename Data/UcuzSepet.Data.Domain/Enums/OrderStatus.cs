using System.ComponentModel;

namespace UcuzSepet.Data.Domain.Enums {

    /// <summary>
    /// Order Statues for Customer Information
    /// </summary>
    public enum OrderStatus : byte {
        [Description("Waiting for Approvement")]
        WaitingForApprovement = 0,

        [Description("Preparing")]
        Preparing = 1,

        [Description("On Delivery")]
        OnDelivery = 2,

        [Description("Completed")]
        Completed = 3,

        [Description("Rejected")]
        Rejected = 11,
    }
}
