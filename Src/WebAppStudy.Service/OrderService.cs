using WebApiStudy.Common.Core.Base;
using WebApiStudy.Dtos.Order;

namespace WebApiStudy.Service
{
    /// <summary>
    /// 订单服务
    /// </summary>
    public class OrderService: BaseService
    {
        /// <summary>
        /// 处理订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Result<OrderDTO> ProcessOrder(OrderDTO order)
        {
            try
            {
                if (order == null)
                    return ErrorResult<OrderDTO>("参数不能为空！", "1001");
                OrderDTO orderDTO = new OrderDTO();
                return SuccessResult(orderDTO);
            }
            catch (Exception ex)
            {
                return ErrorResult<OrderDTO>(ex.Message, "1050");
            }
        }
    }
}
