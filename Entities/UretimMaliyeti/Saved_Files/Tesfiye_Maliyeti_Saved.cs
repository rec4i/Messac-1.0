using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KaynakKod.Entities
{
    public class Tesviye_Maliyeti_Saved
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


    }

    public class Tesviye_Maliyeti_Saved_Retrun_Value
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

        public List<Tesviye_Maliyeti_Saved_Row> Tesviye_Maliyeti_Saved_Row { get; set; }

    }

    public class Tesviye_Maliyeti_Saved_Row
    {

        [Key]
        public int Id { get; set; }
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

        public int Tesviye_Maliyeti_Saved_Id { get; set; }


        public string Tesviye_Türü { get; set; }

        public string Birim { get; set; }

        public decimal Birim_Fiyat { get; set; }

        public decimal Adet { get; set; }
        public decimal Toplam_Fiyat { get; set; }


    }



}