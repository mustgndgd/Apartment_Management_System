# Apartment_Management_System
# Mustafa-Gundogdu_Final_Homework
Mustafa Gündoğdu Bitirme Projesi


# Bitirme Projesi
Açıklama : Bir sitede yöneticisiniz. Sitenizde yer alan dairelerin aidat ve ortak kullanım
elektrik, su ve doğalgaz faturalarının yönetimini bir sistem üzerinden yapacaksınız.
İki tip kullanıcınız var:
1-Admin/Yönetici
* Daire bilgilerini girebilir.
* İkamet eden kullanıcı bilgilerini girer.
* Daire başına ödenmesi gereken aidat ve fatura bilgilerini girer(Aylık olarak). Toplu veya
tek tek atama yapılabilir.
* Gelen ödeme bilgilerini görür.
* ~~Gelen mesajları görür.~~
* ~~Mesajların okunmuş/okunmamış/yeni mesaj olduğu anlaşılmalı.~~
* Aylık olarak borç-alacak listesini görür.
* Kişileri listeler, düzenler, siler.
* Daire/konut bilgilerini listeler, düzenler siler.
2-Kullanıcı
* Kendisine atanan fatura ve aidat bilgilerini görür.
* Sadece kredi kartı ile ödeme yapabilir.
* ~~Yöneticiye mesaj gönderebilir.~~
* ~~Mesajların okunmuş/okunmamış/yeni mesaj olduğu anlaşılmalı.~~
* Yaptığı ödemelerini görür.
Daire/Konut bilgilerinde:
* Hangi blokda
* Durumu (Dolu-boş)
* Tipi (2+1 vb.)
* Bulunduğu kat

* Daire numarası
* Daire sahibi veya kiracı
Kullanıcı bilgilerinde
* Ad-soyad
* TCNo
* E-Mail
* Telefon
* Araç bilgisi(varsa plaka no)

Sistem kullanılmaya başladığında ilk olarak,
* 1.Yönetici daire bilgilerini girer.
* 2.Kullanıcı bilgilerini girer.Giriş yapması için otomatik olarak bir şifre
oluşturulur. 
* 3.Kullanıcıları dairelere atar
* 4.Ay bazlı olarak aidat bilgilerini girer.
* 5.Ay bazlı olarak fatura bilgilerini girer
Arayüz dışında kullanıcıların kredi kartı ile ödeme yapabilmesi için ayrı bir servis
yazılacaktır.
Bu serviste sistemde ki her bir kullanıcı için banka bilgileri (bakiye, kredi kartı no
vb.) kontrol edilerek ödeme yapılması sağlanır.
Ödeme sadece kredi kartı ile yapılabilir.
Projede kullanılacaklar:
* 1.Web projesi backend için .Net Core, frontend için
Razorkullanılmalı.
*  2.Sistemin yönetimi/database için MS SQL Server kullanılmalı.
* 3.Kredi kartı servisi için. Veriler mongodb de tutulmalı. Servis .Net WebApi olarak
yazılacaktır.
* 4.Mümkün olduğu kadar derslerde işlenen konular projeye entegre edilmelidir.
 
 * Ayrıca Kullanılan özellikler ve proje anlatımı
 * .net core 3.1 ve Entity Framework kullanarak n katmanlı mimari tasarımı ile proje geliştirildi.
*  Authorize işlemleri için Microsofr Identity implemente edildi.
*  Veritabanındaki identity tabloları güncellendi Configürasyonları yapıldı
*  Dependency Injection, IOC desenleri kullanıldı.
*  Nesne yönelimli programlama ile nesneler arasıdna one-one one-many many-many bağlantıları kuruldu
*  Foreing key oluşturuldu. 
*  Payment Api içerisinde ExceptionMiddleware Kullanıldı
 * Automapper kullanımı yapıldı
* Kullanıcılara arka planda otomatik mail atan bir BACKGROUND SERVİS implemente edildi 
* Admin istediğinde faturası ödenmemiş kullanıcılara mail atıyor sistem

# Projeyi Bilgisayarınızda kurmak için adımları izleyin
## 

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/solution_tanitimi.png )

* Öncelikle veritabanlarını kurmamız gerekiyor
Apartment.App.Web projesinde appsettings.json dosyasına gidiyoruz ve Connectionstring->DefaultConnection içerisindeki connection String i kendi bilgisayarınıza göre ayarlamanız gerekliyor.
"Server= YOUR_SERVER"
 
![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/update-database.png )
* Package Manager Console içerisinde Resimdeki gibi default projeyi seçip UPDATE-DATABASE komutunu çalıştırıyoruz.

