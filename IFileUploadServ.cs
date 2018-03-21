using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfAlfa
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFileUploadServ" in both code and config file together.
    [ServiceContract]
    public interface IFileUploadServ
    {
        [OperationContract]
        //[WebGet(UriTemplate = "File/{fileName}/{fileExtension}")]
        [WebGet(UriTemplate = "Libro?identificador={id}&uuid={uuid}&Codigo={codigo}")]
        Stream DownloadFile(string id, string uuid,string codigo);

        [OperationContract]
        //[WebGet(UriTemplate = "File/{fileName}/{fileExtension}")]
        [WebGet(UriTemplate = "Libroupdate?identificador={id}&uuid={uuid}&Codigo={codigo}&version={version}")]
        Stream UpdateFile(string id, string uuid, string codigo,long version);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/UploadFile?fileName={fileName}")]
        void UploadFile(string fileName, Stream stream);
    }
}
