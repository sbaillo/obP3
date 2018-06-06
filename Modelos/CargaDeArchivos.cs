using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Web.Configuration;

namespace Modelos
{

    public class CargaDeArchivos
    {

        public static void IniciarDB()
        {
            try
            {
                //Crea un grupo y lo elimina para inicializar la base de datos antes de cargar valores.
                using (JuntaContext db = new JuntaContext())
                {
                    Grupo g = new Grupo(9999, "Inicializar");
                    db.Grupos.Add(g);
                    db.SaveChanges();

                    db.Grupos.Remove(g);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }
        }

        public static void CargarGrupos()
        {
            try
            {
                string ruta = HttpRuntime.AppDomainAppPath + WebConfigurationManager.AppSettings["rutaGrupos"].ToString();

                if (File.Exists(ruta))
                {
                    FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;

                        using (JuntaContext db = new JuntaContext())
                        {

                            while ((line = sr.ReadLine()) != null)
                            {
                                var grupo = line.Split('#');
                                Grupo g = new Grupo(Convert.ToInt32(grupo[0]), grupo[1]);

                                if (db.Grupos.Find(g.Id) == null) db.Grupos.Add(g);

                            }

                            db.SaveChanges();
                        }

                    }

                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }


        }

        public static void CargarTramites()
        {
            try
            {
                string ruta = HttpRuntime.AppDomainAppPath + WebConfigurationManager.AppSettings["rutaTramites"].ToString();

                if (File.Exists(ruta))
                {
                    FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;
                        using (JuntaContext db = new JuntaContext())
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                var tramite = line.Split('|');

                                Tramite t = new Tramite(Convert.ToInt32(tramite[0]), tramite[1], Convert.ToDouble(tramite[2]), Convert.ToInt32(tramite[3]));

                                if (db.Tramites.Find(Convert.ToInt32(tramite[0])) == null)
                                    db.Tramites.Add(t);
                               
                            }

                            db.SaveChanges();
                        }
                    }

                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }


        }


        public static void CargarEtapas()
        {
            try
            {
                string ruta = HttpRuntime.AppDomainAppPath + WebConfigurationManager.AppSettings["rutaEtapas"].ToString();

                if (File.Exists(ruta))
                {
                    FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;
                        using (JuntaContext db = new JuntaContext())
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                var etapa = line.Split('@');

                                Etapa e = new Etapa(Convert.ToInt32(etapa[0]), Convert.ToInt32(etapa[1]), etapa[2], Convert.ToInt32(etapa[3]));

                                if (db.Etapas.Find(e.Id) == null)
                                    db.Etapas.Add(e);
                            }

                            db.SaveChanges();
                        }
                    }

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }
        }


        public static void CargarAsignacionGrupos()
        {
            try
            {
                string ruta = HttpRuntime.AppDomainAppPath + WebConfigurationManager.AppSettings["rutaAsignacionGrupos"].ToString();

                if (File.Exists(ruta))
                {
                    FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;
                        using (JuntaContext db = new JuntaContext())
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                var asignacion = line.Split('$');

                                AsignacionGrupo a = new AsignacionGrupo(Convert.ToInt32(asignacion[0]), Convert.ToInt32(asignacion[1]));

                                if(db.AsignacionesGrupo.Find(a.IdTramite, a.IdGrupo)==null)
                                db.AsignacionesGrupo.Add(a);
                            }

                            db.SaveChanges();
                        }
                    }

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }
        }



        public static void CargarUsuarios()
        {
            try
            {
                string ruta = HttpRuntime.AppDomainAppPath + WebConfigurationManager.AppSettings["rutaFuncionarios"].ToString();

                if (File.Exists(ruta))
                {
                    FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;
                        using (JuntaContext db = new JuntaContext())
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                var usuario = line.Split('#');

                                Usuario u = new Usuario { Nombre = usuario[0], Email = usuario[1], IdGrupo = Convert.ToInt32(usuario[2]), Password = "123456789" };

                                if (db.Usuarios.Find(u.Email) == null)
                                    db.Usuarios.Add(u);
                            }

                            db.SaveChanges();
                        }
                    }

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }
        }

        public static void CargarUsuariosNuevos()
        {
            try
            {
                using (JuntaContext db = new JuntaContext())
                {
                    Usuario u = new Usuario { Nombre = "Jose Macedo", Email = "jmacedo@gmail.com", Password = "123456789", IdGrupo = 2 };
                    if (db.Usuarios.Find("jmacedo@gmail.com") == null) db.Usuarios.Add(u);

                    Usuario u2 = new Usuario { Nombre = "Santiago Baillo", Email = "sbaillo@gmail.com", Password = "123456789", IdGrupo = 3 };
                    if (db.Usuarios.Find("sbaillo@gmail.com") == null) db.Usuarios.Add(u2);

                    Usuario u3 = new Usuario { Nombre = "Julia Fagundez", Email = "jfagundez@gmail.com", Password = "123456789", IdGrupo = 4 };
                    if (db.Usuarios.Find("jfagundez@gmail.com") == null) db.Usuarios.Add(u3);

                    Usuario u4 = new Usuario { Nombre = "Martin Caceres", Email = "mcaceres@gmail.com", Password = "123456789", IdGrupo = 5 };
                    if (db.Usuarios.Find("mcaceres@gmail.com") == null) db.Usuarios.Add(u4);

                    Usuario u5 = new Usuario { Nombre = "Rodrigo Basten", Email = "rbasten@gmail.com", Password = "123456789", IdGrupo = 6 };
                    if (db.Usuarios.Find("rbasten@gmail.com") == null) db.Usuarios.Add(u5);

                    Usuario u6 = new Usuario { Nombre = "Lucia Perez", Email = "lperez@gmail.com", Password = "123456789", IdGrupo = 7 };
                    if (db.Usuarios.Find("lperez@gmail.com") == null) db.Usuarios.Add(u6);

                    Usuario u7 = new Usuario { Nombre = "Clara Blanco", Email = "cblanco@gmail.com", Password = "123456789", IdGrupo = 8 };
                    if (db.Usuarios.Find("cblanco@gmail.com") == null) db.Usuarios.Add(u7);

                    db.SaveChanges();
                }
                    
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }
        }

    }
}
