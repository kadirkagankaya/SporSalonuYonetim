# 🏋️‍♂️ Spor Salonu Yönetim Sistemi (Gym Management System)

Bu proje, **.NET 9**, **Entity Framework Core** ve **MongoDB** kullanılarak geliştirilmiş, **N-Katmanlı Mimari (N-Tier Architecture)** prensiplerine tam uyumlu bir REST API projesidir.

Proje; temiz kod (clean code), sürdürülebilirlik ve genişletilebilirlik ilkeleri gözetilerek tasarlanmıştır.

## 🚀 Projenin Öne Çıkan Teknik Özellikleri

Bu projede modern yazılım geliştirme standartları ve ileri seviye teknikler kullanılmıştır:

*   **Mimari:** N-Katmanlı Mimari (Core, Data, Service, API)
*   **Veritabanı:** MongoDB (NoSQL)
*   **ORM:** Entity Framework Core (MongoDB Provider ile)
*   **Tasarım Desenleri:**
    *   **Generic Repository Pattern:** Tekrarlı kodları önlemek için.
    *   **Unit of Work Pattern:** Veritabanı tutarlılığı (transaction) sağlamak için.
    *   **Dependency Injection (DI):** Bağımlılıkları yönetmek için.
*   **Mapping:** AutoMapper kütüphanesi ile Entity-DTO dönüşümleri.
*   **API Yaklaşımları:**
    *   **Controllers:** Klasik MVC tabanlı API yönetimi.
    *   **Minimal API:** .NET'in modern ve hızlı endpoint tanımlama yaklaşımı.
*   **Hata Yönetimi:** Özel **Global Exception Handling Middleware** ile merkezi hata yakalama ve standart response yapısı.
*   **Loglama:** **Serilog** entegrasyonu ile yapılandırılmış loglama (Konsol ve Dosya).
*   **Dokümantasyon:** Swagger / OpenAPI arayüzü.

## 📂 Katman Yapısı

1.  **SporSalonuYonetim.Core:** Projenin kalbi. Entity'ler, DTO'lar, Arayüzler (Interfaces) ve sabitler burada bulunur. Hiçbir dış kütüphaneye bağımlı değildir.
2.  **SporSalonuYonetim.Data:** Veritabanı erişim katmanı. MongoDB Context'i, Repository implementasyonları ve Seed datalar buradadır.
3.  **SporSalonuYonetim.Service:** İş mantığı (Business Logic) katmanı. Validasyonlar, iş kuralları ve Mapping işlemleri burada yapılır.
4.  **SporSalonuYonetim.API:** Dış dünyaya açılan kapı. Controller'lar, Middleware'ler ve DI konfigürasyonlarını içerir.

## 🛠️ Kurulum ve Çalıştırma

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

### Gereksinimler
*   .NET 9 SDK
*   MongoDB (Localhost veya Atlas)

### Adımlar

1.  **Projeyi Klonlayın:**
    ```bash
    git clone https://github.com/kadirkagankaya/SporSalonuYonetim.git
    cd SporSalonuYonetim
    ```

2.  **Veritabanı Bağlantısı:**
    `SporSalonuYonetim.API` projesi altındaki `appsettings.json` dosyasını açın ve MongoDB bağlantı adresinizi kontrol edin:
    ```json
    "ConnectionStrings": {
      "MongoDbConnection": "mongodb://localhost:27017"
    }
    ```

3.  **Projeyi Çalıştırın:**
    ```bash
    dotnet run --project SporSalonuYonetim.API
    ```

4.  **Swagger ile Test Edin:**
    Tarayıcınızda `https://localhost:7198/swagger` (veya konsolda belirtilen port) adresine gidin.

## 📝 API Endpoints

Proje hem **Controller** hem de **Minimal API** yaklaşımlarını destekler:

*   **Users:** `/api/users` (CRUD işlemleri)
*   **Trainers:** `/api/trainers` (Eğitmen işlemleri)
*   **Features (Minimal API):**
    *   `/api/features/subscriptions` (Abonelik Tipleri)
    *   `/api/features/workouts` (Antrenman Programları)

---
**Geliştirici:** Kadir Kağan Kaya
**Tarih:** Aralık 2025
