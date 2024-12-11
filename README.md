Crazy Musicians API
Crazy Musicians API, müzisyenlerle ilgili CRUD (Create, Read, Update, Delete) işlemleri yapmanızı sağlayan bir RESTful API'dir. Bu API ile müzisyenleri listeleyebilir, belirli kriterlere göre arama yapabilir, yeni müzisyenler ekleyebilir, var olanları güncelleyebilir veya silebilirsiniz.

Endpoints ve Kullanım
## 1. Tüm Müzisyenleri Listele
URL: GET /api/musicians
Açıklama: Sistemdeki tüm müzisyenlerin bilgilerini döner.
Örnek Yanıt:
json
 ```
[
    {
        "id": 1,
        "name": "Ahmet Çalgı",
        "profession": "Ünlü Çalgı Çalar",
        "funFeature": "Her zaman yanlış nota çalar, ama çok eğlenceli."
    },
    {
        "id": 2,
        "name": "Zeynep Melodi",
        "profession": "Popüler Melodi Yazarı",
        "funFeature": "Şarkıları yanlış anlaşılır ama çok popüler."
    }
]
 ```
## 2. İsme Göre Müzisyen Arama
URL: GET /api/musicians/search
Query Parametreleri:
name (zorunlu): Aramak istediğiniz müzisyenin adı.
Açıklama: İsme göre müzisyenleri filtreler.
Örnek İstek:
sql
GET /api/musicians/search?name=Ahmet
Örnek Yanıt:
 ```json
[
    {
        "id": 1,
        "name": "Ahmet Çalgı",
        "profession": "Ünlü Çalgı Çalar",
        "funFeature": "Her zaman yanlış nota çalar, ama çok eğlenceli."
    }
]
 ```
## 3. ID ile Müzisyen Getir
URL: GET /api/musicians/{id}
Açıklama: Belirtilen ID'ye sahip müzisyenin bilgilerini döner.
Örnek Yanıt:
 ```json
{
    "id": 3,
    "name": "Cemil Akor",
    "profession": "Çılgın Akorist",
    "funFeature": "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli."
}
 ```
## 4. Yeni Müzisyen Ekle
URL: POST /api/musicians
Açıklama: Sisteme yeni bir müzisyen ekler.
Body:
 ```json
{
    "id": 11,
    "name": "Yeni Müzisyen",
    "profession": "Yeni Meslek",
    "funFeature": "Yeni eğlenceli özellik"
} ```
Örnek Yanıt: (Başarılı Ekleme)
 ```json
{
    "id": 11,
    "name": "Yeni Müzisyen",
    "profession": "Yeni Meslek",
    "funFeature": "Yeni eğlenceli özellik"
} ```
##5. Müzisyen Bilgilerini Güncelle
URL: PUT /api/musicians/{id}
Açıklama: Belirtilen ID'ye sahip müzisyenin tüm bilgilerini günceller.
Body:
 ```json
{
    "name": "Güncellenmiş İsim",
    "profession": "Güncellenmiş Meslek",
    "funFeature": "Güncellenmiş Eğlenceli Özellik"
} ```
Örnek Yanıt:
HTTP 204 No Content (Başarılı Güncelleme)

### 6. Eğlenceli Özelliği Güncelle
URL: PATCH /api/musicians/{id}
Açıklama: Müzisyenin yalnızca eğlenceli özelliğini değiştirir.
Body:
 ```json
"Yeni eğlenceli özellik"
Örnek Yanıt:
HTTP 204 No Content (Başarılı Güncelleme)
```

### 7. Müzisyen Sil
URL: DELETE /api/musicians/{id}
Açıklama: Belirtilen ID'ye sahip müzisyeni sistemden siler.
Örnek Yanıt:
HTTP 204 No Content (Başarılı Silme)
Veri Modeli
Müzisyenlerin sistemdeki temsili aşağıdaki gibidir:

 ```csharp

public class Musician
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Profession { get; set; }
    public string FunFeature { get; set; }
}
```
