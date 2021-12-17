using System.Threading.Tasks;
using SoapCoreDemo.WebApi.Interfaces;
using SoapCoreDemo.WebApi.Models;

namespace SoapCoreDemo.WebApi.InternalServices
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        /// <summary>
        /// Receives the order and performs the necessary steps to completion.
        /// </summary>        
        public async Task<string> ProcessOrder(PurchaseOrderType purchaseOrderModel)
        {
            // Here goes all the async logic for validation, processing the order and returning the result.

            return "Order processed with success!";
        }
    }
}
