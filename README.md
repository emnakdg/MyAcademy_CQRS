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

