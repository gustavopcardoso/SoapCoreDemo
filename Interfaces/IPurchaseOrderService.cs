using System.Threading.Tasks;
using SoapCoreDemo.WebApi.Models;

namespace SoapCoreDemo.WebApi.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<string> ProcessOrder(PurchaseOrderType purchaseOrderModel);
    }
}
