using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KaynakKod.Entities
{
    public class Bağlantı_Elemanı_Saved
    {

        [Key]
        public int Id { get; set; }
        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }


    }

    public class Bağlantı_Elemanı_Saved_Retrun_Value
    {

        [Key]
        public int Id { get; set; }
        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }

        public List<Bağlantı_Elemanı_Saved_row> Bağlantı_Elemanı_Saved_rows { get; set; }

    }

    public class Bağlantı_Elemanı_Saved_row
    {

        [Key]
        public int Id { get; set; }
        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }

        public int Bağlantı_Elemanı_Saved_Id { get; set; }
        public string Bağlantı_Elemanı_Id { get; set; }
        public string Bağlantı_Elemanı_Adı { get; set; }
        public decimal Birim_Fiyat { get; set; }
        public decimal Adet { get; set; }
        public decimal Toplam_Fiyat { get; set; }


    }



}