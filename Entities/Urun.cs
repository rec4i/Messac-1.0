using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        public string Urun_Adı { get; set; }
        public string Urun_Barkod { get; set; }
        public string Urun_Resim { get; set; }

        public string Etiket_Fiyatı { get; set; }
        public string Depo_Fiyatı { get; set; }

    }
}