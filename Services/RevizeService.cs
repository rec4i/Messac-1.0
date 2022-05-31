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
            //_context.Büküm_KiloHesabı.Remove(Değer);
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

        public decimal Parça_Get_By_Takım_Id(Takım y, Parça z, int r)
        {


            var temp = (from x in _context.Parças
                        where y.Id == x.Takım_Id && x.Is_Deleted == 0
                        select x
            );

            IEnumerable<Parça_Retrun_Value> rt = temp.Select(o => new Parça_Retrun_Value
            {

                Birim_Maliyet =

                (from x in _context.Toplam_Maliyet_Saveds

                 join _revises in _context.Revizes
                 on x.Revize_Id equals _revises.Id

                 orderby _revises.Id descending

                 where _revises.Parça_Id == o.Id && _revises.Is_Deleted == 0 && x.Is_Deleted == 0

                 select x


                ).FirstOrDefault().Revize_Id

                == r ||

                (from x in _context.Toplam_Maliyet_Saveds

                 join _revises in _context.Revizes
                 on x.Revize_Id equals _revises.Id

                 orderby _revises.Id descending

                 where _revises.Parça_Id == o.Id && _revises.Is_Deleted == 0 && x.Is_Deleted == 0

                 select _revises


                ).FirstOrDefault().Parça_Id == z.Id

                ?



                 0



                 :


                (from x in _context.Toplam_Maliyet_Saveds

                 join _revises in _context.Revizes
                 on x.Revize_Id equals _revises.Id

                 orderby _revises.Id descending
                 where _revises.Parça_Id == o.Id && _revises.Is_Deleted == 0 && x.Is_Deleted == 0

                 select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)

                ).FirstOrDefault() * o.Parça_Adeti


                ,




            });

            decimal Toplam_Malzeme_Maliyeti = rt.Select(o => o.Birim_Maliyet).Sum();



            return Toplam_Malzeme_Maliyeti;
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

                        where x.Id == y.Id && x.Is_Deleted == 0

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
                Evrak_Maliyeti =
                  (((
                       (
                           (from x in _context.Toplam_Maliyet_Saveds

                            join _revises in _context.Revizes
                            on x.Revize_Id equals _revises.Id

                            where _revises.Id == temp.Id && _revises.Is_Deleted == 0 && x.Is_Deleted == 0

                            select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                           ).FirstOrDefault() *
                           (from x in _context.Parças
                            where x.Id == temp.Parça_Id
                            select x.Parça_Adeti

                       ).FirstOrDefault()
                       )

                       /

                   (
                     Parça_Get_By_Takım_Id(temp._Takım, temp._Parça, temp.Id)
                        +
                      (from x in _context.Toplam_Maliyet_Saveds

                       join _revises in _context.Revizes
                       on x.Revize_Id equals _revises.Id

                       where _revises.Id == temp.Id && _revises.Is_Deleted == 0 && x.Is_Deleted == 0

                       select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                                ).FirstOrDefault()
                    *
                    (from x in _context.Parças
                     where x.Id == temp._Parça.Id
                     select x.Parça_Adeti
                    ).FirstOrDefault()

                    )

                    )
                        *
                      (from x in _context.Takıms

                       join _Parça in _context.Parças
                       on x.Id equals _Parça.Takım_Id

                       where _Parça.Id == temp._Parça.Id && x.Is_Deleted == 0

                       select x.Evrak_Maliyeti
                ).FirstOrDefault())
                /
                    (from x in _context.Parças
                     where x.Id == temp._Parça.Id
                     select x.Parça_Adeti
                    ).FirstOrDefault()) +

(from x in _context.Toplam_Maliyet_Saveds

 join _revises in _context.Revizes
 on x.Revize_Id equals _revises.Id

 where _revises.Id == temp.Id && _revises.Is_Deleted == 0 && x.Is_Deleted == 0

 select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                    ).FirstOrDefault()









                // +
                // (from x in _context.Toplam_Maliyet_Saveds

                //  join _revises in _context.Revizes
                //  on x.Revize_Id equals _revises.Id

                //  where _revises.Id == temp.Id && _revises.Is_Deleted == 0 && x.Is_Deleted == 0

                //  select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                // ).FirstOrDefault() *
                //     (from x in _context.Parças
                //      where x.Id == temp.Parça_Id
                //      select x.Parça_Adeti

                //                     ).FirstOrDefault()

                //     (from x in _context.Takıms

                //      join _Parça in _context.Parças
                //      on x.Id equals _Parça.Takım_Id

                //      where _Parça.Id == temp._Parça.Id && x.Is_Deleted == 0

                //      select x.Evrak_Maliyeti
                // ).FirstOrDefault()






                // (
                //        Parça_Get_By_Takım_Id(temp._Takım, temp._Parça, temp.Id) 

                //        +
                //     (from x in _context.Toplam_Maliyet_Saveds

                //      join _revises in _context.Revizes
                //      on x.Revize_Id equals _revises.Id

                //      where _revises.Id == temp.Id && _revises.Is_Deleted == 0 && x.Is_Deleted == 0

                //      select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                //     ).FirstOrDefault()
                // ) == 0 ? 0 :

                // ((
                //     (from x in _context.Toplam_Maliyet_Saveds

                //      join _revises in _context.Revizes
                //      on x.Revize_Id equals _revises.Id

                //      where _revises.Id == temp.Id && _revises.Is_Deleted == 0 && x.Is_Deleted == 0

                //      select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                //     ).FirstOrDefault() * (from x in _context.Parças
                //                           where x.Id == temp.Parça_Id
                //                           select x.Parça_Adeti

                // ).FirstOrDefault()
                // )

                // /
                // (
                //     Parça_Get_By_Takım_Id(temp._Takım, temp._Parça, temp.Id) 
                //        +
                //     (from x in _context.Toplam_Maliyet_Saveds

                //      join _revises in _context.Revizes
                //      on x.Revize_Id equals _revises.Id

                //      where _revises.Id == temp.Id && _revises.Is_Deleted == 0 && x.Is_Deleted == 0

                //      select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                //     ).FirstOrDefault()
                // )
                // *

                // (from x in _context.Takıms

                //  join _Parça in _context.Parças
                //  on x.Id equals _Parça.Takım_Id

                //  where _Parça.Id == temp._Parça.Id && x.Is_Deleted == 0

                //  select x.Evrak_Maliyeti
                // ).FirstOrDefault())

                // +

                // (from x in _context.Toplam_Maliyet_Saveds

                //  join _revises in _context.Revizes
                //  on x.Revize_Id equals _revises.Id

                //  where _revises.Id == temp.Id && _revises.Is_Deleted == 0 && x.Is_Deleted == 0

                //  select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                //     ).FirstOrDefault()



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