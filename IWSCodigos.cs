using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfAlfa
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWSCodigos" in both code and config file together.
    [ServiceContract]
    public interface IWSCodigos : IWSBase<codigos>
    {
        [OperationContract]
        //[WebInvoke(UriTemplate = "?searchBy=getXCodigo&codigo={codigo}&uuid={uuid}",
        [WebInvoke(UriTemplate = "?searchBy=getXCodigo&idcodigo={idcodigo}",
        BodyStyle = WebMessageBodyStyle.WrappedRequest,
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        Method = "GET")]
        List<libroscodigos> getXCodigo(long idcodigo);

        [OperationContract]
        [WebInvoke(UriTemplate = "?searchBy=VerificarCodigo&codigo={codigo}&uuid={uuid}",
        BodyStyle = WebMessageBodyStyle.WrappedRequest,
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        Method = "GET")]
        List<codigos> VerificarCodigo(string codigo, string uuid);
    }
}
