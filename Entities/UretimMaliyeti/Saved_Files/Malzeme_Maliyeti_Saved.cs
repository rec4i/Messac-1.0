using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KaynakKod.Entities
{
    public class Malzeme_Maliyeti_Saved
    {

        [Key]
        public int Id { get; set; }

        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }




        public int Malzeme_Id { get; set; }
        public string Malzeme_Adı { get; set; }

        public decimal Malzeme_Birim_Fiyatı { get; set; }

        public int Malzeme_Kesim_Türü_Id { get; set; }

        public decimal Plaka_Eni { get; set; }

        public decimal Plaka_Boyu { get; set; }

        public decimal Plaka_Kalınlığı { get; set; }

        public decimal Parça_Adeti { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Parça_Firesiz_Ağırlığı { get; set; }

        public decimal Plaka_Maliyeti { get; set; }




    }

}