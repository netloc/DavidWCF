using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace DavidWCF
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        public Stream Login() {  // http://localhost:34306/Security.svc/xml/Login 
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            //StreamReader(xslDb.FileLocation).BaseStream;

            byte[] bytearray = Encoding.UTF8.GetBytes(@"{ ""value"": ""Hello George"" }");

            MemoryStream stream = new MemoryStream(bytearray);

            StreamReader reader = new StreamReader(stream);
            
            return reader.BaseStream;
        }

        public string GetData(int value) {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
