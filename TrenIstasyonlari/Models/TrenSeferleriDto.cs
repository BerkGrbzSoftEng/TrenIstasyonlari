namespace TrenIstasyonlari.Models
{
    public class TrenSeferleriDto
    {
        public int SeferId { get; set; }
        public string KalkisIstasyonAdi { get; set; }
        public string VarisIstasyonAdi { get; set; }
        public DateTime KalkisSaati { get; set; }
        public DateTime VarisSaati { get; set; }
        public int KalkisIstasyonId { get; set; }
        public int VarisIstasyonId { get; set; }
    }
}
