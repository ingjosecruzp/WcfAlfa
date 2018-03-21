using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace WcfAlfa
{
    [ServiceContract]
    public interface IWSBase<TEntity>
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/{id}",
        BodyStyle = WebMessageBodyStyle.Bare,
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        Method = "GET")]
        TEntity get(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/",
        BodyStyle = WebMessageBodyStyle.Bare,
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        Method = "GET")]
        List<TEntity> getAll();

        /*[OperationContract]
        [WebInvoke(UriTemplate = "search?method={metodo}",
        BodyStyle = WebMessageBodyStyle.Bare,
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        Method = "GET")]
        List<TEntity> query(string metodo);*/
    }
}