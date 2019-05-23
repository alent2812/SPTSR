using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SPTSR.Models
{
    public class SeminarDBContext : DbContext
    {
        public SeminarDBContext() : base("name=SeminarDBContext")
        {

        }



        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Kolegij> Kolegiji { get; set; }
        public DbSet<KorisnikKolegij> KorisnikKolegiji { get; set; }
        public DbSet<Seminar> Seminari { get; set; }
        public DbSet<Tema> Teme { get; set; }
        public DbSet<Termin> Termini{ get; set; }
    }

}