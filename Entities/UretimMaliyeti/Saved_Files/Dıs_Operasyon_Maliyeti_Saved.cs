//Dıs_Operasyon_Maliyeti.cs


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KaynakKod.Entities
{
    public class Dıs_Operasyon_Maliyeti_Saved
    {

        [Key]
        public int Id { get; set; }
        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }

    }
    public class Dıs_Operasyon_Maliyeti_Saved_Retrun_Value
    {

        [Key]
        public int Id { get; set; }
        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }
        public List<Dıs_Operasyon_Maliyeti_Saved_Row> Dıs_Operasyon_Maliyeti_Saved_Rows { get; set; }

    }


    public class Dıs_Operasyon_Maliyeti_Saved_Row
    {

        [Key]
        public int Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }
        public int Dıs_Operasyon_Maliyeti_Saved_Id { get; set; }


        public string Dıs_Operasyon_Adı { get; set; }

        public decimal Dıs_Operasyon_Birim_Fiyat { get; set; }

        public decimal Dıs_Operasyon_Adet { get; set; }

        public decimal Toplam_Maliyet { get; set; }


    }



}