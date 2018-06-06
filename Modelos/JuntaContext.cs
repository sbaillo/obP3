using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Modelos
{
    public class JuntaContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Tramite> Tramites { get; set; }
        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<AsignacionGrupo> AsignacionesGrupo { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<EtapasDeExpediente> EtapasDeExpedientes { get; set; }
        public JuntaContext():base("conexionJunta")
        {

        }
    }
}
