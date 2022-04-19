using System.Collections.Generic;
using System.Linq;
using KaynakKod.Entities;
using KaynakKod.Entities.UretimMaliyeti.İşlemler;
using Microsoft.Extensions.Options;
using qrmenu.Entities;
using WebApi.Authorization;
using WebApi.Helpers;

namespace KaynakKod.Services
{
    public interface IDıs_OperasyonService
    {
        DısOperasyon DısOperasyon_Add(DısOperasyon x);

        DısOperasyon DısOperasyon_Delete(DısOperasyon x);

        DısOperasyon DısOperasyon_Edit(DısOperasyon x);

        List<DısOperasyon_Return_Valur> DısOperasyon_Get_All();

        DısOperasyon_Return_Valur DısOperasyon_Get_By_Id(DısOperasyon x);

        List<DısOperasyon_Return_Valur> DısOperasyon_Get_By_text(DısOperasyon x);

    }
    public class Dıs_OperasyonService : IDıs_OperasyonService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public Dıs_OperasyonService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public DısOperasyon DısOperasyon_Add(DısOperasyon x)
        {
            _context.DısOperasyons.Add(x);
            _context.SaveChanges();
            return x;
        }

        public DısOperasyon DısOperasyon_Delete(DısOperasyon x)
        {
            var temp = _context.DısOperasyons;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.DısOperasyons.Remove(Değer);
            _context.SaveChanges();

            return Değer;

        }

        public DısOperasyon DısOperasyon_Edit(DısOperasyon x)
        {
            var temp = _context.DısOperasyons;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Operasyon_Adı = x.Operasyon_Adı;
            Değer.Operasyon_Maliyeti = x.Operasyon_Maliyeti;
            Değer.Birim_Id = x.Birim_Id;
            _context.SaveChanges();

            return Değer;
        }

        public List<DısOperasyon_Return_Valur> DısOperasyon_Get_All()
        {
            var temp = (from x in _context.DısOperasyons
                        select x
            );
            IEnumerable<DısOperasyon_Return_Valur> rd = temp.Select(o => new DısOperasyon_Return_Valur
            {
                Id = o.Id,
                Operasyon_Adı = o.Operasyon_Adı,
                Operasyon_Maliyeti = o.Operasyon_Maliyeti,
                Birim_Id = o.Birim_Id,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                 ).FirstOrDefault()
            });

            return rd.ToList();
        }

        public DısOperasyon_Return_Valur DısOperasyon_Get_By_Id(DısOperasyon y)
        {
            var temp = (from x in _context.DısOperasyons
                        where x.Id == y.Id
                        select x
            ).FirstOrDefault();

            DısOperasyon_Return_Valur rv= new DısOperasyon_Return_Valur {
                Id=temp.Id,
                Operasyon_Adı=temp.Operasyon_Adı,
                Operasyon_Maliyeti=temp.Operasyon_Maliyeti,
                Birim_Id=temp.Birim_Id,
                Birim=(from x in _context.Birimlers
                        where x.Id==temp.Birim_Id
                        select x
                ).FirstOrDefault()
                
            };

            return rv;
        }

        public List<DısOperasyon_Return_Valur> DısOperasyon_Get_By_text(DısOperasyon malzeme)
        {
            var temp = _context.DısOperasyons;
            var Değer = (from x in temp


                         where x.Operasyon_Adı.StartsWith(malzeme.Operasyon_Adı)
                         select new
                         {
                             x.Operasyon_Adı,
                             x.Id,
                             x.Operasyon_Maliyeti,
                             x.Birim_Id,
                             
                         }
            );
            IEnumerable<DısOperasyon_Return_Valur> Return_değer = Değer.Select(o => new DısOperasyon_Return_Valur
            {
                Operasyon_Adı = o.Operasyon_Adı,
                Operasyon_Maliyeti = o.Operasyon_Maliyeti,
                Id = o.Id,
                Birim_Id=o.Birim_Id,
                Birim=( from x in _context.Birimlers
                        where x.Id==o.Birim_Id
                        select x
                ).FirstOrDefault()

            });
            return Return_değer.ToList();
        }
    }
}