using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.DTO;

namespace YesilEvAppYigit.DAL.Concerete
{
    public class ReportingDAL
    {
        public List<KullaniciAdminRaporDTO> HowManyUsersAndAdminsAreInDatabase()
        {
            List<KullaniciAdminRaporDTO> dto = new List<KullaniciAdminRaporDTO>();

            try
            {
                using (YesilEvDbContext db = new YesilEvDbContext())
                {
                    var obj = new KullaniciAdminRaporDTO
                    {
                        Admin = db.Users.Where(p => p.RoleID == 1).Count(),
                        Kullanici = db.Users.Where(p => p.RoleID == 2).Count()
                    };
                    dto.Add(obj);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return dto;
        }

        public List<KullaniciUrunDTO> KullaniciEkledikleriUrunRapor()
        {
            return new ReportingDAL().HowManyProductDidEachUserAdd().OrderByDescending(a => a.UrunAdet).Take(3).ToList();
        }
        public List<UrunUrunIcerikAdetDTO> UrunUrunIcerikAdetRapor()
        {
            List<UrunUrunIcerikAdetDTO> list = null;
            using (YesilEvDbContext db = new YesilEvDbContext())
            {
                list = (from u in db.Products
                        join uui in db.UrunAllergens on u.UrunID equals uui.UrunID
                        group new { u.UrunAdi, uui } by u.UrunID into grp
                        select new UrunUrunIcerikAdetDTO()
                        {
                            UrunAdi = grp.Select(x => x.UrunAdi).FirstOrDefault(),
                            IcerikAdet = grp.Count()
                        }).ToList();
            }

            return list;
        }

        public List<KullaniciUrunDTO> HowManyProductDidEachUserAdd()
        {
            List<KullaniciUrunDTO> list = null;
            using (YesilEvDbContext db = new YesilEvDbContext())
            {
                list = (from u in db.Products
                        join uui in db.Users on u.AddedBy equals uui.UserID
                        group new { uui.Username, u.UrunID } by uui.Username into grp
                        select new KullaniciUrunDTO()
                        {
                            KullaniciAdi = grp.Select(x => x.Username).FirstOrDefault(),
                            UrunAdet = grp.Count()
                        }).ToList();
            }

            return list;
        }
        public List<AlerjenFavoriDTO> HowManyProductsAreInFavoriteListsWithLeastRiskedAllergen()
        {
            List<AlerjenFavoriDTO> dto = null;
            using (YesilEvDbContext db = new YesilEvDbContext())
            {
                var ulf = db.UrunAllergens.Join(db.Allergens, a => a.AllergenID, b => b.AlerjenID, (a, b) => new
                {
                    AllergenID = a.AllergenID,
                    AllergenAdi = b.AlerjenAdi,
                    RiskID = b.RiskID,
                    UrunID = a.UrunID
                }).Join(db.Products, a => a.UrunID, b => b.UrunID, (a, b) => new
                {
                    AllergenID = a.AllergenID,
                    AllergenAdi = a.AllergenAdi,
                    RiskID = a.RiskID,
                    Urun = b
                }).Join(db.FavoriUruns, a => a.Urun.UrunID, b => b.UrunID, (a, b) => new UrunRiskFavoriDTO
                {
                    AllergenID = a.AllergenID,
                    AllergenAdi = a.AllergenAdi,
                    RiskID = a.RiskID,
                    UrunID = b.UrunID,
                    FavoriID = b.FavoriID
                }).Where(a => a.RiskID == 1).ToList();
                dto = (from u in ulf
                       group new { u } by u.AllergenAdi into grp
                       select new AlerjenFavoriDTO()
                       {
                           AllergenAdi = grp.Select(x => x.u.AllergenAdi).FirstOrDefault(),
                           FavoriSayisi = grp.Count()
                       }).ToList();

            }
            return dto;
        }

        public List<OnaylanmamisUrunDTO> HowManyProductsAreAddedThisMonthAndNotApprovedByAdmin()
        {
            List<OnaylanmamisUrunDTO> list = null;
            using (YesilEvDbContext db = new YesilEvDbContext())
            {
                list = db.Products.Where(a => a.IsApproved == false && a.DateAdded.Month == DateTime.Now.Month).Select(a => new OnaylanmamisUrunDTO
                {
                    UrunAdi = a.UrunAdi,
                    EklenmeTarihi = a.DateAdded,
                    Ekleyen = a.AddedBy
                }).ToList();
            }
            return list;
        }

        public List<AlerjenRiskDTO> WhichAllergensHaveTheHighestRiskLevel()
        {
            List<AlerjenRiskDTO> dto = null;
            using (YesilEvDbContext db = new YesilEvDbContext())
            {
                dto = db.UrunAllergens.Join(db.Allergens, a => a.AllergenID, b => b.AlerjenID, (a, b) => new
                {
                    AllergenID = a.AllergenID,
                    AllergenAdi = b.AlerjenAdi,
                    RiskID = b.RiskID,
                    UrunID = a.UrunID
                }).Join(db.Risks, a => a.RiskID, b => b.RiskID, (a, b) => new AlerjenRiskDTO
                {
                    AllergenAdi = a.AllergenAdi,
                    Risk = b.RiskTipi,
                    Derecesi = b.RiskID
                }).Distinct().Where(a => a.Derecesi > 3).ToList();

            }
            return dto;
        }

        public List<AlerjenUrunDTO> UrunveAlerjenleriGetir()
        {
            List<AlerjenUrunDTO> dto = new List<AlerjenUrunDTO>();
            using (YesilEvDbContext db = new YesilEvDbContext())
            {
                var uaList = (from ua in db.UrunAllergens
                              join a in db.Allergens on ua.AllergenID equals a.AlerjenID
                              join p in db.Products on ua.UrunID equals p.UrunID
                              select new UrunAllergenDTO()
                              {
                                  UrunID = p.UrunID,
                                  AllergenID = a.AlerjenID,
                                  ID = ua.ID
                              }).ToList();
                uaList.ForEach(a => a.Allergen = new UrunAllergenDAL().getAllergen(a.AllergenID));
                uaList.ForEach(a => a.Product = new ProductDAL().UrunGetir(a.UrunID));

                dto = (from u in uaList
                       orderby u.Allergen.AlerjenAdi ascending
                       select new AlerjenUrunDTO()
                       {
                           AlerjenAdi = u.Allergen.AlerjenAdi,
                           UrunAdi = u.Product.UrunAdi
                       }).ToList();
            }
            return dto;
        }

        public List<EnYuksekFavoriUrunDTO> EnCokFavoriUrunRapor()
        {
            List<EnYuksekFavoriUrunDTO> dto = null;
            using (YesilEvDbContext db = new YesilEvDbContext())
            {
                var ulf = db.Products.Join(db.FavoriUruns, a => a.UrunID, b => b.UrunID, (a, b) => new
                {
                    UrunAdi = a.UrunAdi,
                    FavoriSayisi = b.FavoriID
                }).ToList();
                dto = (from u in ulf
                       group new { u } by u.UrunAdi into grp
                       select new EnYuksekFavoriUrunDTO()
                       {
                           UrunAdi = grp.Select(x => x.u.UrunAdi).FirstOrDefault(),
                           FavoriSayisi = grp.Count()
                       }).OrderByDescending(a => a.FavoriSayisi).ToList();
            }
            return dto;
        }

        public List<EnYuksekFavoriUrunDTO> EnCokFavori3UrunRapor()
        {
            return new ReportingDAL().EnCokFavoriUrunRapor().Take(3).ToList();
        }

        public List<KullaniciListeSayisiDTO> KullaniciListeSayisiRapor()
        {
            List<KullaniciListeSayisiDTO> dto = null;
            using (YesilEvDbContext db = new YesilEvDbContext())
            {
                var temp = (from u in db.Users
                            join f in db.Favorites on u.UserID equals f.UserID
                            join fu in db.FavoriUruns on f.ListID equals fu.FavoriID
                            group new { u, f, fu } by u.UserID into grf
                            select new
                            {
                                KullaniciAdi = grf.Select(a => a.u.Username).FirstOrDefault(),
                                KullaniciID = grf.Select(a => a.u.UserID).FirstOrDefault(),
                                FavoriUrunSayisi = grf.Where(grp => grp.u.UserID == grp.f.UserID).Select(a => a.fu.UrunID).Count()
                            }).ToList();
                temp.GroupBy(a => a.KullaniciAdi).ToList();
                var temp2 = (from t in temp
                             join b in db.Blacklists on t.KullaniciID equals b.UserID
                             join ba in db.BlacklistAllergens on b.ListID equals ba.BlacklistID
                             group new { t, b, ba } by ba.BlacklistID into grb
                             select new
                             {
                                 KullaniciAdi = grb.Select(a => a.t.KullaniciAdi).FirstOrDefault(),
                                 KullaniciID = grb.Select(a => a.t.KullaniciID).FirstOrDefault(),
                                 KaralisteUrunSayisi = grb.Count()
                             }
                       ).ToList();
                dto = temp.Join(temp2, a => a.KullaniciID, b => b.KullaniciID, (a, b) => new KullaniciListeSayisiDTO()
                {
                    KullaniciAdi = a.KullaniciAdi,
                    FavoriUrunSayisi = a.FavoriUrunSayisi,
                    KaralisteUrunSayisi = b.KaralisteUrunSayisi
                }).OrderBy(a => a.KullaniciAdi).ToList();
            }
            return dto;
        }

        public List<KullaniciKaraListeAdetDTO> KaralisteEnCokUrunKullaniciRapor()
        {
            List<KullaniciKaraListeAdetDTO> dto = null;
            using (YesilEvDbContext db = new YesilEvDbContext())
            {
                dto = (from u in db.Users
                       join b in db.Blacklists on u.UserID equals b.UserID
                       join bu in db.BlacklistAllergens on b.ListID equals bu.BlacklistID
                       group new { bu, u } by bu.BlacklistID into grp
                       select new KullaniciKaraListeAdetDTO
                       {
                           KullaniciAdi = grp.Select(x => x.u.Username).FirstOrDefault(),
                           KaralisteUrunAdeti = grp.Count()
                       }).Take(3).ToList();
            }
            return dto;
        }

        public List<FavoriKaralisteEklenenUrunlerDTO> BuAyFavoriKaralisteyeAlinanlarRapor()
        {
            List<FavoriKaralisteEklenenUrunlerDTO> list = null;
            using (YesilEvDbContext db = new YesilEvDbContext())
            {
                list = (from p in db.Products
                        join fu in db.FavoriUruns on p.UrunID equals fu.UrunID
                        where fu.DateAdded.Value.Month == DateTime.Now.Month
                        select new FavoriKaralisteEklenenUrunlerDTO()
                        {
                            UrunAdi = p.UrunAdi,
                            EklenmeTarihi = fu.DateAdded,
                            Turu = "Favori"
                        }).ToList();
                var list2 = (from ba in db.BlacklistAllergens
                             join bu in db.UrunAllergens on ba.AllergenID equals bu.AllergenID
                             join p in db.Products on bu.UrunID equals p.UrunID
                             where ba.DateAdded.Value.Month == DateTime.Now.Month
                             select new FavoriKaralisteEklenenUrunlerDTO()
                             {
                                 UrunAdi = p.UrunAdi,
                                 EklenmeTarihi = ba.DateAdded,
                                 Turu = "Karaliste"
                             }).ToList();
                list.AddRange(list2);
            }
            return list;
        }
    }
}
