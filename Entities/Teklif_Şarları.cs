using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Entities
{
    public class Teklif_Şarları
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public List<Urun> Uruns { get; set; }
        public int Alım_Miktarı { get; set; }
        public int Mal_Fazlası { get; set; }
        
    }
}