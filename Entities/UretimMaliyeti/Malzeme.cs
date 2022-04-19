using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace qrmenu.Entities
{
    public class Malzeme_Genel_Adı
    {
        [Key]
        public int Id { get; set; }
        public string Malzeme_Genel_Adı_Txt { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }


    }
    public class Malzeme
    {
        [Key]
        public int Id { get; set; }
        public string Malzeme_Cinsi { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Özgül_Ağırlık { get; set; }
        public int Kesim_TürüId { get; set; }
        public int Büküm_Kriteri { get; set; }
        public int Malzeme_Genel_AdıId { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }

    }

    public class Malzeme_Return_Value
    {

        public int Id { get; set; }
        public string Malzeme_Cinsi { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Özgül_Ağırlık { get; set; }
        public Kesim_Türü Kesim_Türü { get; set; }
        public int Büküm_Kriteri { get; set; }
        public Malzeme_Genel_Adı Malzeme_Genel_AdıId { get; set; }

    }







}