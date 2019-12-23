using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QinGy.MarketPlatform.OrderApi.Model
{
   /// <summary>
   /// 
   /// 
   /// </summary>
    public class OrderInfo
    {
        public Guid Id { get; set; }
        public string OrderCode { get; set; }
        public string MarketOrderCode { get; set; }
        public string BuyerName { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }

    public class OrderDetail
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public string ItemCode { get; set; }

    }
    public class OrderSku
    {

    }
    public enum OrderStatus
    {
        Pending,
        Paid,
        PartialShipped,
        Shipped,
        Cancel,
        Refund,
        Return,
        Completed
    }
}
