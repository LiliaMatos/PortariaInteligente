using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using PortariaInteligente.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PortariaInteligente.Data
{
    public class PortariaInteligenteContext : IdentityDbContext
    {
        public PortariaInteligenteContext(DbContextOptions<PortariaInteligenteContext> options) : base(options)
        {
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PortariaInteligenteBD;Trusted_Connection=true;");

         }
 

        public DbSet<Visitado> Visitados { get; set; }
        public DbSet<Convidado> Convidados { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<ConvidadoEvento> ConvidadoEventos { get; set; }




    }
}
