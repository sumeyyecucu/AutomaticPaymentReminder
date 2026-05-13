# Automatic Payment Reminder

Banka müşterilerinin düzenli abonelik ödemelerini (elektrik, su, internet, GSM vb.) tek bir platform üzerinden takip edebildiği ve ödeyebildiği bankacılık uygulamasıdır.

---

## Teknolojiler

**Backend**
- .NET 10 / ASP.NET Core Web API
- Clean Architecture
- MediatR (CQRS pattern)
- Entity Framework Core
- FluentValidation
- AutoMapper
- MySQL

**Frontend**
- React
- Bootstrap 5
- Axios
- React Router DOM

---

## Mimari

Proje Clean Architecture prensiplerine göre 4 katmana ayrılmıştır:

```
Domain       → Entity'ler, enum'lar, interface'ler
Application  → Use case'ler, handler'lar, DTO'lar, validator'lar
Infrastructure → Repository implementasyonları, mock servisler, DbContext
API          → Controller'lar, middleware, Program.cs
```

---

## Kurulum

### Backend

```bash
cd AutomaticPaymentReminder.API
dotnet restore
dotnet ef database update
dotnet run
```

> API: `http://localhost:5150`  
> Swagger: `http://localhost:5150` (root path)

### Frontend

```bash
cd automatic-payment-reminder
npm install
npm start
```

> Uygulama: `http://localhost:3000`

---

## API Endpoint Listesi

### Customers
| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | /api/customers | Tüm müşterileri listele |
| GET | /api/customers/{id} | Müşteri detayı |
| POST | /api/customers | Yeni müşteri oluştur |
| PUT | /api/customers | Müşteri güncelle |
| DELETE | /api/customers/{id} | Müşteri sil |

### Subscriptions
| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | /api/subscriptions | Abonelikleri listele |
| GET | /api/subscriptions/{id} | Abonelik detayı |
| POST | /api/subscriptions | Yeni abonelik oluştur |
| PUT | /api/subscriptions/{id} | Abonelik güncelle |
| DELETE | /api/subscriptions/{id} | Abonelik sil |

### Debt
| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | /api/subscriptions/{id}/debt | Borç sorgula |

### SubscriptionType
| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | /api/subscriptionTypes | Abonelik türlerini listele |
| POST | /api/subscriptionTypes | Abonelik türü ekle |
| DELETE | /api/subscriptionTypes/{id} | Abonelik türü sil|

### Payments
| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | /api/payments | Ödemeleri listele |
| POST | /api/payments | Yeni ödeme oluştur |

### Email
| Method | Endpoint | Açıklama |
|--------|----------|----------|
| POST |  /api/email/send-reminders | Email gönder |
| GET |  /api/email/unpaid-debts | Ödenmemiş borçları listele |

---

## Üçüncü Parti Servis Entegrasyonları (Mock)

### MockDebtQueryService
Abonelik numarasına göre mock borç bilgisi döndürür. Gerçek entegrasyon yerine statik veri kullanılır.

### MockPaymentGatewayService
Ödeme işlemlerini simüle eder. %90 başarı oranı ile rastgele başarılı/başarısız sonuç döndürür.

---

## Kimlik Doğrulama

JWT tabanlı authentication kapsam dışı bırakıldı. Mevcut kullanıcı kimliği her istekte `X-Customer-Id` header'ı ile iletilir. Frontend, seçilen müşteriyi `localStorage`'da saklar ve her API isteğine otomatik ekler.

---

## Veri Modeli

```
Customers → Subscriptions → Payments
SubscriptionTypes → Subscriptions
```

- Bir müşteri birden fazla aboneliğe sahip olabilir
- Bir aboneliğin birden fazla ödemesi olabilir
- Aynı dönem için tekrar ödeme yapılamaz

---

## Yapay Zeka Kullanımı

Bu projede yapay zeka aşağıdaki alanlarda kullanılmıştır:

| Alan | Kullanım |
|------|----------|
| Kod üretimi | Repository, handler ve mock servis iskeletleri oluşturuldu |
| Refactoring | Servis katmanı ve controller yapısı gözden geçirildi |
| Validation kuralları | FluentValidation kuralları önerildi, gözden geçirilerek uygulandı |
| API tasarımı | Endpoint isimlendirme ve route yapısı için öneri alındı |
| Dokümantasyon | ER diagram, akış diyagramı ve README oluşturuldu |

> Üretilen tüm çıktılar doğrudan kullanılmamış; gözden geçirilerek ve projeye uygun şekilde düzenlenerek uygulanmıştır.

---

## Kapsam Dışı Bırakılanlar

- JWT authentication (Header bazlı müşteri kimliği ile çözüldü)
- Gerçek SMS/Email bildirimi (Mock endpoint ile simüle edildi)
- Uzun süreli ödeme yapılmayan aboneliklerin otomatik pasife alınması
- Ödeme iadesi (Refund)
