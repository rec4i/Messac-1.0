using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KaynakKod.Entities.UretimMaliyeti.İşlemler
{
    public class BaglantıElemanları
    {
        [Key]
        public int Id { get; set; }
        public string Bağlantı_Elemanı_Text { get; set; }
        public decimal Birim_Fiyat { get; set; }
        public int Bağlantı_Elemanları_Türü_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
    }

    public class BaglantıElemanları_Retun_Value
    {
        [Key]
        public int Id { get; set; }
        public string Bağlantı_Elemanı_Text { get; set; }
        public decimal Birim_Fiyat { get; set; }

        public int Bağlantı_Elemanları_Türü_Id { get; set; }

        public Bağlantı_Elemanları_Türü Bağlantı_Elemanları_Türü { get; set; }
    }

    public class Bağlantı_Elemanları_Türü
    {
        [Key]
        public int Id { get; set; }
        public string Bağlantı_Elemanları_Türü_Text { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }

    }
}
