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
using KaynakKod.Entities;

namespace qrmenu.Services
{
    public interface IRevizeService
    {
        Revize Revize_Add(Revize x);
        Revize Revize_Delete(Revize x);
        Revize Revize_Edit(Revize x);
        List<Revize> Revize_Get_All();
        Revize_Retrun_Value Revize_Get_By_Id(Revize y);
        List<Revize_Retrun_Value> Revize_Get_By_Parça_Id(Parça x);
    }
    public class RevizeService : IRevizeService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public RevizeService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Revize Revize_Add(Revize x)
        {
            _context.Revizes.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Revize Revize_Delete(Revize x)
        {
            var temp = _context.Revizes;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            _context.SaveChanges();

            return Değer;
        }

        public Revize Revize_Edit(Revize x)
        {
            throw new NotImplementedException();
        }

        public List<Revize> Revize_Get_All()
        {
            throw new NotImplementedException();
        }

        public Revize Get_Last_Revize_with_Parça_Id(Parça x)
        {
            var temp = _context.Revizes.Where(o => o.Parça_Id == x.Id).OrderByDescending(o => o.Id).FirstOrDefault();
            return temp;
        }

        public Toplam_Maliyet_Saved Toplam_Maliyet_Saved_Get_By_Revize_Id(Revize x)
        {
            var temp = _context.Toplam_Maliyet_Saveds.Where(o => o.Revize_Id == x.Id).FirstOrDefault();
            return temp;
        }


        public int Parçadaki_Son_Revizenin_Idsi(int Parça_Id)
        {

            return
            _context.Toplam_Maliyet_Saveds
            .Join(
                _context.Revizes,
                t => t.Revize_Id,
                r => r.Id,
                (t, r) => new
                {
                    t,
                    r
                }
            )
            .Join(
                _context.Parças,
                revize => revize.r.Parça_Id,
                parça => parça.Id,
                (revize, parça) => new
                {
                    revize,
                    parça
                }

            ).Where(o => o.parça.Id == Parça_Id).OrderByDescending(o => o.revize.r.Id).FirstOrDefault().revize.t.Id;
            //.Select(o=> o.revize.t.Malzeme_Karlı_Toplam+o.revize.t.İşçilik_Karlı_Toplam- o.revize.t.Fire_Maliyeti)

        }


