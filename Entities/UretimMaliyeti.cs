using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class UretimMaliyeti
    {
        [Key]
        public int Id { get; set; }
        public string İşin_Adı { get; set; }
        public DateTime Oluşturlma_Tar { get; set; }
        public DateTime Son_Düzenleme_Tar { get; set; }
        public int Olusturan_kullanıcı { get; set; }
        public int Musteri_Id { get; set; }
        public string Teslim_Tarihi_Beklentisi { get; set; }
        public string Ödeme_Şekli_Beklentisi { get; set; }

    }
    public class UretimMaliyeti_Return
    {
        public int Id { get; set; }
        public string İşin_Adı { get; set; }
        public string Oluşturlma_Tar { get; set; }
        public string Son_Düzenleme_Tar { get; set; }
        public int Olusturan_kullanıcı { get; set; }
        public int Musteri_Id { get; set; }
        public string Teslim_Tarihi_Beklentisi { get; set; }
        public string Ödeme_Şekli_Beklentisi { get; set; }

    }
}