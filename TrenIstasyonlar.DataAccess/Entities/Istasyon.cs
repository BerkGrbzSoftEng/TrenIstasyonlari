using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrenIstasyonlar.DataAccess.Entities
{
    public class Istasyon
    {
        public int IstasyonId { get; set; }

        public string? IstasyonAdi { get; set; }

        public string? IstasyonAdres { get; set; }

        public string? IstasyonKonum { get; set; }

        public virtual ICollection<Sefer> SeferKalkisIstasyons { get; set; } = new List<Sefer>();

        public virtual ICollection<Sefer> SeferVarisIstasyons { get; set; } = new List<Sefer>();
    }
}
