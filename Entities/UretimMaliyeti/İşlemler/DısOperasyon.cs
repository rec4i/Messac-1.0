using System.ComponentModel.DataAnnotations;
using qrmenu.Entities;

namespace KaynakKod.Entities
{
    public class DısOperasyon
    {

        [Key]
        public int Id { get; set; }

        public string Operasyon_Adı { get; set; }
        public int Birim_Id { get; set; }
        public decimal Operasyon_Maliyeti { get; set; }

    }

    public class DısOperasyon_Return_Valur
    {

        [Key]
        public int Id { get; set; }

        public string Operasyon_Adı { get; set; }
        public decimal Operasyon_Maliyeti { get; set; }

        public int Birim_Id { get; set; }

        public Birimler Birim { get; set; }

    }


}