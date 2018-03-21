using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace WcfAlfa
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WSCodigos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WSCodigos.svc or WSCodigos.svc.cs at the Solution Explorer and start debugging.
    public class WSCodigos : WsBase, IWSCodigos
    {
        public codigos get(string id)
        {
            //Comentario Fede
            //throw new NotImplementedException();
            return null;
        }
        public List<codigos> query(string metodo)
        {
            //throw new NotImplementedException();
            return null;
        }
        public List<codigos> getAll()
        {
            try
            {
                alfadbEntities db = new alfadbEntities();

                List<codigos> LstCodigos = db.codigos.ToList();

                return LstCodigos;
            }
            catch (Exception ex)
            {

                Error(ex, "El codigo");
                return null;
            }
        }
        public codigos BuscarCodigo(alfadbEntities db,string codigo)
        {
            try
            {
                codigos codigolibro = db.codigos.Where(c => c.Codigo == codigo).SingleOrDefault();

                if (codigolibro == null)
                    throw new Exception("Codigo incorrecto");

                if (codigolibro.UUID != null)
                    throw new Exception("Este codigo ya se encuentra asociado a un dispositivo");

                return codigolibro;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<libroscodigos> getXCodigo(long codigo)
        {
            List<string> tokens = new List<string>();
            try
            {
                alfadbEntities db = new alfadbEntities();

                //codigos codigolibro = BuscarCodigo(db, codigo);

                List<libroscodigos> LstLibrosCodigos = db.libroscodigos.Include(l => l.libros).Where(l => l.CodigoId == codigo).ToList();

                return LstLibrosCodigos;
            }
            catch (Exception ex)
            {
                Error(ex, "El usuario");
                tokens.Add("");
                return null;
            }
        }
        public List<codigos> VerificarCodigo(string codigo, string uuid)
        {
            try
            {
                alfadbEntities db = new alfadbEntities();


                codigos codigolibro = BuscarCodigo(db, codigo);

                //Actualiza la tablas libros codigo poniendo el UUID del dispostivo
                List<libroscodigos> LibrosCodigos = db.libroscodigos.Where(x => x.CodigoId == codigolibro.Id).ToList();
                LibrosCodigos.ForEach(c => c.UUID = uuid);

                //Liga el codigo con el uuid del equipo
                codigolibro.UUID = uuid;
                db.Entry(codigolibro).State = System.Data.Entity.EntityState.Modified;


                db.SaveChanges();

                List<codigos> codigoslibros=new  List<codigos>();
                codigoslibros.Add(codigolibro);

                return codigoslibros;
            }
            catch (Exception ex)
            {
                Error(ex, "El codigo");
                return null;
            }
        }
    }
}
