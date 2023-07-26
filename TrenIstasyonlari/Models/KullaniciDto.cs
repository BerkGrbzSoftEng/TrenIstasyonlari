using System.ComponentModel.DataAnnotations;

namespace TrenIstasyonlari.Models
{
    public class KullaniciDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Zorunludur.")]
        [StringLength(100,ErrorMessage = "{0} alanı  en az {2} karakter uzunluğunda olmalıdır!", MinimumLength = 4)]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Sifre Zorunludur.")]
        [StringLength(200, ErrorMessage = "{0} alanı  en az {2} karakter uzunluğunda olmalıdır!", MinimumLength = 4)]
        [DataType(DataType.Password)] 
        public string Sifre { get; set; }

        public int KullaniciId { get; set; }
    }
}
