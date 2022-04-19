using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace qrmenu.Entities
{
    public class Kesim_Türü
    {
        [Key]
        public int Id { get; set; }
        public string Kesim_Türü_Txt { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }

    }
    public class Kesim
    {
        [Key]
        public int Id { get; set; }
        public int Kesim_Türü_Id { get; set; }
        public decimal Kesim_mm_Bas { get; set; }
        public decimal Kesim_mm_Son { get; set; }
        public decimal Saat_Bası_Ucret { get; set; }

        public int Birim_Id { get; set; }

        [DefaultValue(0)]
        public int Is_Deleted { get; set; }
    }

    public class Kesim_Retun_value
    {
        [Key]
        public int Id { get; set; }
        public int Kesim_Türü_Id { get; set; }
        public decimal Kesim_mm_Bas { get; set; }
        public decimal Kesim_mm_Son { get; set; }
        public decimal Saat_Bası_Ucret { get; set; }

        public int Birim_Id { get; set; }

        public Birimler Birim { get; set; }

       
    }




}