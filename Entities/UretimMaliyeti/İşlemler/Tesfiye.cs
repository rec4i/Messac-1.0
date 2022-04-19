using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using qrmenu.Entities;

namespace KaynakKod.Entities.UretimMaliyeti.İşlemler
{
    public class Tesfiye
    {
        [Key]
        public int Id { get; set; }
        public string Tesfiye_Türü { get; set; }
        public int Birim_Id { get; set; }
        public decimal Maliyet { get; set; }
        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
    }
    public class Tesfiye_Return_Value
    {
        public int Id { get; set; }
        public string Tesfiye_Türü { get; set; }
        public int Birim_Id { get; set; }
        public Birimler Birim { get; set; }
        public decimal Maliyet { get; set; }
    }
}