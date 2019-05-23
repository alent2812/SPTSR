using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTSR.Models
{
    public class KorisnikKolegij
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public int KolegijId { get; set; }
        public virtual Korisnik Korisnici { get; set; }
        public virtual Kolegij Kolegiji { get; set; }
        public virtual ICollection<Seminar> Seminari { get; set; }

    }
}