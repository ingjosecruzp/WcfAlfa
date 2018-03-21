using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfAlfa
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WSLibros" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WSLibros.svc or WSLibros.svc.cs at the Solution Explorer and start debugging.
    public class WSLibros : WsBase, IWSLibros
    {
        public libros get(string id)
        {
            //throw new NotImplementedException();
            return null;
        }
        public List<libros> getAll()
        {
            try
            {
                alfadbEntities db = new alfadbEntities();

                List<libros> LstLibros = db.libros.ToList();

                return LstLibros;
            }
            catch (Exception ex)
            {

                Error(ex, "El libro");
                return null;
            }
        }
        public List<libroscategorias> getXcategoria(string categoria)
        {
            List<string> tokens = new List<string>();
            try
            {

                alfadbEntities db = new alfadbEntities();
                long CategoriaId = long.Parse(categoria);

                List<libroscategorias> librocategoria = db.libroscategorias.Include(l => l.libros).Where(lc => lc.CategoriaId == CategoriaId).ToList();

                if (librocategoria == null)
                    throw new Exception("No se encontraron libros en esta categoria");

               // List<libros> LstLibros = db.libros.Where(l => l.Id == librocategoria.ToList().).ToList();


                /*   tokens Token = new tokens();
                   Token.Token = GenerarToken(Usuario.Id.ToString(), Usuario.Usuario, Usuario.Password);
                   Token.FechaUltimaModificacion = DateTime.Now;

                   db.tokens.Add(Token);
                   db.SaveChanges();


                   tokens.Add(Token.Token);
                   return tokens;*/
                return librocategoria;
            }
            catch (Exception ex)
            {
                Error(ex, "El usuario");
                tokens.Add("");
                return null;
            }
        }
        public List<libros> getXlike(string librolike,int index)
        {
            List<string> tokens = new List<string>();
            try
            {
                /*test*/
                alfadbEntities db = new alfadbEntities();
                List<libros> libros = db.libros.Where(l => l.Nombre.Contains(librolike)).OrderBy(m=>m.Nombre).Skip(index).Take(20).ToList();

                /*if (libros == null || libros.Count==0)
                    throw new Exception("No se encontraron libros con esta descripcion");*/


                /*   tokens Token = new tokens();
                   Token.Token = GenerarToken(Usuario.Id.ToString(), Usuario.Usuario, Usuario.Password);
                   Token.FechaUltimaModificacion = DateTime.Now;

                   db.tokens.Add(Token);
                   db.SaveChanges();


                   tokens.Add(Token.Token);
                   return tokens;*/
                return libros;
            }
            catch (Exception ex)
            {
                Error(ex, "El usuario");
                tokens.Add("");
                return null;
            }
        }
        public List<libroscodigos> ChecarSaldo(long libroId,string uuid)
        {
            List<string> tokens = new List<string>();
            try
            {
               
                alfadbEntities db = new alfadbEntities();
                libroscodigos ObjLibrosCodigos = new libroscodigos();

                // List<libroscodigos> Lstlibroscodigos = db.libroscodigos.AsNoTracking().Include(c=>c.codigos).Where(c => c.codigos.UUID== uuid).Where(Libroid=>Libroid.LibroId==null).ToList();
                   List<libroscodigos> Lstlibroscodigos = db.libroscodigos.AsNoTracking().Where(c => c.UUID == uuid && c.LibroId ==null).Include(a=>a.codigos).ToList();
                if (Lstlibroscodigos.Count >= 1)
                   {
                    
                        

                        //se llena el objeto libroscodigo para hacer el update table:libroscodigos
                        ObjLibrosCodigos.Id = Lstlibroscodigos.First().Id;
                        ObjLibrosCodigos.LibroId = libroId;
                        ObjLibrosCodigos.Activo = "SI";
                 
                     // db.libroscodigos.Attach(ObjLibrosCodigos);
                        db.Entry(ObjLibrosCodigos).State = System.Data.Entity.EntityState.Modified;
                        db.Entry(ObjLibrosCodigos).Property(p => p.CodigoId).IsModified = false;
                        db.Entry(ObjLibrosCodigos).Property(p => p.Activo).IsModified = false;
                        db.Entry(ObjLibrosCodigos).Property(p => p.UUID).IsModified = false;


                    db.SaveChanges();
                   }
                return Lstlibroscodigos; 
            }
            catch (Exception ex)
            {
                Error(ex, "Ya cuentas con este libro, intenta con otro libro");
                tokens.Add("");
                return null;
            }
        }
    }
}
