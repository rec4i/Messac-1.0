using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace qrmenu.Entities
{
    public class Cinsiyet
    {
        [Key]
        public int Id { get; set; }
        public string Cinsiyet_Adı { get; set; }
        [JsonIgnore] 
        public int Silinmişmi { get; set; }
    }
}