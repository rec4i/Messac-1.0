using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace qrmenu.Entities
{
    // public class Büküm_Cinsi
    // {
    //     [Key]
    //     public int Id { get; set; }
    //     public string Büküm_Cinsi_Txt { get; set; }
    //     public int Malzeme_Genel_Adı_ID { get; set; }
    // }

    public class Kalınlık
    {
        [Key]
        public int Id { get; set; }
        public decimal Kalınlık_Bas { get; set; }
        public decimal Kalınlık_Son { get; set; }
        public int Malzeme_Genel_Adı_ID { get; set; }

    }

    public class Kalınlık_Return_Value
    {
        [Key]
        public int Id { get; set; }
        public decimal Kalınlık_Bas { get; set; }
        public decimal Kalınlık_Son { get; set; }
        public int Malzeme_Genel_Adı_ID { get; set; }

        public Malzeme_Genel_Adı Malzeme_Genel_Adı { get; set; }

    }

    public class Uzunluk_Fiyat
    {
        public int Id { get; set; }
        public int Kalınlık_Id { get; set; }
        public decimal Uzunluk_Bas { get; set; }
        public decimal Uzunluk_Son { get; set; }
        public decimal Fiyat { get; set; }
    }

    public class Uzunluk_Fiyat_Return_Value
    {
        public int Id { get; set; }
        public int Kalınlık_Id { get; set; }
        public Kalınlık Kalınlık { get; set; }
        public decimal Uzunluk_Bas { get; set; }
        public decimal Uzunluk_Son { get; set; }
        public decimal Fiyat { get; set; }
    }


    public class Adet_Başına_Fiyat
    {
        [Key]
        public int Id { get; set; }
        public int Büküm_Adeti { get; set; }
        public decimal Fiyat { get; set; }
        public int Malzeme_Genel_Adı_Id { get; set; }
    }

    public class Adet_Başına_Fiyat_Retun_Value
    {
        [Key]
        public int Id { get; set; }
        public int Büküm_Adeti { get; set; }
        public decimal Fiyat { get; set; }
        public int Malzeme_Genel_Adı_Id { get; set; }

        public Malzeme_Genel_Adı Malzeme_Genel_Adı { get; set; }
    }

    public class Kilo_Başına_Büküm
    {
        [Key]
        public int Id { get; set; }
        public decimal Kilo_Bas { get; set; }
        public decimal Kilo_Son { get; set; }
        public int Malzeme_Genel_Id { get; set; }
        public decimal Fiyat { get; set; }
    }

    public class Kilo_Başına_Büküm_Return_Value
    {
        [Key]
        public int Id { get; set; }
        public decimal Kilo_Bas { get; set; }
        public decimal Kilo_Son { get; set; }
        public int Malzeme_Genel_Id { get; set; }

        public Malzeme_Genel_Adı Malzeme_Genel_Adı { get; set; }
        public decimal Fiyat { get; set; }
    }



    public class Büküm
    {
        [Key]
        public int Id { get; set; }
        public string Büküm_Cinsi_ID { get; set; }
        public int Aralıkmı { get; set; }
        public decimal? Aralık_Bas { get; set; }
        public decimal? Aralık_Son { get; set; }
        public int? Sabit_Değer { get; set; }
        public int Birim_Id { get; set; }

        public int Fiyat { get; set; }

    }

    public class Birimler
    {
        [Key]
        public int Id { get; set; }

        public string Birim_Uzun_Ad { get; set; }
        public string Birim_Kısa_ad { get; set; }



        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
    }














}