using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTSR.Models
{
    public class Kolegij
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        
        public virtual ICollection<Seminar> Seminari { get; set; }
        public virtual ICollection<KorisnikKolegij> KorisnikKolegiji { get; set; }
        
    }
}