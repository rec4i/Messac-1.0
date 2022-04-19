using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities

{
    public class YeniUye
    {

        public int Id { get; set; }
        public DateTime Kayır_Tarihi
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

        public long? TC { get; set; }
        public DateTime Doğum_Tarihi { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }

        public string AnaADI { get; set; }
        public string BabaADI { get; set; }
        public string TELEFONNO { get; set; }
        public string AdresIS { get; set; }

        public string Mail { get; set; }
        public int Cinsiyet { get; set; }
        public string AdresEV { get; set; }
        public int? MESLEK { get; set; }
        public int? PartiGOREVI { get; set; }

        public int? GorevYeriIL { get; set; }
        public int? GorevYeriILCE { get; set; }
        public string RESİM { get; set; }
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