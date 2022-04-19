using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using qrmenu.Entities;

namespace KaynakKod.Entities.UretimMaliyeti.İşlemler
{
    public class Boya_Türü
    {
        [Key]
        public int Id { get; set; }
        public string Boya_Türü_Text { get; set; }
        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
    }

    public class Boya_Türü_Retrun_Value
    {
        [Key]
        public int Id { get; set; }
        public string Boya_Türü_Text { get; set; }
        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        public List<Boya_Return_Value> Boyas { get; set; }
    }
    public class Boya
    {
        [Key]
        public int Id { get; set; }
        public int Boya_Türü_Id { get; set; }
        public string Boya_Text { get; set; }
        public int Birim_Id { get; set; }
        public decimal Birim_Fiyat { get; set; }
        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
    }

    public class Boya_Return_Value
    {
        [Key]
        public int Id { get; set; }
        public int Boya_Türü_Id { get; set; }
        public string Boya_Text { get; set; }
        public int Birim_Id { get; set; }
        public Birimler Birim { get; set; }
        public Boya_Türü Boya_Türü { get; set; }
        public decimal Birim_Fiyat { get; set; }
        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
    }


}