using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfAlfa
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWSLibros" in both code and config file together.
    [ServiceContract]
    public interface IWSLibros : IWSBase<libros>
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "?searchBy=getXcategoria&categoria={categoria}",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "GET")]
        List<libroscategorias> getXcategoria(string categoria);

        [OperationContract]
        [WebInvoke(UriTemplate = "?searchBy=getXlike&librolike={librolike}&index={index}",
        BodyStyle = WebMessageBodyStyle.WrappedRequest,
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        Method = "GET")]
        List<libros> getXlike(string librolike,int index);

        [OperationContract]
        [WebInvoke(UriTemplate = "?searchBy=VerificarCodigo&libroId={libroId}&uuid={uuid}",
        BodyStyle = WebMessageBodyStyle.WrappedRequest,
       ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        Method = "GET")]
        List<libroscodigos> ChecarSaldo(long libroId, string uuid);


    }
}
