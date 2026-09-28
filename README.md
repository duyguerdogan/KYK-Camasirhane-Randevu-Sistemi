# KYK Çamaşırhane Randevu Sistemi

KYK yurtlarında çamaşırhane kullanımını planlamak ve sıra beklemeyi azaltmak amacıyla geliştirilmiş **C# Windows Forms** masaüstü uygulaması. Kullanıcı bilgileri, çamaşır ve kurutma makinesi seçimleri ile rezervasyon işlemleri SQL Server üzerinde tutulur.

## Özellikler

- Kullanıcı bilgilerini ekleme, listeleme, güncelleme ve silme ekranları.
- Çamaşır ve kurutma makinesi seçimi.
- Çamaşır makinelerinin boş/dolu durumlarını görüntüleme.
- Kullanıcı, makine, tarih ve saat bilgileriyle rezervasyon oluşturma.
- Rezervasyonları listeleme, güncelleme ve silme ekranları.
- Çamaşır makinesi rezervasyonunda kullanıcı/makine seçimi, saat biçimi ve başlangıç–bitiş sırası kontrolü.

## Kullanılan Teknolojiler

| Teknoloji | Kullanım |
| --- | --- |
| C# | Uygulama mantığı |
| .NET Framework 4.7.2 | Hedef çalışma ortamı |
| Windows Forms | Masaüstü arayüzü |
| Microsoft SQL Server | Veri saklama |
| ADO.NET / System.Data.SqlClient | Veritabanı bağlantısı ve sorgular |
| DataSet / TableAdapter | Veri erişimi ve veri bağlama |

## Gereksinimler

- Windows işletim sistemi.
- Visual Studio ve **.NET masaüstü geliştirme** iş yükü.
- **.NET Framework 4.7.2 Developer Pack / Targeting Pack**.
- Erişilebilir bir SQL Server örneği ve uygulamanın beklediği veritabanı şeması.
- Veritabanını hazırlamak için SQL Server Management Studio (SSMS) veya eşdeğer bir araç.

## Kurulum ve Çalıştırma

### 1. Projeyi indirin

```bash
git clone https://github.com/duyguerdogan/KYK-Camasirhane-Randevu-Sistemi.git
cd KYK-Camasirhane-Randevu-Sistemi
```

Git kullanmıyorsanız GitHub üzerindeki **Code → Download ZIP** seçeneğiyle indirebilirsiniz.

### 2. Visual Studio ile açın

`KykCamasirhaneSistemi/KykCamasirhaneSistemi.sln` dosyasını açın. Hedef çerçeve eksik uyarısı alırsanız .NET Framework 4.7.2 hedefleme paketini yükleyin.

### 3. Veritabanını hazırlayın

Uygulama, `KykCamasirhaneProjesi` adlı SQL Server veritabanına bağlanacak şekilde yapılandırılmıştır.

> **Kurulum notu:** Depoda şu an ayrı bir veritabanı oluşturma SQL betiği veya yedek dosyası sunulmuyor. Yalnızca boş bir veritabanı oluşturmak uygulamayı çalıştırmak için yeterli değildir; beklenen tabloların, sütunların ve ilişkilerin de hazırlanması gerekir. DataSet (`.xsd`) dosyaları ve kaynak koddaki sorgular veri yapısını incelemek için kullanılabilir, ancak tam veritabanı kurulum betiğinin yerini tutmaz.

Çamaşır makinesi rezervasyon akışının kullandığı temel tablolar arasında `Kullanici`, `CamasirMakinesiDurumu`, `MakineSecimi`, `Rezervasyon` ve `RezervasyonTarihSaat` bulunur. Makine listelerinin dolması için ilgili makine kayıtları da veritabanında bulunmalıdır.

### 4. Bağlantı bilgilerini düzenleyin

`KykCamasirhaneSistemi/App.config` içindeki bağlantı dizesinin `Data Source` alanını kendi SQL Server örneğinize göre değiştirin.

