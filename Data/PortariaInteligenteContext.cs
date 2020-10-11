using Microsoft.EntityFrameworkCore;
using PortariaInteligente.Models;

namespace PortariaInteligente.Data
{
    public class PortariaInteligenteContext : DbContext
    {
        public PortariaInteligenteContext(DbContextOptions<PortariaInteligenteContext> options) : base(options)
        {
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
         }
 

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Visitante> Visitantes { get; set; }
        public DbSet<Visitado> Visitados { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Convite> Convites { get; set; }
        public DbSet<Papel> Papeis { get; set; }



    }
}
