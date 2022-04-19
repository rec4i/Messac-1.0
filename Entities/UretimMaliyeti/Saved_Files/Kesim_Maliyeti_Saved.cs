using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KaynakKod.Entities
{
    public class Kesim_Maliyeti_Saved
    {

        [Key]
        public int Id { get; set; }
        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }


        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }




        public int Malzeme_Kesim_Türü_Id { get; set; }

        public int Parça_Adeti { get; set; }

        public decimal Kesim_Verimliliği { get; set; }

        public DateTime Kesim_Süresi_Saat { get; set; }

        public string Kesim_Süresi_Saniye { get; set; }

        public decimal Kesim_Fiyatı { get; set; }

        public decimal Kesim_Maliyeti { get; set; }






    }

}