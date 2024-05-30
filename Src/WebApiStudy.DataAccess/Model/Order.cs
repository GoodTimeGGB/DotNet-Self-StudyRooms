using Abp.Domain.Entities;
using Abp.Events.Bus;

namespace WebApiStudy.DataAccess.Model
{
    public class Order : AggregateRoot // 聚合根
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 订单明细
        /// </summary>
        public List<OrderItem> OrderItems { get; set; }
    }

    /// <summary>
    /// 订单明细DTO
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
    }
}
