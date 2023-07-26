using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrenIstasyonlar.DataAccess.Entities
{
    public class Sefer
    {
        public int SeferId { get; set; }

        public int? KalkisIstasyonId { get; set; }

        public int? VarisIstasyonId { get; set; }

        public DateTime? KalkisSaati { get; set; }

        public DateTime? VarisSaati { get; set; }

        public virtual Istasyon? KalkisIstasyon { get; set; }

        public virtual Istasyon? VarisIstasyon { get; set; }
    }
}
