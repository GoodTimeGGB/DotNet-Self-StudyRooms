using WebApiStudy.DataAccess.Model;

namespace WebApiStudy.DataAccess.IRepository
{
    /// <summary>
    /// 订单仓储接口
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// 获取订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Order GetOrderById(int id);

        /// <summary>
        /// 保存订单
        /// </summary>
        /// <param name="order"></param>
        void SaveOrder(Order order);
    }
}
