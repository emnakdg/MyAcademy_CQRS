using CQRSProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.Context
{
    public static class DataSeeder
    {
        public static void SeedData(AppDbContext context)
        {

            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Pasta ve Kekler" },
                    new Category { Name = "Ekmek ve Unlu Mamuller" },
                    new Category { Name = "Tatlılar ve Kurabiyeler" },
                    new Category { Name = "Dondurma ve Soğuk Lezzetler" }
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }


            var pastaCat = context.Categories.FirstOrDefault(c => c.Name == "Pasta ve Kekler");
            var ekmekCat = context.Categories.FirstOrDefault(c => c.Name == "Ekmek ve Unlu Mamuller");
            var tatliCat = context.Categories.FirstOrDefault(c => c.Name == "Tatlılar ve Kurabiyeler");
            var dondurmaCat = context.Categories.FirstOrDefault(c => c.Name == "Dondurma ve Soğuk Lezzetler");


            if (!context.Sliders.Any())
            {
                context.Sliders.AddRange(
                    new Slider
                    {
                        Title = "Geleneksel Lezzetler Modern Dokunuşlar",
                        Description = "Avrupa'nın En Sevilen Tatlıları - Rengarenk Macaronlar!",
                        ImageUrl = "/Index-Photos/banner/banner-image-1.png",
                        ButtonText = "Şimdi Keşfet",
                        ButtonUrl = "/Shop",
                        BackgroundColor = "#e8382e",
                        IsActive = true,
                        Order = 1
                    },
                    new Slider
                    {
                        Title = "Mutluluk Veren Tatlar",
                        Description = "Özel Günleriniz İçin En Taze Pastalar Sizi Bekliyor.",
                        ImageUrl = "/Index-Photos/banner/banner-image-2.png",
                        ButtonText = "Alışverişe Başla",
                        ButtonUrl = "/Shop",
                        BackgroundColor = "#e05b8c",
                        IsActive = true,
                        Order = 2
                    },
                    new Slider
                    {
                        Title = "Serinleten Doğal Lezzet",
                        Description = "%100 Doğal Meyvelerden Yapılan Dondurmalarımızı Denediniz mi?",
                        ImageUrl = "/Index-Photos/banner/banner-image-3.png",
                        ButtonText = "Çeşitleri Gör",
                        ButtonUrl = "/Shop",
                        BackgroundColor = "#f59c1a",
                        IsActive = true,
                        Order = 3
                    }
                );
                context.SaveChanges();
            }


            if (!context.ThreeStepServices.Any())
            {
                context.ThreeStepServices.AddRange(
                    new ThreeStepService
                    {
                        StepNumber = 1,
                        Title = "Taze Fırın Ürünleri",
                        Description = "Her sabah fırından yeni çıkmış, sıcacık ve taze ürünlerimizi sizin için hazırlıyoruz."
                    },
                    new ThreeStepService
                    {
                        StepNumber = 2,
                        Title = "Özel Pastalar",
                        Description = "Doğum günü, düğün ve özel günleriniz için hayalinizdeki pastayı tasarlıyoruz."
                    },
                    new ThreeStepService
                    {
                        StepNumber = 3,
                        Title = "Hızlı Teslimat",
                        Description = "Siparişlerinizi özenle paketleyip en kısa sürede kapınıza kadar getiriyoruz."
                    }
                );
                context.SaveChanges();
            }


            if (!context.OurHistories.Any())
            {
                context.OurHistories.Add(new OurHistory
                {
                    Title = "Bagery Hakkında",
                    Description = "1990 yılından beri lezzet tutkunlarına hizmet veriyoruz. Geleneksel tarifleri modern sunumlarla birleştirerek, en kaliteli malzemelerle hazırladığımız ürünlerimizi sizlere sunuyoruz. Müşteri memnuniyeti ve kalite bizim için her zaman önceliklidir.",
                    ImageUrl = "/Index-Photos/our-history/ice-cream-1.png",
                    SignatureImageUrl = "/Index-Photos/our-history/signature-1.png",
                    OverviewTitle = "Neden Biz?",
                    OverviewDescription = "Yılların verdiği tecrübe ve ustalığı, yenilikçi anlayışımızla harmanlıyoruz. Hijyen standartlarına tam uyum sağlıyor, sağlığınızı önemsiyoruz.",
                    OverviewItems = "%100 Kalite Garantisi|Günlük Taze Üretim|Doğal Malzemeler"
                });
                context.SaveChanges();
            }


            if (!context.Products.Any() && pastaCat != null && ekmekCat != null && tatliCat != null && dondurmaCat != null)
            {
                context.Products.AddRange(

                    new Product
                    {
                        Name = "Premium Maraş Dondurması",
                        Description = "Keçi sütüyle hazırlanan, yoğun kıvamlı geleneksel Maraş dondurması.",
                        Price = 120,
                        ImageUrl = "/Index-Photos/our-shop/shop-1.jpg",
                        CategoryId = dondurmaCat.Id
                    },
                    new Product
                    {
                        Name = "İtalyan Usulü Vanilya",
                        Description = "Gerçek vanilya çubuklarıyla hazırlanan, yumuşak kıvamlı Gelato.",
                        Price = 100,
                        ImageUrl = "/Index-Photos/our-shop/shop-2.jpg",
                        CategoryId = dondurmaCat.Id
                    },
                    new Product
                    {
                        Name = "Külah Dondurma",
                        Description = "Çıtır kornet külah içinde karışık meyveli dondurma keyfi.",
                        Price = 80,
                        ImageUrl = "/Index-Photos/our-shop/shop-4.jpg",
                        CategoryId = dondurmaCat.Id
                    },
                     new Product
                    {
                        Name = "Karadut Sorbe",
                        Description = "Sütsüz, %100 meyve püresi ile yapılan serinletici lezzet.",
                        Price = 90,
                        ImageUrl = "/Index-Photos/our-shop/shop-1.jpg", // Görsel tekrarı
                        CategoryId = dondurmaCat.Id
                    },

                    new Product
                    {
                        Name = "Çikolatalı Yaş Pasta",
                        Description = "Yoğun Belçika çikolatası ve taze kek ile hazırlanan enfes pasta.",
                        Price = 450,
                        ImageUrl = "/Index-Photos/our-shop/shop-3.jpg",
                        CategoryId = pastaCat.Id
                    },
                    new Product
                    {
                        Name = "Frambuazlı Cheesecake",
                        Description = "Kıtır bisküvi tabanı ve taze frambuaz soslu San Sebastian Cheesecake.",
                        Price = 180,
                        ImageUrl = "/Index-Photos/our-shop/shop-3.jpg", // Görsel tekrarı
                        CategoryId = pastaCat.Id
                    },
                     new Product
                    {
                        Name = "Tiramisu",
                        Description = "Mascarpone peyniri ve espresso ile hazırlanan orijinal İtalyan lezzeti.",
                        Price = 160,
                        ImageUrl = "/Index-Photos/our-shop/shop-3.jpg", // Görsel tekrarı
                        CategoryId = pastaCat.Id
                    },

                    new Product
                    {
                        Name = "Ekşi Mayalı Köy Ekmeği",
                        Description = "24 saat fermente edilmiş, taş fırında pişmiş doğal ekmek.",
                        Price = 50,
                        ImageUrl = "/Index-Photos/our-shop/shop-2.jpg", // Görsel tekrarı
                        CategoryId = ekmekCat.Id
                    },
                     new Product
                    {
                        Name = "Tam Buğday Baget",
                        Description = "Lif kaynağı tam buğday unundan, çıtır kabuklu baget ekmek.",
                        Price = 35,
                        ImageUrl = "/Index-Photos/our-shop/shop-2.jpg", // Görsel tekrarı
                        CategoryId = ekmekCat.Id
                    },

                    new Product
                    {
                        Name = "Renkli Macaronlar (6'lı)",
                        Description = "Çilek, fıstık, limon ve çikolatalı karışık Fransız kurabiyesi.",
                        Price = 200,
                        ImageUrl = "/Index-Photos/banner/banner-image-1.png", // Slider görseli ürün olarak da kullanılabilir
                        CategoryId = tatliCat.Id
                    },
                     new Product
                    {
                        Name = "Çikolatalı Ekler",
                        Description = "İçi dolu dolu pastacı kreması, üzeri yoğun çikolata kaplamalı.",
                        Price = 90,
                        ImageUrl = "/Index-Photos/banner/banner-image-2.png", // Görsel tekrarı
                        CategoryId = tatliCat.Id
                    }
                );
                context.SaveChanges();
            }


            if (!context.Services.Any())
            {
                context.Services.AddRange(
                    new Service
                    {
                        Title = "Dondurma Çeşitleri",
                        Description = "Mevsimin en taze meyveleri ve doğal süt ile hazırladığımız dondurmalarımız.",
                        Icon = "icon-Ice-Cream",
                        Order = 1
                    },
                    new Service
                    {
                        Title = "Günlük Taze Ekmek",
                        Description = "Taş fırınımızdan çıkan mis kokulu, katkısız ve doğal ekmek çeşitleri.",
                        Icon = "icon-Bread",
                        Order = 2
                    },
                    new Service
                    {
                        Title = "Özel Gün Pastaları",
                        Description = "En mutlu günleriniz için size özel tasarladığımız butik pastalar.",
                        Icon = "icon-Cake",
                        Order = 3
                    },
                    new Service
                    {
                        Title = "Tatlı Atıştırmalıklar",
                        Description = "Çay ve kahve keyfinize eşlik edecek kurabiye ve donut çeşitleri.",
                        Icon = "icon-Donuts",
                        Order = 4
                    }
                );
                context.SaveChanges();
            }


            if (!context.PhotoGalleries.Any() && ekmekCat != null && tatliCat != null && dondurmaCat != null)
            {
                context.PhotoGalleries.AddRange(
                    new PhotoGallery
                    {
                        Title = "Ekmek Yapımı",
                        ImageUrl = "/Index-Photos/photo-gallery/project-1.jpg",
                        CategoryId = ekmekCat.Id
                    },
                    new PhotoGallery
                    {
                        Title = "Pancake Sunumu",
                        ImageUrl = "/Index-Photos/photo-gallery/project-2.jpg",
                        CategoryId = tatliCat.Id
                    },
                    new PhotoGallery
                    {
                        Title = "Dondurma Keyfi",
                        ImageUrl = "/Index-Photos/photo-gallery/project-3.jpg",
                        CategoryId = dondurmaCat.Id
                    }
                );
                context.SaveChanges();
            }


            if (!context.Promotions.Any())
            {
                context.Promotions.AddRange(
                    new Promotion
                    {
                        Title = "Herkesin Vazgeçemediği Lezzet",
                        Description = "Bu haftaya özel tüm çikolatalı pastalarda %20 indirim fırsatını kaçırmayın!",
                        ImageUrl = "/Index-Photos/promotion/promotion-1.jpg,/Index-Photos/promotion/promotion-2.jpg",
                        DiscountPercentage = 20,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7),
                        IsActive = true
                    },
                    new Promotion
                    {
                        Title = "Kahve Yanı Atıştırmalıklar",
                        Description = "Kahve alana dilediği kurabiye %50 indirimli.",
                        ImageUrl = "/Index-Photos/promotion/promotion-3.jpg",
                        DiscountPercentage = 50,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7),
                        IsActive = true
                    }
                );
                context.SaveChanges();
            }


            if (!context.Testimonials.Any())
            {
                context.Testimonials.AddRange(
                    new Testimonial
                    {
                        CustomerName = "Ayşe Yılmaz",
                        CustomerTitle = "Gurme Blogger",
                        Comment = "Hayatımda yediğim en taze ve lezzetli cheesecakeler buradaydı. Kesinlikle tavsiye ederim, mekanın atmosferi de harika.",
                        ImageUrl = "/Index-Photos/testimonials/testimonial-1.png",
                        Rating = 5
                    },
                    new Testimonial
                    {
                        CustomerName = "Mehmet Demir",
                        CustomerTitle = "Şef",
                        Comment = "Ekmeklerin dokusu ve lezzeti tam istediğim gibi. Ekşi mayalı köy ekmeği favorim oldu. Ellerinize sağlık.",
                        ImageUrl = "/Index-Photos/testimonials/testimonial-1.png",
                        Rating = 5
                    }
                );
                context.SaveChanges();
            }
            

            if (!context.Campaigns.Any())
            {
                context.Campaigns.AddRange(
                    new Campaign
                    {
                        Title = "Yaz Kampanyası",
                        Description = "Tüm dondurma çeşitlerinde 2 al 1 öde!",
                        ImageUrl = "/Index-Photos/banner/banner-image-3.png",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(2),
                        IsActive = true
                    },
                     new Campaign
                    {
                        Title = "Ramazan Özel",
                        Description = "İftar sonrası tatlılarınız bizden, özel indirimlerle.",
                        ImageUrl = "/Index-Photos/banner/banner-image-1.png",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(1),
                        IsActive = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
