using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using qrmenu.Entities;

namespace KaynakKod.Entities.UretimMaliyeti.İşlemler
{
    public class Kaplama
    {
        [Key]
        public int Id { get; set; }
        public string Kapmala_Text { get; set; }

        public decimal Birim_Maliyet { get; set; }

        public int Birim_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
    }
    public class Kaplama_Return_Value
    {
        [Key]
        public int Id { get; set; }
        public string Kapmala_Text { get; set; }
        public int Birim_Id { get; set; }
        public decimal Birim_Maliyet { get; set; }

        public Birimler Birimler { get; set; }
    }
}