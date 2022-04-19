using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KaynakKod.Entities
{
    public class Parça
    {

        [Key]
        public int Id { get; set; }

        public string Parça_Adı { get; set; }

        public decimal Parça_Adeti { get; set; }


        public int Takım_Id { get; set; }


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
    public class Parça_Retrun_Value
    {

        [Key]
        public int Id { get; set; }

        public string Parça_Adı { get; set; }

        public decimal Parça_Adeti { get; set; }
        public decimal Birim_Maliyet { get; set; }


        public int Takım_Id { get; set; }


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

}