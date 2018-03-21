using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;
using System.Data.Entity;
using System.Web;

namespace WcfAlfa
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FileUploadServ" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select FileUploadServ.svc or FileUploadServ.svc.cs at the Solution Explorer and start debugging.
	public class FileUploadServ : WsBase, IFileUploadServ
	{
        public Stream UpdateFile(string id, string uuid, string codigo,long version)
        {
            try
            {
                alfadbEntities db = new alfadbEntities();

                int LibroId = Int16.Parse(id);

                //codigos Libro = db.codigos.Where(c => c.Codigo == codigo && c.UUID == uuid && ).Single()
                versiones Libro = db.versiones.Where(i => i.LibroId == LibroId && i.Version == version).SingleOrDefault();


                //string downloadFilePath = Path.Combine(HostingEnvironment.MapPath("~/FileServer/Extracts"), fileName + "." + fileExtension);
                string downloadFilePath = Path.Combine("C:\\Descargar_Libros\\updates\\", Libro.NombreArchivo + ".zip");

                // open stream
                System.IO.FileStream stream = new System.IO.FileStream(downloadFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                String headerInfo = "attachment; filename=" + Libro.NombreArchivo + ".zip";
                WebOperationContext.Current.OutgoingResponse.Headers["Content-Disposition"] = headerInfo;

                HttpContext.Current.Response.Headers.Add("Content-Length", stream.Length.ToString());
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";


                return stream;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Stream DownloadFile(string id, string uuid, string codigo)
        {
            try
            {
                alfadbEntities db = new alfadbEntities();

                int LibroId = Int16.Parse(id);

                //codigos Libro = db.codigos.Where(c => c.Codigo == codigo && c.UUID == uuid && ).Single()
                libroscodigos Libro = db.libroscodigos.Include(i => i.codigos).Include(i => i.libros).Where(c => c.codigos.Codigo == codigo && c.codigos.UUID == uuid && c.libros.Id == LibroId).SingleOrDefault();
                

                //string downloadFilePath = Path.Combine(HostingEnvironment.MapPath("~/FileServer/Extracts"), fileName + "." + fileExtension);
                string downloadFilePath = Path.Combine("C:\\Descargar_Libros\\", Libro.libros.Nombre + ".zip");

                // open stream
                System.IO.FileStream stream = new System.IO.FileStream(downloadFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                String headerInfo = "attachment; filename=" + Libro.libros.Nombre + ".zip";
                WebOperationContext.Current.OutgoingResponse.Headers["Content-Disposition"] = headerInfo;

                HttpContext.Current.Response.Headers.Add("Content-Length", stream.Length.ToString());
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";


                return stream;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void UploadFile(string fileName, Stream stream)
        {
            try
            {
                string FilePath = Path.Combine(HostingEnvironment.MapPath("~/FileServer/Uploads"), fileName);

                int length = 0;
                using (FileStream writer = new FileStream(FilePath, FileMode.Create))
                {
                    int readCount;
                    var buffer = new byte[8192];
                    while ((readCount = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        writer.Write(buffer, 0, readCount);
                        length += readCount;
                    }
                }
            }
            catch (Exception ex)
            {
                Error(ex, "El Libro");
            }
        }
    }
}
