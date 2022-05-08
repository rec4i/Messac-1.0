using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KaynakKod.Entities
{
    public class Revize
    {

        [Key]
        public int Id { get; set; }

        public int Parça_Id { get; set; }

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

    public class Revize_Retrun_Value
    {

        public int Id { get; set; }

        public int Parça_Id { get; set; }

        public int Is_Deleted { get; set; }

        public DateTime Olusturlma_Tarihi
        {
            get; set;
        }

        public Takım Takım { get; set; }

        public Parça Parça { get; set; }

        public İş İş { get; set; }

    }


}