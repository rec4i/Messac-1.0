using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KaynakKod.Entities
{
    public class Toplam_Maliyet_Saved
    {

        [Key]
        public int Id { get; set; }

        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }

        private DateTime _DateCreated = DateTime.Now;

        public DateTime Olusturlma_Tarihi
        {
            get
            {
                return this._DateCreated;
            }

            set { this._DateCreated = value; }
        }

        public decimal İşçilik_Maliyeti { get; set; }
        public decimal İşçilik_Kar_Oranı { get; set; }
        public decimal İşçilik_Karlı_Toplam { get; set; }


        public decimal Malzeme_Maliyeti { get; set; }
        public decimal Malzeme_Kar_Oranı { get; set; }
        public decimal Malzeme_Karlı_Toplam { get; set; }

        public decimal Malzeme_Birim_Fiyatı { get; set; }
        public decimal Hurda_Birim_Satış_Oranı { get; set; }
        public decimal Malzeme_Hurda_Fiyatı { get; set; }
        public decimal Malzeme_Fire_Oranı { get; set; }
        public decimal Fire_Maliyeti { get; set; }

        public decimal Parça_Genel_Kar_Oranı { get; set; }
        public decimal Parça_Toplam_Maliyeti { get; set; }





    }

    public class Toplam_Maliyet_Saved_Return_Value
    {

        [Key]
        public int Id { get; set; }

        public int Revize_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }

        private DateTime _DateCreated = DateTime.Now;

        public DateTime Olusturlma_Tarihi
        {
            get
            {
                return this._DateCreated;
            }

            set { this._DateCreated = value; }
        }

        public decimal İşçilik_Maliyeti { get; set; }
        public decimal İşçilik_Kar_Oranı { get; set; }
        public decimal İşçilik_Karlı_Toplam { get; set; }


        public decimal Malzeme_Maliyeti { get; set; }
        public decimal Malzeme_Kar_Oranı { get; set; }
        public decimal Malzeme_Karlı_Toplam { get; set; }

        public decimal Malzeme_Birim_Fiyatı { get; set; }
        public decimal Hurda_Birim_Satış_Oranı { get; set; }
        public decimal Malzeme_Hurda_Fiyatı { get; set; }
        public decimal Malzeme_Fire_Oranı { get; set; }
        public decimal Fire_Maliyeti { get; set; }

        public decimal Parça_Genel_Kar_Oranı { get; set; }
        public decimal Parça_Toplam_Maliyeti { get; set; }


        public List<İşçilik_Maliyeti_Selected> İşçilik_Maliyeti_Selecteds { get; set; }

        public List<Malzeme_Maliyeti_Selected> Malzeme_Maliyeti_Selected { get; set; }



    }

    public class İşçilik_Maliyeti_Selected
    {
        [Key]
        public int Id { get; set; }

        public int Toplam_Maliyet_Saved_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }

        private DateTime _DateCreated = DateTime.Now;

        public DateTime Olusturlma_Tarihi
        {
            get
            {
                return this._DateCreated;
            }

            set { this._DateCreated = value; }
        }


        public string Maliyet_Text { get; set; }
        public decimal İşlem_Maliyeti { get; set; }
    }

    public class Malzeme_Maliyeti_Selected
    {
        [Key]
        public int Id { get; set; }

        public int Toplam_Maliyet_Saved_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }

        private DateTime _DateCreated = DateTime.Now;

        public DateTime Olusturlma_Tarihi
        {
            get
            {
                return this._DateCreated;
            }

            set { this._DateCreated = value; }
        }


        public string Maliyet_Text { get; set; }
        public decimal İşlem_Maliyeti { get; set; }

    }


}