* Web Projemiz hazır şimdi API'yi oluşturalım
Mongo Db Yükledikten sonra bknz: https://www.mongodb.com/try/download/community üzerinden indirip kurduktan sonra 

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/mongo-create-db.png )
* Resimdeki adımları izleyerek veritabanın kuruyoruz.

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/mongo-connectionstring.png )
* Resimdeki adımları izleyerek mongo için kullanacağımız bağlantıyı kopyalıyoruz bağlana tıklayıp kapatıyoruz.


![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/paymentservice-update.png )
* Resimdeki adımları izleyerek mongodb konfigürasyonlarını API mize ekliyoruz. Veritabanı oluştururken kullandığımız veritabanı ve collectionName i doğru yazdığımızdan emin olmalıyız

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/multiple-start.png )
* Resimdeki adımları izleyerek WEB uygulamamız ve API uygulamamızın birlikte çalışmasını Sağlıyoruz.

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/swagger-port.png )
* Resimdeki adımları izleyerek swagger portunu kontrol ediyoruz buradaki url bilgilerini 

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/url.png )
* Resimdeki adımları izleyerek eğer sizinki farklı ise url inizi buraya giriyorsunuz.

* Artk başlamaya hazırsınız

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/seed1.png )


![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/seed2.png )

* Sistem kendiliğinden bir admin atamaktadır.

* Admin Tc numarası :12345678900
* Admin Şifre : Admin123.
* Default olarak bir admin, Fatura Tipleri (Aidat,Elektrik,Su,Doğalgaz)
* 2 Blok ve Her Bloğa Katlar eklemektedir
* Kullanıcı kaydı yapılınca şifresi otomatik olarak Sifre123. atanıyor login sayfasında bilgilendirme yapıldı kullanım için

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m1.png )
* Anasayfada sadece giriş yapan kullanıcılar ilgili sayfaları görecek şekilde düzenlendi
![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m2.png )
*  Giriş için TC kimlik numarası ve Şifre gerekli kılındı
*  Üyeler için Default şifre : Sifre123. 
* Admin için şifre Admin123. 

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m3.png )
* Giriş işlemi için validasyonlar tanımlandı 

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m4.png )
* Admin işlemleri için Navigation Barda menüler tanımlandı

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m5.png )
* Kullanıcıların listelenip yönetileceği sayfa admin buradan kullanıcı ekleyebilir listeleyebilir güncelleyebilir

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m6.png )


![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m7.png )


![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m8.png )
* Fatura tipi otomatik olarak ekleniyor Web projesi altında Data Klasörü içinde ContextSeed kısmında tanımlandı. Admin isterse yeni bir 
tip oluşturabilir güncelleyebilir listeleyebilir
![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m9.png )
* Yönetilen sitedeki BLOK lar; o Bloklardaki KAT lar ve Her kattaki daire miktarı bu sayfada tanımlandı listelendi.
* Admin blok ekleyebilir 
* Admin bloğa kat ekleyebilir 
* Eğer blokta kalan yoksa bloğu silebilir

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m10.png )
* Admin kata Daire ekleyebilir

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m11.png )
* Adres bilgileri otomatik geliyor değiştirilemez şekilde. 
Sadece büyüklük boş olma durumu ev sahibi durumu ve varsa kiracının Kimlik numarasını ekleyerek daire ekleyebilir
Kullanıcı bilgileri olmadan boş olarak da daire ekleyebilir

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m12.png )
* Dairelerin boş veya dolu olması listeleniyor


![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m13.png )
* SADECE DOLU EVLERE FATURA KESİLEBİLİR 
* Fatura tipleri seçilebilir
* Kullanım miktarı, birim fiyatı ve kullanım yapılan gün seçilerek Toplam tutar otomatik oluşur


![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m14.png )
* Kesilen faturalar listelenir Detaylı bilgi tablodan okunabilinir

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m17.png )
* Fatura ödeme ekranında kart bilgileri girilerek ödeme işlemi tamamlanır verilerin doğruluğu kontrol edilir.
* Kredi kartının geçerli bir limiti olunmasına bakılmaz geçerli birimler girilirse ödenmiş sayılır 

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m18.png )
* Fatura ödenmişse eğer Ödeme makbuzu görüntülenebilri

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m19.png )
* MongoDb de yaptığımız ödemenin kaydı görünmekte

![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m20.png )
* Mongo Db den ödeme bilgilerini çekebiliriz


![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m22.png )
* Mail Servisi için ayarlamaları yapmalıyız
![image](https://github.com/mustgndgd/Apartment_Management_System/blob/main/images/m21.png )
* Ödenmemiş faturaların kullanıcılarına mail atarak bilgilendirme geçmek için bir kuyruk yapısı oluşturduk
* Log olarak basıldı