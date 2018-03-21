using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfAlfa
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWSVersiones" in both code and config file together.
    [ServiceContract]
    public interface IWSVersiones : IWSBase<versiones>
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "?searchBy=Actualizaciones&libroId={libroId}&version={version}&uuid={uuid}",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
             RequestFormat = WebMessageFormat.Json,
             Method = "GET")]
        List<versiones> Actualizaciones(long libroId,long version,string uuid);
    }
}
