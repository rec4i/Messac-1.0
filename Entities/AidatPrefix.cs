using System.ComponentModel.DataAnnotations;

namespace qrmenu.Entities
{
    public class AidatPrefix
    {
        [Key]
        public int Id { get; set; }
        public string Aidat_Prefix { get; set; }
    }
}