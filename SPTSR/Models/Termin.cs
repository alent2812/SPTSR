using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTSR.Models
{
    public class Termin
    {
        public int Id { get; set; }
        public DateTime Vrijeme { get; set; } //Dan izlaganja
        public int BrojIzlaganja { get; set; } //Broj izlaganja u terminu
        public virtual ICollection<Seminar> Seminari { get; set; }
    }
}