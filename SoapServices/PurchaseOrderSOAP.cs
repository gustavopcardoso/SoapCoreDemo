using System;
using System.Threading.Tasks;
using SoapCoreDemo.WebApi.Interfaces;
using SoapCoreDemo.WebApi.Models;
using SoapCoreDemo.WebApi.SoapServices.Contracts;

namespace SoapCoreDemo.WebApi.SoapServices
{
    public class PurchaseOrderSOAP : IPurchaseOrderSOAP
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderSOAP(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;                
        }

        public async Task<string> PurchaseOrder(PurchaseOrderType purchaseOrder)
        {
            string responseMessage = await _purchaseOrderService.ProcessOrder(purchaseOrder);

            return responseMessage;
        }
    }
}
