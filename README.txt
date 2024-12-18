# BirlikteMiniDemo

Bu proje, kullanıcı, ürün, kategori ve sepet yönetimini içeren bir demo uygulamasıdır. **Clean Architecture** prensiplerine uygun olarak tasarlanmış, **CQRS**, **MediatR** ve **Entity Framework Core** ile desteklenmiştir. Proje **Docker** üzerinde PostgreSQL ile çalıştırılabilir.

---

## **Proje Yapısı**

Proje aşağıdaki katmanlardan oluşmaktadır:

- **Domain**: İş kuralları ve temel modellerin bulunduğu katman.
- **Application**: CQRS ve iş mantıklarının işlendiği katman.
- **Infrastructure**: Repository ve servis implementasyonlarının bulunduğu katman.
- **Persistence**: Entity Framework Core ile veritabanı işlemleri.
- **API**: REST API'yi barındıran katman.

---

## **Kullanılan Teknolojiler**

- .NET 8
- Entity Framework Core
- PostgreSQL
- Docker ve Docker Compose
- Swagger (API dokümantasyonu)
- MediatR (CQRS için)

---

## **Özellikler**

1. **Kullanıcı Yönetimi**
   - Kullanıcı kayıt, güncelleme ve silme işlemleri.
   - Kullanıcının profil fotoğrafını Base64 formatında kaydetme.

2. **Ürün Yönetimi**
   - Ürün ekleme, güncelleme, silme ve listeleme işlemleri.
   - Ürün görsellerini Base64 formatında kaydetme.

3. **Kategori Yönetimi**
   - Kategoriler için CRUD işlemleri.

4. **Sepet Yönetimi**
   - Sepet detaylarını görüntüleme.
   - Sepete ürün ekleme ve çıkarma.

---

## **Kurulum Adımları**

### 1. **Gereksinimler**

- Docker ve Docker Compose

- .NET 8 SDK

### 2. **Projenin Klonlanması**

git clone https://github.com/username/BirlikteMiniDemo.git

cd BirlikteMiniDemo

### 3. Docker ile PostgreSQL ve Uygulamanın Çalıştırılması

Docker Compose Çalıştırma: Proje dizininde aşağıdaki komutu çalıştırarak PostgreSQL ve uygulamayı başlatın:


docker-compose up -d

Docker Servislerini Kontrol Etme: Çalışan servisleri kontrol etmek için:

docker ps

### 4. Veritabanı Migration İşlemleri

Docker içinde uygulamanın çalıştığı konteynere bağlanarak migration işlemlerini gerçekleştirin.

Konteynere Bağlanma:


docker exec -it birlikte-mini-demo-api bash

Migration İşlemleri:

dotnet ef migrations add InitialCreate -p ../BirlikteMiniDemo.Persistence -s .
dotnet ef database update -p ../BirlikteMiniDemo.Persistence -s .