        public Revize Parçadaki_SonRevize(int Parça_Id)
        {
            var Rt = _context.Revizes.Where(o => o.Parça_Id == Parça_Id && o.Is_Deleted == 0).OrderByDescending(o => o.Id).FirstOrDefault();

            //Console.WriteLine(Rt.Id);

            return Rt;

        }
        public decimal ToplamTakımMaliyeti(int Takım_Id)
        {
            decimal Toplam_Takım_Maliyeti = 0;
            var Takımdaki_Parçalar = _context.Parças.Where(o => o.Takım_Id == Takım_Id && o.Is_Deleted == 0).ToList();


            foreach (var item in Takımdaki_Parçalar)
            {





                var Son_Revize = Parçadaki_SonRevize(item.Id);
                var Toplam_Maliyet = _context.Toplam_Maliyet_Saveds.Where(o => o.Revize_Id == Son_Revize.Id && o.Is_Deleted == 0).FirstOrDefault();
                if (Toplam_Maliyet != null)
                {
                    Toplam_Takım_Maliyeti += (Toplam_Maliyet.Malzeme_Karlı_Toplam + Toplam_Maliyet.İşçilik_Karlı_Toplam - Toplam_Maliyet.Fire_Maliyeti) * item.Parça_Adeti;
                }

            }

            Console.WriteLine("---------------------------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("---------------------------");
            Console.WriteLine(Toplam_Takım_Maliyeti);

            return Toplam_Takım_Maliyeti;
        }










        public Revize_Retrun_Value Revize_Get_By_Id(Revize y)
        {
            var temp = (from x in _context.Revizes

                        join _Parça in _context.Parças
                        on x.Parça_Id equals _Parça.Id

                        join _Takım in _context.Takıms
                        on _Parça.Takım_Id equals _Takım.Id

                        join _İş in _context.İşs
                        on _Takım.İş_Id equals _İş.Id

                        where x.Id == y.Id && x.Is_Deleted == 0 && _Parça.Is_Deleted == 0
                        && _Takım.Is_Deleted == 0
                        && _İş.Is_Deleted == 0
                        select new
                        {
                            x.Id,
                            x.Is_Deleted,
                            x.Olusturlma_Tarihi,
                            x.Parça_Id,
                            _Parça,
                            _Takım,
                            _İş
                        }
            ).FirstOrDefault();
            Revize_Retrun_Value rv = new Revize_Retrun_Value
            {
                Id = temp.Id,
                Parça_Id = temp.Parça_Id,
                Is_Deleted = temp.Is_Deleted,
                Takım = temp._Takım,
                Parça = temp._Parça,
                İş = temp._İş,
                Olusturlma_Tarihi = temp.Olusturlma_Tarihi,
                Evrak_Maliyeti = //ToplamTakımMaliyeti(temp._Takım.Id)
                (
                    _context.Toplam_Maliyet_Saveds.Where(o => o.Revize_Id == temp.Id && o.Is_Deleted == 0)
                    .FirstOrDefault()
                )
                == null ? 0 :
                (
                    (
                        (
                            temp._Takım.Evrak_Maliyeti
                             /
                            (
                                ToplamTakımMaliyeti(temp._Takım.Id)
                            -
                            (
                                _context.Toplam_Maliyet_Saveds.Where(o => o.Revize_Id == Parçadaki_SonRevize(temp._Parça.Id).Id && o.Is_Deleted == 0)
                                .Select(o => o.İşçilik_Maliyeti + o.Malzeme_Karlı_Toplam - o.Fire_Maliyeti)
                                .FirstOrDefault() * temp._Parça.Parça_Adeti
                            )
                            +
                            (
                                _context.Toplam_Maliyet_Saveds.Where(o => o.Revize_Id == temp.Id && o.Is_Deleted == 0)
                                .Select(o => o.İşçilik_Maliyeti + o.Malzeme_Karlı_Toplam - o.Fire_Maliyeti)
                                .FirstOrDefault() * temp._Parça.Parça_Adeti
                            )
                            )


                        )
                    *
                    (
                        _context.Toplam_Maliyet_Saveds.Where(o => o.Revize_Id == temp.Id && o.Is_Deleted == 0)
                        .Select(o => o.İşçilik_Maliyeti + o.Malzeme_Karlı_Toplam - o.Fire_Maliyeti)
                        .FirstOrDefault() * temp._Parça.Parça_Adeti
                    )
                    )
                /
                (
                    temp._Parça.Parça_Adeti
                )

                )
                +
                (
                    _context.Toplam_Maliyet_Saveds.Where(o => o.Revize_Id == temp.Id && o.Is_Deleted == 0)
                    .Select(o => o.İşçilik_Maliyeti + o.Malzeme_Karlı_Toplam - o.Fire_Maliyeti)
                    .FirstOrDefault()
                )



            };

            return rv;
        }


        public List<Revize_Retrun_Value> Revize_Get_By_Parça_Id(Parça y)
        {
            var temp = (from x in _context.Revizes

                        join _Parça in _context.Parças
                        on x.Parça_Id equals _Parça.Id

                        where x.Parça_Id == y.Id && x.Is_Deleted == 0

                        select new
                        {
                            x.Id,
                        }
            );



            List<Revize_Retrun_Value> rt = new List<Revize_Retrun_Value>();

            if (temp.Count() > 0)
            {
                foreach (var item in temp)
                {
                    rt.Add(Revize_Get_By_Id(new Revize
                    {
                        Id = item.Id,
                    }));
                }
            }



            return (from x in rt.ToList()
                    where x.Is_Deleted == 0
                    select x
            ).ToList();
        }


    }
}