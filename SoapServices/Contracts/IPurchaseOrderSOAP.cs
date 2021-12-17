using System.ServiceModel;
using System.Threading.Tasks;
using SoapCoreDemo.WebApi.Models;

namespace SoapCoreDemo.WebApi.SoapServices.Contracts
{
    [ServiceContract(Namespace = "http://tempuri.org/PurchaseOrderSchema.xsd")]
    public interface IPurchaseOrderSOAP
    {
        [OperationContract(Name="ProcessOrder")]
        Task<string> PurchaseOrder(PurchaseOrderType PurchaseOrder);
    }
}
