using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTSR.Models
{
    public class Tema
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public virtual ICollection<Seminar> Seminari { get; set; }
    }
}