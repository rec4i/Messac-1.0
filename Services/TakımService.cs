using System;
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
    public interface ITakımService
    {
        Takım Takım_Add(Takım x);

        Takım Takım_Delete(Takım x);

        Takım Takım_Edit(Takım x);

        List<Takım_Return_Value> Takım_Get_All();

        Takım_Return_Value Takım_Get_By_Id(Takım x);

        List<Takım_Return_Value> Takım_Get_By_Text(Takım x);

        List<Takım_Return_Value> Takım_Get_By_İş_Id(İş x);

        Takım_Return_Value Takım_Set_Evrak_Maliyteti(Takım x);




    }
    public class TakımService : ITakımService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public TakımService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Takım Takım_Add(Takım x)
        {
            _context.Takıms.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Takım Takım_Delete(Takım x)
        {
            var temp = _context.Takıms;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.kaplamas.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Takım Takım_Edit(Takım x)
        {
            var temp = _context.Takıms;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Takım_Adı = x.Takım_Adı;
            _context.SaveChanges();

            return Değer;
        }

        public List<Takım_Return_Value> Takım_Get_All()
        {
            var temp = (from x in _context.Takıms
                        where x.Is_Deleted == 0
                        select new
                        {
                            x.Id,
                            x.İş_Id,
                            x.Olusturlma_Tarihi,
                            x.Takım_Adı
                        }
            );

            IEnumerable<Takım_Return_Value> rv = temp.Select(o => new Takım_Return_Value
            {
                Id = o.Id,
                İş_Id = o.İş_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Takım_Adı = o.Takım_Adı,
                İş = (from x in _context.İşs
                      where x.Id == o.İş_Id
                      select x
             ).FirstOrDefault()


            });
            return rv.ToList();
        }

        public Takım_Return_Value Takım_Get_By_Id(Takım y)
        {
            var temp = (from x in _context.Takıms
                        where x.Is_Deleted == 0 && y.Id == x.Id
                        select new
                        {
                            x.Id,
                            x.İş_Id,
                            x.Olusturlma_Tarihi,
                            x.Takım_Adı
                        }
            ).FirstOrDefault();

            Takım_Return_Value rv = new Takım_Return_Value
            {

                Id = temp.Id,
                İş_Id = temp.İş_Id,
                Olusturlma_Tarihi = temp.Olusturlma_Tarihi,
                Takım_Adı = temp.Takım_Adı,
                İş = (from x in _context.İşs
                      where x.Id == temp.İş_Id
                      select x
                    ).FirstOrDefault()

            };


            return rv;
        }

        public List<Takım_Return_Value> Takım_Get_By_Text(Takım y)
        {
            var temp = (from x in _context.Takıms
                        where x.Is_Deleted == 0 && x.Takım_Adı.StartsWith(y.Takım_Adı)
                        select new
                        {
                            x.Id,
                            x.İş_Id,
                            x.Olusturlma_Tarihi,
                            x.Evrak_Maliyeti,

                            x.Takım_Adı
                        }
         );

            IEnumerable<Takım_Return_Value> rv = temp.Select(o => new Takım_Return_Value
            {
                Id = o.Id,
                İş_Id = o.İş_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Takım_Adı = o.Takım_Adı,
                Evrak_Maliyeti = o.Evrak_Maliyeti,
                Toplam_Maliyet = (from x in _context.Toplam_Maliyet_Saveds

                                  join _Parça in _context.Parças
                                  on o.Id equals _Parça.Takım_Id


                                  join _revises in _context.Revizes
                                  on x.Revize_Id equals _revises.Id


                                  orderby _revises.Id descending
                                  where _revises.Parça_Id == _Parça.Id

                                  select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                ).FirstOrDefault(),
                İş = (from x in _context.İşs
                      where x.Id == o.İş_Id
                      select x
             ).FirstOrDefault()


            });
            return rv.ToList();
        }
        public List<Parça_Retrun_Value> Parça_Get_By_Takım_Id(Takım y)
        {


            var temp = (from x in _context.Parças
                        where y.Id == x.Takım_Id && x.Is_Deleted == 0
                        select x
            );

            IEnumerable<Parça_Retrun_Value> rt = temp.Select(o => new Parça_Retrun_Value
            {
                Id = o.Id,
                Parça_Adı = o.Parça_Adı,
                Parça_Adeti = o.Parça_Adeti,
                Birim_Maliyet = (from x in _context.Toplam_Maliyet_Saveds

                                 join _revises in _context.Revizes
                                 on x.Revize_Id equals _revises.Id

                                 orderby _revises.Id descending
                                 where _revises.Parça_Id == o.Id

                                 select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                ).FirstOrDefault(),

                Evrak_Maliyeti =
                (from x in _context.Toplam_Maliyet_Saveds

                 join _revises in _context.Revizes
                 on x.Revize_Id equals _revises.Id
                 orderby _revises.Id descending
                 where _revises.Parça_Id == o.Id

                 select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                ).FirstOrDefault()

                <= 0 ? 0 :






                (from x in _context.Toplam_Maliyet_Saveds

                 join _revises in _context.Revizes
                 on x.Revize_Id equals _revises.Id

                 orderby _revises.Id descending
                 where _revises.Parça_Id == o.Id


                 select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                ).FirstOrDefault() * o.Parça_Adeti



                ,



                Toplam_Maliyet =
                (from x in _context.Parças
                 where x.Takım_Id == o.Takım_Id
                 select x.Parça_Adeti

                ).Sum() == 0 ? 0 :
                (from x in _context.Takıms
                 where o.Takım_Id == x.Id
                 select x.Evrak_Maliyeti
                ).FirstOrDefault() / (from x in _context.Parças
                                      where x.Takım_Id == o.Takım_Id
                                      select x.Parça_Adeti

                ).Sum() * o.Parça_Adeti + ((from x in _context.Toplam_Maliyet_Saveds

                                            join _revises in _context.Revizes
                                            on x.Revize_Id equals _revises.Id
                                            orderby _revises.Id descending
                                            where _revises.Parça_Id == o.Id

                                            select (x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti)
                ).FirstOrDefault() * o.Parça_Adeti),


                Takım_Id = o.Takım_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi


            });




            decimal Toplam_Malzeme_Maliyeti = rt.Select(o => o.Birim_Maliyet).Sum();
            IEnumerable<Parça_Retrun_Value> rt_1 = rt.Select(o => new Parça_Retrun_Value
            {
                Id = o.Id,
                Parça_Adı = o.Parça_Adı,
                Parça_Adeti = o.Parça_Adeti,
                Birim_Maliyet =
                Toplam_Malzeme_Maliyeti == 0 ? 0 :
                (((o.Birim_Maliyet / Toplam_Malzeme_Maliyeti) *
                (from x in _context.Takıms
                 where o.Takım_Id == x.Id
                 select x.Evrak_Maliyeti
                ).FirstOrDefault()) / o.Parça_Adeti) + o.Birim_Maliyet

                 ,


                Evrak_Maliyeti = Toplam_Malzeme_Maliyeti == 0 ? 0 :

                ((((o.Birim_Maliyet / Toplam_Malzeme_Maliyeti) *
                (from x in _context.Takıms
                 where o.Takım_Id == x.Id
                 select x.Evrak_Maliyeti
                ).FirstOrDefault()) / o.Parça_Adeti) + o.Birim_Maliyet) * o.Parça_Adeti
                ,




                Toplam_Maliyet =
                Toplam_Malzeme_Maliyeti == 0 ? 0 :
                Convert.ToDecimal(((((o.Birim_Maliyet / Toplam_Malzeme_Maliyeti) *
                (from x in _context.Takıms
                 where o.Takım_Id == x.Id
                 select x.Evrak_Maliyeti
                ).FirstOrDefault()) / o.Parça_Adeti) + o.Birim_Maliyet).ToString("F")) * o.Parça_Adeti,


                Takım_Id = o.Takım_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi
            });

            return rt_1.ToList();
        }
        public List<Takım_Return_Value> Takım_Get_By_İş_Id(İş y)
        {

            var temp = (from x in _context.Takıms
                        where x.Is_Deleted == 0 && x.İş_Id == y.Id
                        select new
                        {
                            x.Id,
                            x.İş_Id,
                            x.Olusturlma_Tarihi,
                            x.Evrak_Maliyeti,
                            x.Takım_Adı
                        }
            );

            IEnumerable<Takım_Return_Value> rv = temp.Select(o => new Takım_Return_Value
            {
                Id = o.Id,
                İş_Id = o.İş_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Takım_Adı = o.Takım_Adı,
                Evrak_Maliyeti = o.Evrak_Maliyeti


                ,



                İş = (from x in _context.İşs
                      where x.Id == o.İş_Id
                      select x
                    ).FirstOrDefault()

            });

            List<Takım_Return_Value> Rv_1 = new List<Takım_Return_Value>();


            foreach (var item in rv)
            {
                Takım_Return_Value add_ = new Takım_Return_Value
                {
                    Id = item.Id,
                    İş_Id = item.İş_Id,
                    Olusturlma_Tarihi = item.Olusturlma_Tarihi,
                    Takım_Adı = item.Takım_Adı,
                    Evrak_Maliyeti = item.Evrak_Maliyeti,
                    İş = item.İş,
                    Toplam_Maliyet = Parça_Get_By_Takım_Id(new Takım
                    {
                        Id = item.Id
                    }).Select(o => o.Birim_Maliyet).Sum()

                };

                Rv_1.Add(add_);
            }



            return Rv_1.ToList();

        }

        public Takım_Return_Value Takım_Set_Evrak_Maliyteti(Takım y)
        {
            var temp_ = _context.Takıms;
            var Değer = temp_.FirstOrDefault(o => o.Id == y.Id);
            Değer.Evrak_Maliyeti = y.Evrak_Maliyeti;



            _context.SaveChanges();

            var temp = (from x in _context.Takıms
                        where x.Is_Deleted == 0 && y.Id == x.Id
                        select new
                        {
                            x.Id,
                            x.İş_Id,
                            x.Olusturlma_Tarihi,
                            x.Evrak_Maliyeti,
                            x.Takım_Adı
                        }
              );

          
            IEnumerable<Takım_Return_Value> rv = temp.Select(o => new Takım_Return_Value
            {
                Id = o.Id,
                İş_Id = o.İş_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Takım_Adı = o.Takım_Adı,
                Evrak_Maliyeti = o.Evrak_Maliyeti


                ,



                İş = (from x in _context.İşs
                      where x.Id == o.İş_Id
                      select x
                    ).FirstOrDefault()

            });

            List<Takım_Return_Value> Rv_1 = new List<Takım_Return_Value>();


            foreach (var item in rv)
            {
                Takım_Return_Value add_ = new Takım_Return_Value
                {
                    Id = item.Id,
                    İş_Id = item.İş_Id,
                    Olusturlma_Tarihi = item.Olusturlma_Tarihi,
                    Takım_Adı = item.Takım_Adı,
                    Evrak_Maliyeti = item.Evrak_Maliyeti,
                    İş = item.İş,
                    Toplam_Maliyet = Parça_Get_By_Takım_Id(new Takım
                    {
                        Id = item.Id
                    }).Select(o => o.Birim_Maliyet).Sum()

                };

                Rv_1.Add(add_);
            }



            return Rv_1.FirstOrDefault();



        }
    }
}