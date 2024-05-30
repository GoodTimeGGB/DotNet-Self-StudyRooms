using Abp.Domain.Entities;

namespace WebApiStudy.Dtos.Order
{
    /// <summary>
    /// 订单信息DTO
    /// </summary>
    public class OrderDTO: AggregateRoot // 聚合根
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 订单明细
        /// </summary>
        public List<OrderItemDTO> OrderItems { get; set; }
    }

    /// <summary>
    /// 订单明细DTO
    /// </summary>
    public class OrderItemDTO
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
