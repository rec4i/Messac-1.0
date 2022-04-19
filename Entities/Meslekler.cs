using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace qrmenu.Entities
{
    public class Meslekler
    {
        [Key]
        public int Id { get; set; }
        public string Meslek_Adı { get; set; }
        [JsonIgnore]
        public int Silinmişmi { get; set; }
    }
}