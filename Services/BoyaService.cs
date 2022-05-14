using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Authorization;
using WebApi.Models.Şehir_Request;
using qrmenu.Models.Uyeİşlemleri;
using qrmenu.Entities;
using KaynakKod.Entities.UretimMaliyeti.İşlemler;

namespace qrmenu.Services
{
    public interface IBoyaService
    {
        Boya_Türü Boya_Türü_Add(Boya_Türü x);
        Boya_Türü Boya_Türü_Delete(Boya_Türü x);
        Boya_Türü Boya_Türü_Edit(Boya_Türü x);
        List<Boya_Türü_Retrun_Value> Boya_Türü_Get_All();
        Boya_Türü_Retrun_Value Boya_Türü_Gey_By_Id(Boya_Türü x);



        Boya Boya_Add(Boya x);
        Boya Boya_Delete(Boya x);
        Boya Boya_Edit(Boya x);
        Boya_Return_Value Boya_Get_All();
        List<Boya_Return_Value> Boya_Get_By_Text(Boya x);
        List<Boya_Return_Value> Boya_Get_By_Boya_Türü_Id(Boya x);
        Boya_Return_Value Boya_Get_By_Id(Boya x);








    }
    public class BoyaService : IBoyaService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public BoyaService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Boya_Türü Boya_Türü_Add(Boya_Türü x)
        {
            _context.Boya_Türüs.Add(x);
            _context.SaveChanges();
            return x;

        }

        public Boya_Türü Boya_Türü_Delete(Boya_Türü x)
        {
            var temp = _context.Boya_Türüs;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            //_context.Büküm_KiloHesabı.Remove(Değer);
            _context.SaveChanges();

            return Değer;

        }

        public Boya_Türü Boya_Türü_Edit(Boya_Türü x)
        {
            var temp = _context.Boya_Türüs;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Boya_Türü_Text = x.Boya_Türü_Text;
            //_context.Büküm_KiloHesabı.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public List<Boya_Türü_Retrun_Value> Boya_Türü_Get_All()
        {
            var temp = (from x in _context.Boya_Türüs
                        where x.Is_Deleted == 0
                        select x
            );

            IEnumerable<Boya_Türü_Retrun_Value> rt = temp.Select(o => new Boya_Türü_Retrun_Value
            {
                Id = o.Id,
                Boya_Türü_Text = o.Boya_Türü_Text,
                Boyas = (from x in _context.Boyas
                         where x.Boya_Türü_Id == o.Id
                         select x
                ).Select(o => new Boya_Return_Value
                {
                    Id = o.Id,
                    Boya_Türü_Id = o.Boya_Türü_Id,
                    Boya_Text = o.Boya_Text,
                    Birim_Id = o.Birim_Id,
                    Birim = (from x in _context.Birimlers
                             where x.Id == o.Birim_Id
                             select x
                    ).FirstOrDefault(),
                    Birim_Fiyat = o.Birim_Fiyat,
                    Is_Deleted = o.Is_Deleted
                }).ToList()
            });


            return rt.ToList();

        }

        public Boya_Türü_Retrun_Value Boya_Türü_Gey_By_Id(Boya_Türü y)
        {
            var temp = (from x in _context.Boya_Türüs
                        where x.Is_Deleted != 1 && x.Id == y.Id
                        select x
            );

            IEnumerable<Boya_Türü_Retrun_Value> rt = temp.Select(o => new Boya_Türü_Retrun_Value
            {
                Id = o.Id,
                Boya_Türü_Text = o.Boya_Türü_Text,
                Boyas = (from x in _context.Boyas
                         where x.Boya_Türü_Id == o.Id
                         select x
                ).Select(o => new Boya_Return_Value
                {
                    Id = o.Id,
                    Boya_Türü_Id = o.Boya_Türü_Id,
                    Boya_Text = o.Boya_Text,
                    Birim_Id = o.Birim_Id,
                    Birim = (from x in _context.Birimlers
                             where x.Id == o.Birim_Id
                             select x
                    ).FirstOrDefault(),
                    Birim_Fiyat = o.Birim_Fiyat,
                    Is_Deleted = o.Is_Deleted
                }).ToList()
            });


            return rt.FirstOrDefault();
        }

        public Boya Boya_Add(Boya x)
        {
            _context.Boyas.Add(x);
            _context.SaveChanges();
            return x;

        }

        public Boya Boya_Delete(Boya x)
        {
            var temp = _context.Boyas;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            //_context.Büküm_KiloHesabı.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Boya Boya_Edit(Boya x)
        {
            var temp = _context.Boyas;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Birim_Fiyat = x.Birim_Fiyat;
            Değer.Boya_Text = x.Boya_Text;
            Değer.Birim_Id = x.Birim_Id;

            //_context.Büküm_KiloHesabı.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Boya_Return_Value Boya_Get_All()
        {
            throw new NotImplementedException();

        }

        public List<Boya_Return_Value> Boya_Get_By_Text(Boya y)
        {
            var temp = (from x in _context.Boyas
                        where x.Is_Deleted != 1 && x.Boya_Text.StartsWith(y.Boya_Text)
                        select x
            );

            IEnumerable<Boya_Return_Value> rt = temp.Select(o => new Boya_Return_Value
            {
                Id = o.Id,
                Boya_Türü_Id = o.Boya_Türü_Id,
                Boya_Text = o.Boya_Text,
                Birim_Id = o.Birim_Id,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                    ).FirstOrDefault(),
                Birim_Fiyat = o.Birim_Fiyat,
                Is_Deleted = o.Is_Deleted,
                Boya_Türü = (from x in _context.Boya_Türüs
                             where x.Id == o.Boya_Türü_Id
                             select x
                ).FirstOrDefault()
            });

            return rt.ToList();

        }

        public List<Boya_Return_Value> Boya_Get_By_Boya_Türü_Id(Boya y)
        {
            var temp = (from x in _context.Boyas
                        where x.Is_Deleted != 1 && x.Boya_Türü_Id == y.Boya_Türü_Id
                        select x
          );

            IEnumerable<Boya_Return_Value> rt = temp.Select(o => new Boya_Return_Value
            {
                Id = o.Id,
                Boya_Türü_Id = o.Boya_Türü_Id,
                Boya_Text = o.Boya_Text,
                Birim_Id = o.Birim_Id,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                    ).FirstOrDefault(),
                Birim_Fiyat = o.Birim_Fiyat,
                Is_Deleted = o.Is_Deleted,
                Boya_Türü = (from x in _context.Boya_Türüs
                             where x.Id == o.Boya_Türü_Id
                             select x
                ).FirstOrDefault()
            });

            return rt.ToList();
        }

        public Boya_Return_Value Boya_Get_By_Id(Boya y)
        {
            var temp = (from x in _context.Boyas
                        where x.Is_Deleted != 1 && x.Id == y.Id
                        select x
            );

            IEnumerable<Boya_Return_Value> rt = temp.Select(o => new Boya_Return_Value
            {
                Id = o.Id,
                Boya_Türü_Id = o.Boya_Türü_Id,
                Boya_Text = o.Boya_Text,
                Birim_Id = o.Birim_Id,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                    ).FirstOrDefault(),
                Birim_Fiyat = o.Birim_Fiyat,
                Is_Deleted = o.Is_Deleted,
                Boya_Türü = (from x in _context.Boya_Türüs
                             where x.Id == o.Boya_Türü_Id
                             select x
                ).FirstOrDefault()
            });

            return rt.FirstOrDefault();

        }
    }
}