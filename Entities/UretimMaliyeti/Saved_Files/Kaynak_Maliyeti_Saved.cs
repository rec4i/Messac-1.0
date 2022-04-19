using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KaynakKod.Entities
{
    public class Kaynak_Maliyeti_Saved
    {

        [Key]
        public int Id { get; set; }
        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }


    }

    public class Kaynak_Maliyeti_Saved_Retrun_Value
    {

        [Key]
        public int Id { get; set; }
        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }

        public List<Kaynak_Maliyeti_Saved_Row> Kaynak_Maliyeti_Saved_Row { get; set; }

    }

    public class Kaynak_Maliyeti_Saved_Row
    {

        [Key]
        public int Id { get; set; }
        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }

        public int Kaynak_Maliyeti_Saved_Id { get; set; }


        public string Kaynak_Adı { get; set; }

        public string Kaynak_birimi { get; set; }

        public decimal Birim_Fiyat { get; set; }

        public decimal Adet { get; set; }
        public decimal Toplam_Fiyat { get; set; }


    }



}