Windows kimlik doğrulaması kullanan örnek bağlantı dizesi:

```text
Data Source=SUNUCU_ADINIZ;Initial Catalog=KykCamasirhaneProjesi;Integrated Security=True;
```

`SUNUCU_ADINIZ` yerine kendi sunucu/örnek adınızı yazın. Windows hesabınızın ilgili veritabanına erişim yetkisi olmalıdır.

**Yalnızca App.config dosyasını değiştirmek yeterli değildir:** Bazı form dosyalarında bağlantı dizesi doğrudan tanımlanmıştır. Visual Studio’da çözüm genelinde `Data Source=` araması yapın; form kodlarındaki ve DataSet ayarlarındaki bağlantı bilgilerini de kendi ortamınızla uyumlu hale getirin.

### 5. Uygulamayı başlatın

Veritabanı ve bağlantı ayarları tamamlandıktan sonra Visual Studio’da **Build → Build Solution** ile derleyin. Gerekirse `KykCamasirhaneSistemi` projesini başlangıç projesi olarak seçin ve **F5** ile çalıştırın.

## Örnek Kullanım Akışı

1. Kullanıcı bilgileri ekranından bir kullanıcı kaydı oluşturun.
2. Makine seçimi ekranından çamaşır veya kurutma makinesi bölümüne geçin.
3. Çamaşır makinesi rezervasyonu için listeden boş bir makine ve kullanıcı seçin.
4. Tarihi, başlangıç saatini ve bitiş saatini girerek kaydı oluşturun.
5. Rezervasyon listeleme ekranından kaydı kontrol edin; ilgili ekranlardan güncelleme veya silme işlemlerini yapın.

## Proje Yapısı

```text
KykCamasirhaneSistemi/
├── KykCamasirhaneSistemi.sln       # Visual Studio çözümü
├── KykCamasirhaneSistemi.csproj    # Proje ve hedef çerçeve ayarları
├── Program.cs                    # Uygulama başlangıcı
├── girisFormu.cs                  # Karşılama / giriş ekranı
├── AnaSayfaFormu.cs               # Ana menü
├── MakineSecimi.cs                # Makine türü seçimi
├── CamasirMakinesi.cs             # Çamaşır makinesi rezervasyonları
├── KurutmaMakinesi.cs             # Kurutma makinesi işlemleri
├── Kullanici*.cs                  # Kullanıcı yönetimi ekranları
├── Rezervasyon*.cs                # Rezervasyon yönetimi ekranları
├── KykCamasirhaneProjesiDataSet*   # DataSet ve veri erişimi dosyaları
├── App.config                    # Uygulama ve bağlantı ayarları
├── Properties/                   # Proje kaynakları ve ayarları
└── Resources/                    # Arayüz görselleri
```

Formların `.Designer.cs` dosyaları arayüz yerleşimini, `.resx` dosyaları ise ilgili kaynakları içerir.

## Mevcut Sınırlamalar ve Geliştirme Hedefleri

- Veritabanı şeması ve örnek veriler için tekrar çalıştırılabilir kurulum betikleri eklenmesi.
- Bağlantı bilgilerinin tek bir yapılandırma noktasında toplanması.
- Rezervasyon adımlarının tek bir veritabanı işlemi (`transaction`) içinde tamamlanması.
- Makine uygunluğunun yalnızca boş/dolu bilgisiyle değil, seçilen tarih ve saat aralığına göre kontrol edilmesi; eşzamanlı rezervasyonların güvence altına alınması.
- Kullanıcı doğrulaması ve yetkilendirme eklenmesi. Mevcut giriş düğmesi doğrudan ana sayfayı açar.
- Otomatik testler ve uygulama ekran görüntüleri eklenmesi.

## Geliştirici

[Duygu Erdoğan](https://github.com/duyguerdogan)
