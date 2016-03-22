using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DavidWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUser" in both code and config file together.
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        [WebInvoke(
                Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare)]
        Stream Login(Credentials credentials);
    }

    [DataContract(Namespace = "")]
    public class Credentials
    {
        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }
    }
}
