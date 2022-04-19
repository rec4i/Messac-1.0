using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace KaynakKod.Entities
{
    public class İş
    {

        [Key]
        public int Id { get; set; }
        public string İşin_Adı { get; set; }

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