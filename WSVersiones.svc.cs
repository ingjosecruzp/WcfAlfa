using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAlfa
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WSVersiones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WSVersiones.svc or WSVersiones.svc.cs at the Solution Explorer and start debugging.
    public class WSVersiones : WsBase, IWSVersiones
    {
        public List<versiones> Actualizaciones(long libroId,long version,string uuid)
        {
            try
            {
                alfadbEntities db = new alfadbEntities();

                //Verifica si el libro se encuntra asociado al uuid
                libroscodigos libro = db.libroscodigos.Where(i => i.UUID == uuid && i.LibroId == libroId).SingleOrDefault();

                if (libro == null)
                    throw new Exception("Este libro no se encuentra asociado a tu libreria");

                //Busca una version disponible para el libro
                List<versiones> LstVersionesLibro = db.versiones.Where(i => i.LibroId == libroId && i.Version > version).ToList();

                return LstVersionesLibro;
            }
            catch (Exception ex)
            {

                Error(ex, "El libro");
                return null;
            }
        }

        public versiones get(string id)
        {
            throw new NotImplementedException();
        }

        public List<versiones> getAll()
        {
            throw new NotImplementedException();
        }
    }
}
