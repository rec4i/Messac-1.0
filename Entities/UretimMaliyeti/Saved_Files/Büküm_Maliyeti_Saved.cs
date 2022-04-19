using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KaynakKod.Entities
{
    public class Büküm_Maliyeti_Saved_Ağırlık
    {

        [Key]
        public int Id { get; set; }
        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }




        public decimal Malzeme_Ağırlığı { get; set; }

        public decimal Kat_Sayı { get; set; }

        public decimal Büküm_Maliyeti { get; set; }

        public int Büküm_Tipi { get; set; }


    }

    public class Büküm_Maliyeti_Saved_Adet
    {

        [Key]
        public int Id { get; set; }
        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }



        public int Büküm_Adeti { get; set; }
        public int Büküm_Zorluğu_Id { get; set; }

        public decimal Kat_Sayı { get; set; }

        public decimal Büküm_Maliyeti { get; set; }

        public int Büküm_Tipi { get; set; }


    }



    public class Büküm_Maliyeti_Saved_Uzunluk
    {

        [Key]
        public int Id { get; set; }
        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
        [DefaultValue("getdata()")]
        public DateTime Olusturlma_Tarihi { get; set; }





        public int Büküm_Adeti { get; set; }
        public int Hesap_Çeşiti_Id { get; set; }

        public decimal Malzeme_Eni { get; set; }
        public decimal Malzeme_Boyu { get; set; }

        public decimal Malzeme_Boyu_Katsayı { get; set; }

        public int Büküm_Zorluğu_Id { get; set; }

        public decimal Büküm_Zorluğu_Katsayı { get; set; }

        public decimal Büküm_Maliyeti { get; set; }

        public int Büküm_Tipi { get; set; }

    }

}