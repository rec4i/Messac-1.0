using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KaynakKod.Entities
{
    public class Takım
    {

        [Key]
        public int Id { get; set; }

        public string Takım_Adı { get; set; }

        public int İş_Id { get; set; }

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

    public class Takım_Return_Value
    {

        [Key]
        public int Id { get; set; }

        public string Takım_Adı { get; set; }

        public int İş_Id { get; set; }

        public İş İş { get; set; }

        public DateTime Olusturlma_Tarihi { get; set; }

    }



}