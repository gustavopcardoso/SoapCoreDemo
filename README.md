# SoapCore Demo
This is a simple .NET Core 3.1 application to demonstrate how to receive SOAP requests from an external client. For this example I got the XSD from the [docs](https://docs.microsoft.com/en-us/visualstudio/xml-tools/sample-xsd-file-simple-schema?view=vs-2022). Also, I made use of an external WSDL file, as described [here](https://github.com/DigDes/SoapCore#using-with-external-wsdl--xsd-schemas).

The model class was generated using the XML Schema Definition tool (Xsd.exe) from the VS command prompt, with the following command:

```
xsd PurchaseOrder.xsd /classes / language:CS
```
The request sample below can be sent using the [Postman](https://www.postman.com/downloads/) tool:
```xml
<soap:Envelope xmlns:soap="http://www.w3.org/2003/05/soap-envelope" xmlns:pur="http://tempuri.org/PurchaseOrderSchema.xsd" xmlns:tem="http://tempuri.org/">
   <soap:Header/>
   <soap:Body>
      <pur:ProcessOrder>
         <pur:PurchaseOrder OrderDate="2021-12-05">
            <pur:ShipTo country="US">
               <pur:name>John</pur:name>
               <pur:street>4635 Crowfield Road</pur:street>
               <pur:city>Phoenix</pur:city>
               <pur:state>AZ</pur:state>
               <pur:zip>85034</pur:zip>
            </pur:ShipTo>
            <pur:BillTo country="US">
               <pur:name>Mary</pur:name>
               <pur:street>256 Charla Lane</pur:street>
               <pur:city>Dallas</pur:city>
               <pur:state>TX</pur:state>
               <pur:zip>75240</pur:zip>
            </pur:BillTo>
         </pur:PurchaseOrder>
      </pur:ProcessOrder>
   </soap:Body>
</soap:Envelope>
```
For now, it doesn’t contain any business logic or validation. The main purpose is just to illustrate a way for .NET Core Web API to receive incoming SOAP requests making use of WCF contracts.
