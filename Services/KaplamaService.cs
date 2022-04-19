using System.Collections.Generic;
using System.Linq;
using KaynakKod.Entities.UretimMaliyeti.İşlemler;
using Microsoft.Extensions.Options;
using qrmenu.Entities;
using WebApi.Authorization;
using WebApi.Helpers;

namespace KaynakKod.Services
{
    public interface IKaplamaService
    {
        Kaplama kaplama_Add(Kaplama x);
        Kaplama Kaplama_Delete(Kaplama x);

        Kaplama Kaplama_Edit(Kaplama x);

        List<Kaplama_Return_Value> kaplama_Get_All();

        Kaplama_Return_Value kaplama_Get_By_Id(Kaplama x);

        List<Kaplama_Return_Value> kaplama_Get_By_Text(Kaplama x);


    }
    public class KaplamaService : IKaplamaService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public KaplamaService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Kaplama kaplama_Add(Kaplama x)
        {
            _context.kaplamas.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Kaplama Kaplama_Delete(Kaplama x)
        {
            var temp = _context.kaplamas;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted=1;
           // _context.kaplamas.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Kaplama Kaplama_Edit(Kaplama x)
        {
            var temp = _context.kaplamas;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Kapmala_Text = x.Kapmala_Text;
            Değer.Birim_Id = x.Birim_Id;
            Değer.Birim_Maliyet=x.Birim_Maliyet;
            _context.SaveChanges();

            return Değer;
        }

        public List<Kaplama_Return_Value> kaplama_Get_All()
        {
            var temp = (from x in _context.kaplamas
                        where x.Is_Deleted==0
                        select new {
                            x.Birim_Id,
                            x.Id,
                            x.Kapmala_Text,
                            x.Birim_Maliyet
                        }
            );

            IEnumerable<Kaplama_Return_Value> rd = temp.Select( o =>  new Kaplama_Return_Value{
                Birim_Id=o.Birim_Id,
                Id=o.Id,
                Kapmala_Text=o.Kapmala_Text,
                Birim_Maliyet=o.Birim_Maliyet,
                Birimler=(from x in _context.Birimlers
                        where x.Id==o.Birim_Id
                        select x
                ).FirstOrDefault()

            });

            return rd.ToList();
        }

        public Kaplama_Return_Value kaplama_Get_By_Id(Kaplama y)
        {
            var temp =(from x in _context.kaplamas
                        where x.Id==y.Id &&  x.Is_Deleted==0
                        select new {
                            x.Birim_Id,
                            x.Id,
                            x.Kapmala_Text,
                            x.Birim_Maliyet
                        }
            ).FirstOrDefault();

            Kaplama_Return_Value rd = new Kaplama_Return_Value{
                Birim_Id=temp.Birim_Id,
                Id=temp.Id,
                Kapmala_Text=temp.Kapmala_Text,
                Birim_Maliyet=temp.Birim_Maliyet,
                Birimler =(from x in _context.Birimlers
                        where x.Id==temp.Birim_Id
                        select x
                ).FirstOrDefault()
                
            };

            return rd;

        }

        public List<Kaplama_Return_Value> kaplama_Get_By_Text(Kaplama malzeme)
        {
            var temp = _context.kaplamas;
            var Değer = (from x in temp
                         join Birim in _context.Birimlers
                         on x.Birim_Id equals Birim.Id

                        
                         where x.Kapmala_Text.StartsWith(malzeme.Kapmala_Text) &&  x.Is_Deleted==0
                         select new
                         {
                            x.Birim_Id,
                            x.Id,
                            x.Kapmala_Text,
                            x.Birim_Maliyet,
                            Birim
                         }
            );
            IEnumerable<Kaplama_Return_Value> Return_değer = Değer.Select(o => new Kaplama_Return_Value
            {
                Birim_Id=o.Birim_Id,
                Id=o.Id,
                Kapmala_Text=o.Kapmala_Text,
                Birim_Maliyet=o.Birim_Maliyet,
                Birimler=o.Birim
                
            });
            return Return_değer.ToList();
        }
    }
}