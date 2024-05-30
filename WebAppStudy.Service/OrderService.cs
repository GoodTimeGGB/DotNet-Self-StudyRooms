using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiStudy.Common.Core.Base;
using WebApiStudy.Dtos.Order;

namespace WebApiStudy.Service
{
    /// <summary>
    /// 订单服务
    /// </summary>
    public class OrderService: BaseService
    {
        public Result<OrderDTO> ProcessOrder(OrderDTO order)
        {
            try
            {
                if (order == null)
                    return ErrorResult<OrderDTO>("", "");
                OrderDTO orderDTO = new OrderDTO();
                return SuccessResult(orderDTO);
            }
            catch (Exception ex)
            {
                return ErrorResult<OrderDTO>(ex.Message, "");
            }
        }
    }
}
