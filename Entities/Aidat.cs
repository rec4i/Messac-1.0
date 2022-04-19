using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace qrmenu.Entities
{
    public class Aidat
    {
        [Key]
        public int Id { get; set; }

        public int Uye_Id { get; set; }

        public decimal Tutar { get; set; }

        public DateTime Oluşturulma_Tar
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }
        private DateTime? dateCreated = null;
        public string Açıklama { get; set; }

        public bool Odendimi { get; set; }
        [JsonIgnore]
        public int Silinmişmi
        {
            get
            {
                return this.Default_Value.HasValue
                   ? this.Default_Value.Value
                   : 0;
            }

            set { this.Default_Value = value; }
        }
        private int? Default_Value = null;
    }
}