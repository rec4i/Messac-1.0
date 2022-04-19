using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace qrmenu.Entities
{
    public class Büküm_KiloHesabı
    {

        [Key]
        public int Id { get; set; }

        public decimal Kilo_Bas { get; set; }

        public decimal Kilo_Son { get; set; }

        public decimal KatSayı { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
    }

    public class Büküm_AdetHesabı
    {

        [Key]
        public int Id { get; set; }
        public string Zorluk_Adı { get; set; }
        public decimal Zorluk_Katsayısı { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
    }

    public class Büküm_Uzunluk_Hesabı
    {

        [Key]
        public int Id { get; set; }

        public decimal Uzunluk_Bas { get; set; }

        public decimal Uzunluk_Son { get; set; }

        public decimal Zorluk_Katsayısı { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }

    }


    public class Büküm_Uzunluk_Hesabı_Zorluk
    {

        [Key]
        public int Id { get; set; }

        public string Zorluk_Adı { get; set; }

        public decimal Zorluk_Katsayısı { get; set; }

        public int Büküm_Uzunluk_Hesabı_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
    }


    public class Büküm_Uzunluk_Hesabı_Zorluk_Return_Value
    {

        [Key]
        public int Id { get; set; }

        public string Zorluk_Adı { get; set; }

        public decimal Zorluk_Katsayısı { get; set; }

        public int Büküm_Uzunluk_Hesabı_Id { get; set; }

        public Büküm_Uzunluk_Hesabı Büküm_Uzunluk_Hesabı { get; set; }
    }





}