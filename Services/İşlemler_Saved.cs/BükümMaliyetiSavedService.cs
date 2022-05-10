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
    public interface IBükümMaliyetiSavedService
    {

        Büküm_Maliyeti_Saved_Ağırlık Büküm_Maliyeti_Saved_Ağırlık_Add(Büküm_Maliyeti_Saved_Ağırlık x);
        Büküm_Maliyeti_Saved_Ağırlık Büküm_Maliyeti_Saved_Ağırlık_Delete(Büküm_Maliyeti_Saved_Ağırlık x);

        void Büküm_Maliyeti_Saved_Ağırlık_Delete_By_Revize_Id(Revize x);

        Büküm_Maliyeti_Saved_Ağırlık Büküm_Maliyeti_Saved_Ağırlık_Edit(Büküm_Maliyeti_Saved_Ağırlık x);
        List<Büküm_Maliyeti_Saved_Ağırlık> Büküm_Maliyeti_Saved_Ağırlık_Get_All();
        Büküm_Maliyeti_Saved_Ağırlık Büküm_Maliyeti_Saved_Ağırlık_Get_By_Id(Büküm_Maliyeti_Saved_Ağırlık x);
        List<Büküm_Maliyeti_Saved_Ağırlık> Büküm_Maliyeti_Saved_Ağırlık_Get_By_Parça_Id(Revize x);


        Büküm_Maliyeti_Saved_Adet Büküm_Maliyeti_Saved_Adet_Add(Büküm_Maliyeti_Saved_Adet x);
        Büküm_Maliyeti_Saved_Adet Büküm_Maliyeti_Saved_Adet_Delete(Büküm_Maliyeti_Saved_Adet x);

        void Büküm_Maliyeti_Saved_Adet_Delete_By_Revize_Id(Revize x);


        Büküm_Maliyeti_Saved_Adet Büküm_Maliyeti_Saved_Adet_Edit(Büküm_Maliyeti_Saved_Adet x);
        List<Büküm_Maliyeti_Saved_Adet> Büküm_Maliyeti_Saved_Adet_Get_All();
        Büküm_Maliyeti_Saved_Adet Büküm_Maliyeti_Saved_Adet_Get_By_Id(Büküm_Maliyeti_Saved_Adet x);
        List<Büküm_Maliyeti_Saved_Adet> Büküm_Maliyeti_Saved_Adet_Get_By_Parça_Id(Revize x);



        Büküm_Maliyeti_Saved_Uzunluk Büküm_Maliyeti_Saved_Uzunluk_Add(Büküm_Maliyeti_Saved_Uzunluk x);


        Büküm_Maliyeti_Saved_Uzunluk Büküm_Maliyeti_Saved_Uzunluk_Delete(Büküm_Maliyeti_Saved_Uzunluk x);
        void Büküm_Maliyeti_Saved_Uzunluk_Delete_By_Revize_Id(Revize x);



        Büküm_Maliyeti_Saved_Uzunluk Büküm_Maliyeti_Saved_Uzunluk_Edit(Büküm_Maliyeti_Saved_Uzunluk x);
        List<Büküm_Maliyeti_Saved_Uzunluk> Büküm_Maliyeti_Saved_Uzunluk_Get_All();
        Büküm_Maliyeti_Saved_Uzunluk Büküm_Maliyeti_Saved_Uzunluk_Get_By_Id(Büküm_Maliyeti_Saved_Uzunluk x);

        List<Büküm_Maliyeti_Saved_Uzunluk> Büküm_Maliyeti_Saved_Uzunluk_Get_By_Parça_Id(Revize x);





    }
    public class BükümMaliyetiSavedService : IBükümMaliyetiSavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public BükümMaliyetiSavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Büküm_Maliyeti_Saved_Ağırlık Büküm_Maliyeti_Saved_Ağırlık_Add(Büküm_Maliyeti_Saved_Ağırlık x)
        {
            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Ağırlıks;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Büküm_Maliyeti_Saved_Ağırlıks.Remove(Değer);
                _context.SaveChanges();
            }
            catch { }

            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Adets;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Büküm_Maliyeti_Saved_Adets.Remove(Değer);
                _context.SaveChanges();
            }
            catch { }
            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Uzunluks;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Büküm_Maliyeti_Saved_Uzunluks.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }




            _context.Büküm_Maliyeti_Saved_Ağırlıks.Add(x);
            _context.SaveChanges();
            return x;

        }

        public Büküm_Maliyeti_Saved_Ağırlık Büküm_Maliyeti_Saved_Ağırlık_Delete(Büküm_Maliyeti_Saved_Ağırlık x)
        {
            var temp = _context.Büküm_Maliyeti_Saved_Ağırlıks;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.Büküm_Maliyeti_Saved_Ağırlıks.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public void Büküm_Maliyeti_Saved_Ağırlık_Delete_By_Revize_Id(Revize y)
        {
            

            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Ağırlıks;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == y.Id);
                _context.Büküm_Maliyeti_Saved_Ağırlıks.Remove(Değer);
                _context.SaveChanges();

            }
            catch
            {

            }

            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Adets;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == y.Id);
                _context.Büküm_Maliyeti_Saved_Adets.Remove(Değer);
                _context.SaveChanges();

            }
            catch
            {

            }
            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Uzunluks;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == y.Id);
                _context.Büküm_Maliyeti_Saved_Uzunluks.Remove(Değer);
                _context.SaveChanges();

            }
            catch (System.Exception)
            {

            }




        }


        public Büküm_Maliyeti_Saved_Ağırlık Büküm_Maliyeti_Saved_Ağırlık_Edit(Büküm_Maliyeti_Saved_Ağırlık x)
        {
            var temp = _context.Büküm_Maliyeti_Saved_Ağırlıks;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Büküm_Maliyeti = x.Büküm_Maliyeti;
            Değer.Kat_Sayı = x.Kat_Sayı;
            Değer.Malzeme_Ağırlığı = x.Malzeme_Ağırlığı;
            Değer.Revize_Id = x.Revize_Id;

            _context.SaveChanges();

            return Değer;
        }

        public List<Büküm_Maliyeti_Saved_Ağırlık> Büküm_Maliyeti_Saved_Ağırlık_Get_All()
        {
            var temp = (from x in _context.Büküm_Maliyeti_Saved_Ağırlıks
                        select x
            );

            return temp.ToList();

        }

        public Büküm_Maliyeti_Saved_Ağırlık Büküm_Maliyeti_Saved_Ağırlık_Get_By_Id(Büküm_Maliyeti_Saved_Ağırlık y)
        {
            var temp = (from x in _context.Büküm_Maliyeti_Saved_Ağırlıks
                        where x.Id == y.Id

                        select x
             );

            return temp.FirstOrDefault();
        }


        public List<Büküm_Maliyeti_Saved_Ağırlık> Büküm_Maliyeti_Saved_Ağırlık_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Büküm_Maliyeti_Saved_Ağırlıks
                        where x.Revize_Id == y.Id

                        select x
                        );



            return temp.ToList();


        }









        public Büküm_Maliyeti_Saved_Adet Büküm_Maliyeti_Saved_Adet_Add(Büküm_Maliyeti_Saved_Adet x)
        {
            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Ağırlıks;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Büküm_Maliyeti_Saved_Ağırlıks.Remove(Değer);
                _context.SaveChanges();
            }
            catch { }

            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Adets;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Büküm_Maliyeti_Saved_Adets.Remove(Değer);
                _context.SaveChanges();
            }
            catch { }
            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Uzunluks;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Büküm_Maliyeti_Saved_Uzunluks.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }


            _context.Büküm_Maliyeti_Saved_Adets.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Büküm_Maliyeti_Saved_Adet Büküm_Maliyeti_Saved_Adet_Delete(Büküm_Maliyeti_Saved_Adet x)
        {
            var temp = _context.Büküm_Maliyeti_Saved_Adets;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Büküm_Maliyeti_Saved_Adet Büküm_Maliyeti_Saved_Adet_Edit(Büküm_Maliyeti_Saved_Adet x)
        {
            var temp = _context.Büküm_Maliyeti_Saved_Adets;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Büküm_Maliyeti = x.Büküm_Maliyeti;
            Değer.Kat_Sayı = x.Kat_Sayı;
            Değer.Büküm_Zorluğu_Id = x.Büküm_Zorluğu_Id;
            Değer.Revize_Id = x.Revize_Id;

            _context.SaveChanges();

            return Değer;
        }

        public List<Büküm_Maliyeti_Saved_Adet> Büküm_Maliyeti_Saved_Adet_Get_All()
        {
            var temp = (from x in _context.Büküm_Maliyeti_Saved_Adets
                        select x
            );

            return temp.ToList();
        }

        public Büküm_Maliyeti_Saved_Adet Büküm_Maliyeti_Saved_Adet_Get_By_Id(Büküm_Maliyeti_Saved_Adet y)
        {
            var temp = (from x in _context.Büküm_Maliyeti_Saved_Adets
                        where x.Id == y.Id
                        select x
             );

            return temp.FirstOrDefault();
        }

        public List<Büküm_Maliyeti_Saved_Adet> Büküm_Maliyeti_Saved_Adet_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Büküm_Maliyeti_Saved_Adets
                        where x.Revize_Id == y.Id
                        select x
             );

            return temp.ToList();
        }










        public Büküm_Maliyeti_Saved_Uzunluk Büküm_Maliyeti_Saved_Uzunluk_Add(Büküm_Maliyeti_Saved_Uzunluk x)
        {

            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Ağırlıks;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Büküm_Maliyeti_Saved_Ağırlıks.Remove(Değer);
                _context.SaveChanges();
            }
            catch { }

            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Adets;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Büküm_Maliyeti_Saved_Adets.Remove(Değer);
                _context.SaveChanges();
            }
            catch { }
            try
            {
                var temp = _context.Büküm_Maliyeti_Saved_Uzunluks;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Büküm_Maliyeti_Saved_Uzunluks.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }


            _context.Büküm_Maliyeti_Saved_Uzunluks.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Büküm_Maliyeti_Saved_Uzunluk Büküm_Maliyeti_Saved_Uzunluk_Delete(Büküm_Maliyeti_Saved_Uzunluk x)
        {
            var temp = _context.Büküm_Maliyeti_Saved_Uzunluks;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Büküm_Maliyeti_Saved_Uzunluk Büküm_Maliyeti_Saved_Uzunluk_Edit(Büküm_Maliyeti_Saved_Uzunluk x)
        {
            var temp = _context.Büküm_Maliyeti_Saved_Uzunluks;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Büküm_Maliyeti = x.Büküm_Maliyeti;
            Değer.Büküm_Zorluğu_Id = x.Büküm_Zorluğu_Id;
            Değer.Büküm_Zorluğu_Katsayı = x.Büküm_Zorluğu_Katsayı;
            Değer.Hesap_Çeşiti_Id = x.Hesap_Çeşiti_Id;
            Değer.Malzeme_Boyu_Katsayı = x.Malzeme_Boyu_Katsayı;
            Değer.Malzeme_Eni = x.Malzeme_Eni;


            _context.SaveChanges();

            return Değer;
        }

        public List<Büküm_Maliyeti_Saved_Uzunluk> Büküm_Maliyeti_Saved_Uzunluk_Get_All()
        {
            var temp = (from x in _context.Büküm_Maliyeti_Saved_Uzunluks
                        select x
                );

            return temp.ToList();
        }

        public Büküm_Maliyeti_Saved_Uzunluk Büküm_Maliyeti_Saved_Uzunluk_Get_By_Id(Büküm_Maliyeti_Saved_Uzunluk y)
        {

            var temp = (from x in _context.Büküm_Maliyeti_Saved_Uzunluks
                        where x.Id == y.Id
                        select x
              );

            return temp.FirstOrDefault();

        }

        public List<Büküm_Maliyeti_Saved_Uzunluk> Büküm_Maliyeti_Saved_Uzunluk_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Büküm_Maliyeti_Saved_Uzunluks
                        where x.Revize_Id == y.Id
                        select x
              );

            return temp.ToList();
        }


        public void Büküm_Maliyeti_Saved_Adet_Delete_By_Revize_Id(Revize x)
        {
            throw new NotImplementedException();
        }

        public void Büküm_Maliyeti_Saved_Uzunluk_Delete_By_Revize_Id(Revize x)
        {
            throw new NotImplementedException();
        }
    }
}