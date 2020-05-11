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
 

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ExternalUser> ExternalUsers { get; set; }
        public DbSet<InternalUser> InternalUsers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<GuestMeeting> GuestMeetings { get; set; }




    }
}
