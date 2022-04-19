using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace qrmenu.Entities
{
    public class Parti_Görevi
    {
        [Key]
        public int Id { get; set; }
        public string Görev_Adı { get; set; }
        [JsonIgnore]
        public int Silinmişmi { get; set; }
    }
}