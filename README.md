# 🍞 MyAcademy_CQRS - Fırın (Bakery) E-Ticaret Projesi

Modern yazılım mimarisi desenlerini (**CQRS**, **Mediator**, **Observer**, **Unit of Work**) kullanarak geliştirilmiş, **ASP.NET Core 9.0** tabanlı kapsamlı bir E-Ticaret Web Uygulamasıdır.

Bu proje, gerçek dünyadaki bir "Fırın/Pastane" işletmesini simüle eder. Yönetim için güçlü bir **Admin Paneli** ve müşterilerin ürünleri inceleyip sipariş verebileceği kullanıcı dostu bir **Arayüz (UI)** içerir.

## 🚀 Temel Özellikler

*   **CQRS Mimarisi**: Okuma (Query) ve Yazma (Command) işlemlerinin ayrıştırılmasıyla ölçeklenebilirlik ve bakım kolaylığı sağlar.
*   **Mediator Deseni**: `MediatR` kütüphanesi kullanılarak istek/yanıt (request/response) süreçleri gevşek bağlı (decoupled) hale getirilmiştir.
*   **Tasarım Desenleri:**
    *   **Unit of Work**: Veritabanı işlemlerinde (transaction) bütünlüğü garanti altına alır.
    *   **Observer**: Sipariş, kampanya ve iletişim gibi olaylarda (event) loglama ve bildirim mekanizmaları için kullanılmıştır.
    *   **Repository**: Veri erişim katmanını soyutlar.
*   **Cloudinary Entegrasyonu**: Ürün ve galeri görselleri bulut tabanlı olarak (Cloudinary) saklanır ve yönetilir.
*   **AutoMapper**: Entity ve DTO nesneleri arasında otomatik ve performanslı eşleme sağlar.
*   **Modern Admin Paneli**: Uygulamanın tüm yönlerini yönetmek için geliştirilmiş, istatistikler içeren paneli.
*   **Dinamik Arayüz**: Razor View ve özelleştirilmiş CSS ile geliştirilmiş, responsive (mobil uyumlu) ön yüz.

## 🛠️ Teknolojiler ve Kütüphaneler

*   **Framework**: .NET 9.0 (ASP.NET Core MVC)
*   **Veritabanı**: Microsoft SQL Server (Entity Framework Core 9.0 - Code First)
*   **CQRS & Mediator**: `MediatR` (v12.5.0)
*   **Mapping**: `AutoMapper` (v13.0.1)
*   **Bulut Depolama**: `CloudinaryDotNet` (v1.28.0)
*   **Frontend**: Razor Views, Bootstrap, HTML5, CSS3, jQuery
*   **IDE**: Visual Studio 2022

## 📦 Modüller ve Entity'ler

Uygulama aşağıdaki modüllerin tam yönetimini sağlar:

*   **🛒 Ürünler ve Kategoriler**: Pasta, ekmek ve diğer ürünlerin kategori bazlı yönetimi.
*   **📦 Siparişler**: Müşteri siparişlerinin takibi ve durum yönetimi.
*   **🖼️ Fotoğraf Galerisi**: İşletme fotoğraflarının buluta yüklenmesi ve galeride gösterimi.
*   **📢 Kampanyalar ve İndirimler**: Özel tekliflerin ve pazarlama kampanyalarının oluşturulması.
*   **💬 Müşteri Yorumları (Testimonials)**: Müşteri geri bildirimlerinin yönetimi.
*   **Slider**: Anasayfa kaydırıcı (slider) alanının yönetimi.
*   **📞 İletişim**: Müşteri mesajlarının görüntülenmesi ve takibi.
*   **Diğer**: Hizmetler, Tarihçemiz, 3 Adımlı Servis gibi kurumsal içerik modülleri.

## 🏗️ Mimari Genel Bakış

Proje yapısı, sorumlulukların ayrılığı (Separation of Concerns) ilkesine göre düzenlenmiştir:

*   **CQRSProject**: Ana Web Uygulaması
    *   `CQRSPattern`: `Commands` (Komutlar), `Queries` (Sorgular), `Handlers` (İşleyiciler) ve `Results` (DTO'lar) klasörlerini içerir.
    *   `Entities`: Veritabanı tablolarına karşılık gelen sınıflar.
    *   `Patterns`: UnitOfWork ve Observer desenlerinin implementasyonları.
    *   `Services`: Cloudinary gibi harici servisler.
    *   `Mappings`: AutoMapper profilleri.

## 📷 Ekran Görüntüleri
<img width="1902" height="1000" alt="1" src="https://github.com/user-attachments/assets/fc242736-f763-48d8-b2d0-37d0e7008ff8" />
<img width="1903" height="1007" alt="2" src="https://github.com/user-attachments/assets/fef33ffb-d32c-4874-ad06-068b01e5d322" />
<img width="1901" height="1079" alt="3" src="https://github.com/user-attachments/assets/7dddd95a-337f-43e5-af3a-3e732e6426f4" />
<img width="1904" height="1079" alt="4" src="https://github.com/user-attachments/assets/6c43e8fe-c805-424d-a3bd-708c44dc0ead" />
<img width="1905" height="1080" alt="5" src="https://github.com/user-attachments/assets/d0b58cf9-76bd-41f8-a883-561c20d740e9" />
<img width="1903" height="915" alt="6" src="https://github.com/user-attachments/assets/187ac311-1da0-49d8-ac03-858ad9ecfa48" />
<img width="1904" height="1080" alt="7" src="https://github.com/user-attachments/assets/661c1a74-11d0-457c-aa3d-2cc4b312b6ee" />
<img width="1904" height="1079" alt="8" src="https://github.com/user-attachments/assets/4f9c695b-4731-453e-b3e6-554d7e41377a" />
<img width="1916" height="1080" alt="9" src="https://github.com/user-attachments/assets/c167d6c9-6d60-48f7-9643-777c663b08b6" />
<img width="1906" height="1080" alt="10" src="https://github.com/user-attachments/assets/3995518e-b13a-464f-a54f-807e1731f287" />
<img width="1906" height="1077" alt="11" src="https://github.com/user-attachments/assets/2a0451ca-32f4-46b4-b8b5-8b1c274dbf98" />
<img width="1906" height="1080" alt="12" src="https://github.com/user-attachments/assets/d590e35b-b16a-4f9e-bea7-9259dd3903ea" />
<img width="1904" height="1080" alt="13" src="https://github.com/user-attachments/assets/90273aac-71b7-489a-bb5e-f1308eba89bd" />
<img width="1905" height="1077" alt="14" src="https://github.com/user-attachments/assets/4a1c72f0-7d3e-47aa-bdef-6c26a4290697" />
<img width="1919" height="1080" alt="Admin1" src="https://github.com/user-attachments/assets/1cb20747-b43c-48a9-af59-d6cec4e2997b" />
<img width="1920" height="1080" alt="Admin2" src="https://github.com/user-attachments/assets/6d83b5e4-3ee6-473e-9ed8-c385332e48e3" />
<img width="1918" height="1080" alt="Admin3" src="https://github.com/user-attachments/assets/d79876b5-379d-49e4-83fc-0e7600e20112" />
<img width="1918" height="1080" alt="Admin4" src="https://github.com/user-attachments/assets/c653f5f6-d254-4d02-a73c-c043735e1390" />
<img width="1919" height="1080" alt="Admin5" src="https://github.com/user-attachments/assets/36ccd62f-511a-4b5a-abfe-56f91e678612" />
