using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTSR.Models
{
    public class Seminar
    {
        public int Id { get; set; }
        public int TemaId { get; set; }
        public int TerminId { get; set; }
        public int MaxClanovi { get; set; }
        public DateTime RokPrijave { get; set; }
        public int Clan1 { get; set; }
        public int Clan2 { get; set; }
        public int Clan3 { get; set; }
        public int Clan4 { get; set; }
        public int Clan5 { get; set; }
        public int KorisnikId { get; set; }


        public int KolegijId { get; set; }
        public virtual Kolegij Kolegiji { get; set; }
        public virtual KorisnikKolegij KorisnikKolegiji { get; set; }





        public virtual Tema Teme { get; set; }
        public virtual Termin Termini { get; set; }
        
    }
}