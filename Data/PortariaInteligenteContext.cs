using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
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
             optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PortariaInteligenteBD;Trusted_Connection=true;");

         }
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["PortariaInteligenteDatabase"].ConnectionString);
        }*/

        public DbSet<Anfitriao> Anfitriaos { get; set; }
        public DbSet<Convidado> Convidados { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<ConvidadoEvento> ConvidadosEventos { get; set; }



    }
}
