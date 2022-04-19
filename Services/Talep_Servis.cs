using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Authorization;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class Talep_Context : DbContext
    {
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Teklif_Şarları> Teklif_Şarlarıs { get; set; }
        public Talep_Context()
        {

        }
    }
    public class Talep_Servis
    {
        private Talep_Context _context;
        public void Teklif_Şarları_Ekle()
        {

            var t = new Teklif_Şarları();

            t.Alım_Miktarı = 1;
            t.Mal_Fazlası = 2;



            _context.Teklif_Şarlarıs.Add(t);
            _context.SaveChanges();

        }
    }
}