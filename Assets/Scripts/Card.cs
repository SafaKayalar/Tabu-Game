using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [Header("UI Textleri Assign et")]
    public Text cevapText;
    public Text yasakli1;
    public Text yasakli2;
    public Text yasakli3;
    public Text yasakli4;
    public Text yasakli5;

    // --- SÖZLÜK ---
    private Dictionary<string, string[]> cardDict = new Dictionary<string, string[]>();

    private List<string> allCards = new List<string>();
    private int currentIndex = 0;

    void Start()
    {
        BuildWordList();      // Kod içi kelime listesi
        InitializeAllCards(); // Tüm kartları listeye al
        ShowNext();
    }

    void BuildWordList()
    {
        cardDict.Clear();
        if(GameManager.Instance.category == "Oyun")
        {        
            cardDict.Add("Strateji", new string[] { "hamle", "düşman", "kaynak", "savunma", "zafer" });
            cardDict.Add("Rol Yapma", new string[] { "karakter", "gelişim", "görev", "savaş", "büyü" });
            cardDict.Add("Bulmaca", new string[] { "zeka", "çözüm", "ipucu", "labirent", "karmaşık" });
            cardDict.Add("Kart Oyunu", new string[] { "destek", "taktik", "el", "puan", "rakip" });
            cardDict.Add("Simülasyon", new string[] { "kontrol", "senaryo", "gerçeklik", "model", "ayarlama" });
            cardDict.Add("Macera", new string[] { "keşif", "engel", "harita", "gizem", "hikaye" });
            cardDict.Add("Aksiyon", new string[] { "saldırı", "refleks", "silah", "hız", "tehlike" });
            cardDict.Add("Savaş", new string[] { "strateji", "ordular", "kuşatma", "müttefik", "kayıp" });
            cardDict.Add("Zindan", new string[] { "tuzağı", "anahtar", "canavar", "hazine", "karanlık" });
            cardDict.Add("Hayatta Kalma", new string[] { "açlık", "barınak", "su", "savunma", "tehdit" });
            cardDict.Add("Spor", new string[] { "puan", "hakem", "turnuva", "antrenman", "rekabet" });
            cardDict.Add("Yarış", new string[] { "hız", "viraj", "rakip", "kaza", "zafer" });
            cardDict.Add("Platform", new string[] { "zıplama", "engel", "düşme", "denge", "hedef" });
            cardDict.Add("Korku", new string[] { "hayalet", "karanlık", "gerilim", "tuzağı", "kaçış" });
            cardDict.Add("MOBA", new string[] { "kahraman", "minyon", "koridor", "taktik", "eşya" });
            cardDict.Add("FPS", new string[] { "nişan", "cephane", "hedef", "refleks", "kalkan" });
            cardDict.Add("Taktik", new string[] { "pozisyon", "koordine", "savunma", "saldırı", "öngörü" });
            cardDict.Add("Mücadele", new string[] { "direniş", "zafer", "rakip", "strateji", "risk" });
            cardDict.Add("Zeka Oyunu", new string[] { "mantık", "analiz", "çözüm", "tahmin", "karmaşık" });
            cardDict.Add("Roguelike", new string[] { "rastgele", "tekrar", "zorluk", "keşif", "hayatta kalma" });
            cardDict.Add("Arena", new string[] { "dövüş", "rakip", "strateji", "zafer", "taktik" });
            cardDict.Add("Ekonomi", new string[] { "yatırım", "kaynak", "bütçe", "piyasa", "kar" });
            cardDict.Add("Uzay", new string[] { "yıldız", "gemi", "galaksi", "rota", "karadelik" });
            cardDict.Add("Zombi", new string[] { "bulaşıcı", "kaçış", "sığınak", "tehdit", "silah" });
            cardDict.Add("Casusluk", new string[] { "gizli", "görev", "kod", "kamera", "kaçış" });
            cardDict.Add("Korsan", new string[] { "hazine", "gemi", "rota", "savaş", "deniz" });
            cardDict.Add("Mitoloji", new string[] { "tanrı", "efsane", "canavar", "görev", "büyü" });
            cardDict.Add("Vampir", new string[] { "gece", "kan", "gölge", "av", "gizem" });
            cardDict.Add("Sihirbazlık", new string[] { "ikna", "büyü", "kart", "hile", "taktik" });
            cardDict.Add("Robot", new string[] { "program", "çip", "sensör", "görev", "kontrol" });
            cardDict.Add("F", new string[] { "Saygı", "Cenaze", "Tuş", "Basmak", "Call of Duty" });
            cardDict.Add("Rush B", new string[] { "CS:GO", "Saldırmak", "Taktik", "Dust 2", "P90" });
            cardDict.Add("Rage Quit", new string[] { "Sinir", "Çıkmak", "Alt F4", "Klavye", "Kırmak" });
            cardDict.Add("Camper", new string[] { "Pusucu", "Beklemek", "Köşe", "Çadır", "Sniper" });
            cardDict.Add("GG", new string[] { "Good Game", "İyi", "Bitti", "Tebrik", "Kolay" });
            cardDict.Add("AFK", new string[] { "Uzak", "Klavye", "Gitmek", "Hareket", "Durmak" });
            cardDict.Add("Nerf", new string[] { "Güçsüz", "Zayıflatmak", "Silah", "Karakter", "Yama" });
            cardDict.Add("Smurf", new string[] { "Hesap", "Mavi", "Düşük", "Profesyonel", "Ezmek" });
            cardDict.Add("Teabag", new string[] { "Çömelmek", "Kalkmak", "Ceset", "Hareket", "Dalga" });
            cardDict.Add("P2W", new string[] { "Para", "Kazanmak", "Zengin", "Ücretli", "Avantaj" });
            cardDict.Add("Troll", new string[] { "Şaka", "Bozmak", "Ciddi", "Feed", "Kızdırmak" });
            cardDict.Add("Git Gud", new string[] { "Öğren", "Beceriksiz", "Dark Souls", "Kötü", "Tavsiye" });
            cardDict.Add("Speedrun", new string[] { "Hızlı", "Bitirmek", "Rekor", "Süre", "Glitch" });
            cardDict.Add("Ez", new string[] { "Kolay", "Basit", "Easy", "Noob", "Yenmek" });
            cardDict.Add("Mainlemek", new string[] { "Karakter", "Sürekli", "Oynamak", "Favori", "Seçmek" });
            cardDict.Add("Carry", new string[] { "Taşımak", "Sırtlamak", "Takım", "Güçlü", "Kazandırmak" });
            cardDict.Add("Support", new string[] { "Destek", "Yardım", "Heal", "Yan", "Koruma" });
            cardDict.Add("Tank", new string[] { "Zırh", "Can", "Dayanıklı", "Ön", "Hasar" });
            cardDict.Add("Jungler", new string[] { "Ormancı", "Gank", "Lane", "Koridor", "Canavar" });
            cardDict.Add("Feeder", new string[] { "Beslemek", "Ölmek", "Bilerek", "Rakip", "Kötü" });
            cardDict.Add("Tryhard", new string[] { "Ciddi", "Terlemek", "Zorlamak", "Eğlence", "Kazanmak" });
            cardDict.Add("Ban", new string[] { "Yasak", "Hesap", "Atılmak", "Perma", "Süreli" });
            cardDict.Add("Report", new string[] { "Şikayet", "Bildirmek", "Ban", "Küfür", "Oyun Sonu" });
            cardDict.Add("KDA", new string[] { "Skor", "Oran", "Kill", "Death", "Assist" });
            cardDict.Add("Buff", new string[] { "Güçlendirme", "Özellik", "Yama", "Artı", "Nerf" });
            cardDict.Add("Ulti", new string[] { "Yetenek", "Son", "Güçlü", "R Tuşu", "Bekleme" });
            cardDict.Add("Lobby", new string[] { "Bekleme", "Oda", "Başlamak", "Davet", "Arkadaş" });
            cardDict.Add("Grind", new string[] { "Kasmak", "Tekrar", "Level", "Eşya", "Sıkıcı" });
            cardDict.Add("Drop", new string[] { "Düşmek", "FPS", "Kutu", "İnternet", "Şans" });
            cardDict.Add("Hitbox", new string[] { "Vuruş", "Alan", "Karakter", "Mermi", "Değmek" });
            cardDict.Add("RGB", new string[] { "Işık", "Renkli", "Klavye", "Oyuncu", "Led" });
            cardDict.Add("Mekanik", new string[] { "Klavye", "Ses", "Switch", "Tuş", "Pahalı" });
            cardDict.Add("Hz", new string[] { "Hertz", "Monitör", "Ekran", "Yenileme", "144" });
            cardDict.Add("SSD", new string[] { "Hızlı", "Disk", "Depolama", "Yükleme", "Harddisk" });
            cardDict.Add("GPU", new string[] { "Ekran Kartı", "Grafik", "Görüntü", "İşlemci", "Pahalı" });
            cardDict.Add("Console Peasant", new string[] { "Konsol", "PC", "Fakir", "30 FPS", "Kol" });
            cardDict.Add("PC Master Race", new string[] { "Bilgisayar", "Üstün", "Toplamak", "Kasa", "Performans" });
            cardDict.Add("Son El", new string[] { "Yalan", "Uyumak", "Gece", "Oynamak", "Kapatmak" });
            cardDict.Add("Alt F4", new string[] { "Kapatmak", "Çıkmak", "Kısayol", "Sinir", "Hile" });
            cardDict.Add("Backseat", new string[] { "Karışmak", "Arkadan", "Söylemek", "Öğretmek", "İzlemek" });
            cardDict.Add("Spoiler", new string[] { "Söylemek", "Sonu", "Hikaye", "Tat", "Film" });
            cardDict.Add("Clickbait", new string[] { "Tıklamak", "Yalan", "Başlık", "Video", "Resim" });
            cardDict.Add("Gaben", new string[] { "Steam", "Valve", "Half Life 3", "İndirim", "Cüzdan" });
            cardDict.Add("Lore", new string[] { "Hikaye", "Evren", "Geçmiş", "Derin", "Arka Plan" });
            cardDict.Add("Easter Egg", new string[] { "Gizli", "Sürpriz", "Yumurta", "Paskalya", "Bulmak" });
            cardDict.Add("Save", new string[] { "Kaydetmek", "Dosya", "Kaldığın Yer", "Hafıza", "Yüklemek" });
            cardDict.Add("Checkpoint", new string[] { "Nokta", "Kayıt", "Dönmek", "Ölünce", "Bayrak" });
            cardDict.Add("Tutorial", new string[] { "Eğitim", "Öğretici", "Başlangıç", "Göstermek", "Ders" });
            cardDict.Add("Loading", new string[] { "Yükleniyor", "Ekran", "Beklemek", "Dolmak", "Yüzde" });
            cardDict.Add("Open World", new string[] { "Açık Dünya", "Harita", "Gezmek", "Özgür", "GTA" });
            cardDict.Add("Battle Pass", new string[] { "Bilet", "Sezon", "Ödül", "Seviye", "Paralı" });
            cardDict.Add("Co-op", new string[] { "Beraber", "Arkadaş", "İki Kişilik", "Yardımlaşma", "Takım" });
            cardDict.Add("Crossplay", new string[] { "Platform", "Konsol", "PC", "Birlikte", "Eşleşme" });
            cardDict.Add("Quick Time Event", new string[] { "Tuş", "Basmak", "Zaman", "Sinematik", "Refleks" });
            cardDict.Add("Craft", new string[] { "Yapmak", "Üretmek", "Birleştirmek", "Masa", "Eşya" });
            cardDict.Add("Headshot", new string[] { "Kafa", "Vurmak", "Tek", "Nişan", "Kritik" });
            cardDict.Add("Wallhack", new string[] { "Duvar", "Görmek", "Hile", "Arka", "Saydam" });
            cardDict.Add("Aimbot", new string[] { "Otomatik", "Nişan", "Hile", "Kafa", "Program" });
            cardDict.Add("Clutch", new string[] { "Tek Başına", "Kazandırmak", "Son", "Çevirmek", "Heyecan" });
            cardDict.Add("Ace", new string[] { "Herkes", "Vurmak", "Takım", "Temizlemek", "5 Kişi" });
            cardDict.Add("One Shot", new string[] { "Tek", "Can", "Vuruş", "Ölmek", "Mermi" });
            cardDict.Add("Spray", new string[] { "Taramak", "Sekmek", "Duvar", "Desen", "Basılı Tutmak" });
            cardDict.Add("Stun", new string[] { "Sersem", "Durdurmak", "Hareket", "Bayılmak", "Kitlemek" });
            cardDict.Add("Friendly Fire", new string[] { "Dost", "Ateş", "Vurmak", "Takım", "Zarar" });
            cardDict.Add("Streamer", new string[] { "Yayıncı", "Twitch", "Kamera", "Canlı", "İzleyici" });
            cardDict.Add("Discord", new string[] { "Konuşmak", "Sesli", "Sunucu", "Arkadaş", "Uygulama" });
            cardDict.Add("Toxic", new string[] { "Zehirli", "Küfür", "Kötü", "Davranış", "Sinir" });
            cardDict.Add("Mod", new string[] { "Değişiklik", "Yama", "Dosya", "Eklemek", "Orijinal" });
            cardDict.Add("Emulator", new string[] { "Program", "Konsol", "PC", "Eski", "Çalıştırmak" });
            cardDict.Add("Jumpscare", new string[] { "Korkmak", "Zıplamak", "Aniden", "Çığlık", "Ekrana Fırlamak" });
            cardDict.Add("DLC", new string[] { "Ek Paket", "İçerik", "Satın Almak", "İndirmek", "Genişleme" });
            cardDict.Add("Gank", new string[] { "Baskın", "Sayıca Üstün", "Pusu", "Koridor", "Yardım" });
            cardDict.Add("Mousepad", new string[] { "Fare", "Altlık", "Kaymak", "Kumaş", "Masa" });
        }
        else if(GameManager.Instance.category == "Genel Kültür")
        {
            cardDict.Add("İspanya", new string[] { "La Liga", "Gaudi Sagrada Familia", "Flamenko", "Madrid Kraliyet Sarayı", "İber Yarımadası" });
            cardDict.Add("Hindistan", new string[] { "Ganj Nehri", "Bollywood Endüstrisi", "Tac Mahal Agra", "Yeni Delhi Parlamentosu", "Rupi Para Birimi" });
            cardDict.Add("İtalya", new string[] { "Vatikan Sınırı", "Rönesans Floransa", "Pisa Kulesi", "Roma Forumu", "Akdeniz Çizmesi" });
            cardDict.Add("Çin", new string[] { "Yasak Şehir", "Pekin Olimpiyatı 2008", "Şanghay Kulesi", "Han Hanedanı", "İpek Yolu" });
            cardDict.Add("Berlin", new string[] { "Brandenburg Kapısı", "Reichstag Kubbesi", "Tiergarten Parkı", "Spree Nehri", "1989 Duvar" });
            cardDict.Add("Washington", new string[] { "Capitol Hill", "Lincoln Anıtı", "Pentagon Yakını", "Beyaz Saray", "Potomac Nehri" });
            cardDict.Add("Ottawa", new string[] { "Parlamento Tepesi", "Rideau Kanalı", "Ontario Eyaleti", "Kanada Bayrağı", "Buz Festivali" });
            cardDict.Add("Kiev", new string[] { "Dinipro Nehri", "Bağımsızlık Meydanı", "Altın Kubbeli Katedral", "Doğu Avrupa", "Ukrayna Merkezi" });
            cardDict.Add("Martin Luther", new string[] { "95 Tez 1517", "Wittenberg Kilisesi", "Protestan Reformu", "Almanya", "Katolik Bölünmesi" });
            cardDict.Add("Thomas Edison", new string[] { "Menlo Park", "1879 Filament", "Patent Rekoru", "Elektrik Sistemi", "Fonograf" });
            cardDict.Add("Leonardo da Vinci", new string[] { "Vitruvius Adamı", "Rönesans İtalya", "Uçan Makine Taslağı", "Son Akşam Yemeği", "Floransa" });
            cardDict.Add("Frida Kahlo", new string[] { "Meksika Ressamı", "Otoportre", "Diego Rivera", "Kaş Sembolü", "20. Yüzyıl" });
            cardDict.Add("Yavuz Sultan Selim", new string[] { "1517 Mısır Seferi", "Halifelik", "Çaldıran 1514", "Osmanlı Padişahı", "Kutsal Emanetler" });
            cardDict.Add("Winston Churchill", new string[] { "II. Dünya Lideri", "İngiltere Başbakanı", "Demir Perde Sözü", "1940 Konuşması", "Nobel Edebiyat" });
            cardDict.Add("Gandhi", new string[] { "Tuz Yürüyüşü 1930", "Pasif Direniş", "Hindistan Bağımsızlığı", "Suikast 1948", "İngiliz Yönetimi" });
            cardDict.Add("Marie Antoinette", new string[] { "Versay Sarayı", "1789 Devrimi", "Giyotin", "Fransız Kraliçesi", "Avusturya Doğumlu" });
            cardDict.Add("Stephen Hawking", new string[] { "Kara Delik Radyasyonu", "Cambridge Profesörü", "Zamanın Kısa Tarihi", "ALS Hastalığı", "Teorik Fizik" });
            cardDict.Add("Gregor Mendel", new string[] { "Bezelye Deneyi", "Kalıtım Yasası", "Avusturya Manastırı", "Genetik Temeli", "19. Yüzyıl" });
            cardDict.Add("Louis Pasteur", new string[] { "Pastörizasyon", "Kuduz Aşısı", "Fransız Kimyager", "Mikrop Teorisi", "19. Yüzyıl" });
            cardDict.Add("Elon Musk", new string[] { "SpaceX Falcon", "Tesla Motors", "Mars Projesi", "PayPal Kurucu", "Starlink" });
            cardDict.Add("Carl Sagan", new string[] { "Cosmos Belgeseli", "NASA Danışmanı", "Altın Plak", "Astrobiyoloji", "1980 Yayını" });
            cardDict.Add("Rosalind Franklin", new string[] { "X Işını Difraksiyonu", "DNA Fotoğraf 51", "King's College", "1950'ler", "Moleküler Biyoloji" });
            cardDict.Add("GPS", new string[] { "Uydu Sistemi", "ABD Savunma", "Konum Koordinatı", "Navigasyon", "1978 Fırlatma" });
            cardDict.Add("Tren", new string[] { "Buharlı Lokomotif", "Sanayi Devrimi", "Ray Sistemi", "George Stephenson", "19. Yüzyıl" });
            cardDict.Add("Kamera", new string[] { "Daguerreotype 1839", "Fotoğraf Plakası", "Optik Lens", "Işık Hassasiyet", "Karanlık Oda" });
            cardDict.Add("Bilgisayar", new string[] { "ENIAC 1945", "Turing Makinesi", "İşlemci", "Binary Sistem", "IBM" });
            cardDict.Add("Aşı", new string[] { "Edward Jenner 1796", "Çiçek Hastalığı", "Bağışıklık Sistemi", "Enjeksiyon", "Tıp Devrimi" });
            cardDict.Add("Matematik", new string[] { "Pisagor Teoremi", "Cebir", "Geometri", "Sayı Kuramı", "Antik Yunan" });
            cardDict.Add("Ay'a İniş", new string[] { "Apollo 11", "1969", "Neil Armstrong", "Houston Merkezi", "Buzz Aldrin" });
            cardDict.Add("Lozan Antlaşması", new string[] { "1923 İsviçre", "İsmet İnönü Heyeti", "Sınır Belirleme", "Kapitülasyon Kaldırma", "Barış Antlaşması" });
            cardDict.Add("Çernobil Kazası", new string[] { "1986 Ukrayna", "Nükleer Reaktör 4", "Pripyat", "Radyasyon Sızıntısı", "Sovyet Dönemi" });
            cardDict.Add("Rönesans", new string[] { "Floransa Medici", "15. Yüzyıl", "Sanat Patlaması", "Hümanizm", "Avrupa" });
            cardDict.Add("Soğuk Savaş", new string[] { "NATO 1949", "Varşova Paktı", "Berlin Krizi", "Silahlanma Yarışı", "ABD-SSCB" });
            cardDict.Add("Magna Carta", new string[] { "1215 İngiltere", "Kral John", "Baron İsyanı", "Hukuk Temeli", "Kraliyet Yetkisi" });
            cardDict.Add("Özgürlük Heykeli", new string[] { "Ellis Adası", "Fransız Hediyesi 1886", "New York Limanı", "Meşale", "Bakır Kaplama" });
            cardDict.Add("Kolezyum", new string[] { "MS 80 Roma", "Gladyatör", "Amfitiyatro", "Flavian Hanedanı", "Arena" });
            cardDict.Add("Tac Mahal", new string[] { "Agra Hindistan", "Şah Cihan", "Mumtaz Mahal", "Beyaz Mermer", "Babür" });
            cardDict.Add("Barış Manço", new string[] { "7'den 77'ye", "Anadolu Rock", "Adam Olacak Çocuk", "1999 Vefat", "Uzun Saç" });
            cardDict.Add("Neşet Ertaş", new string[] { "Bozkırın Tezenesi", "Bağlama", "Kırşehir", "Halk Müziği", "Abdal" });
            cardDict.Add("Sabiha Gökçen", new string[] { "Dünyanın İlk Kadın Savaş Pilotu", "1937 Dersim", "Atatürk Manevi Kızı", "Havaalanı İsmi", "Türk Havacılık" });
            cardDict.Add("Hermes", new string[] { "Kanatlı Sandalet", "Tanrıların Habercisi", "Olimpos", "Ticaret Tanrısı", "Yunan" });
            cardDict.Add("Ares", new string[] { "Savaş Tanrısı", "Zeus Oğlu", "Roma Mars", "Olimpos", "Mitoloji" });
            cardDict.Add("Anubis", new string[] { "Çakal Başlı", "Mısır Mitolojisi", "Ölüler Yargısı", "Mumyalama", "Yeraltı" });
            cardDict.Add("Albert Camus", new string[] { "1957 Nobel", "Yabancı Romanı", "Cezayir Doğumlu", "Absürd Felsefe", "Fransız Yazar" });
            cardDict.Add("Nelson Mandela", new string[] { "1993 Nobel", "Apartheid Karşıtı", "Güney Afrika Başkanı", "27 Yıl Hapis", "Barış Ödülü" });
            cardDict.Add("Ada Yonath", new string[] { "2009 Kimya Nobel", "Ribozom Yapısı", "İsrailli Bilim İnsanı", "X-Işını Kristalografi", "Kadın Kimyager" });
            cardDict.Add("Amerika", new string[] { "Özgürlük Heykeli", "Beyaz Saray", "Hollywood Bulvarı", "NBA Finalleri", "New York Borsası" });
            cardDict.Add("Almanya", new string[] { "Berlin Duvarı", "Bundestag", "Oktoberfest", "Bavyera", "Autobahn" });
            cardDict.Add("Londra", new string[] { "Big Ben", "Thames Nehri", "Buckingham Sarayı", "Westminster", "Çift Katlı Otobüs" });
            cardDict.Add("Ankara", new string[] { "Anıtkabir", "Kızılay Meydanı", "TBMM", "Çankaya Köşkü", "Atakule" });
            cardDict.Add("Tokyo", new string[] { "Shibuya Kavşağı", "Akihabara", "İmparatorluk Sarayı", "Sushi Kültürü", "Fuji Manzarası" });
            cardDict.Add("Mustafa Kemal Atatürk", new string[] { "1881 Selanik", "Sakarya Meydan Muharebesi", "Nutuk", "Dolmabahçe 1938", "Cumhuriyet İlanı" });
            cardDict.Add("Napolyon", new string[] { "Waterloo 1815", "Elba Sürgünü", "Fransız İmparatorluğu", "Kodifikasyon", "Topçu Subayı" });
            cardDict.Add("Kanuni Sultan Süleyman", new string[] { "Muhteşem Lakabı", "Hürrem Sultan", "Belgrad Seferi", "Zigetvar", "Osmanlı Altın Çağı" });
            cardDict.Add("Albert Einstein", new string[] { "E=mc²", "1915 Genel Görelilik", "Fotoelektrik Etki", "Nobel 1921", "Patent Ofisi" });
            cardDict.Add("Nikola Tesla", new string[] { "Alternatif Akım Sistemi", "Wardenclyffe Kulesi", "Westinghouse Anlaşması", "Manyetik Alan Deneyi", "Colorado Springs" });
            cardDict.Add("Marie Curie", new string[] { "Polonyum Keşfi", "Radyum İzolasyonu", "1903 Fizik Nobel", "1911 Kimya Nobel", "Paris Laboratuvarı" });
            cardDict.Add("Aziz Sancar", new string[] { "DNA Onarım Mekanizması", "2015 Kimya Nobel", "UNC Chapel Hill", "Mardin Doğumlu", "Biyokimya Çalışması" });
            cardDict.Add("Telefon", new string[] { "1876 Patenti", "Alexander Graham Bell", "Ahize Tasarımı", "İlk Uzun Mesafe Çağrı", "Boston Deneyi" });
            cardDict.Add("Ampul", new string[] { "1879 Filament", "Thomas Edison Laboratuvarı", "Karbon Tel", "Menlo Park", "Elektrik Devresi" });
            cardDict.Add("İnternet", new string[] { "ARPANET 1969", "TCP/IP Protokolü", "Tim Berners-Lee", "World Wide Web", "Sunucu Ağı" });
            cardDict.Add("Fransız İhtilali", new string[] { "14 Temmuz 1789", "Bastille Baskını", "Giyotin İnfazları", "Jakoben Kulübü", "İnsan Hakları Bildirisi" });
            cardDict.Add("II. Dünya Savaşı", new string[] { "Normandiya Çıkarması", "Pearl Harbor 1941", "Hiroşima 6 Ağustos", "Nazi Almanyası", "1945 Teslimiyet" });
            cardDict.Add("İstanbul'un Fethi", new string[] { "29 Mayıs 1453", "Şahi Topu", "Haliç Zinciri", "Bizans Sonu", "II. Mehmet" });
            cardDict.Add("Cumhuriyetin İlanı", new string[] { "29 Ekim 1923", "TBMM Kararı", "Ankara Başkent", "İlk Cumhurbaşkanı", "Yeni Yönetim" });
            cardDict.Add("Piramitler", new string[] { "Gize Platosu", "Keops", "Antik Mısır", "Firavun Mezarı", "Hiyeroglif" });
            cardDict.Add("Eyfel Kulesi", new string[] { "1889 Paris Fuarı", "Gustave Eiffel", "324 Metre Yükseklik", "Champ de Mars", "Demir Kafes" });
            cardDict.Add("Çin Seddi", new string[] { "Ming Hanedanı", "Uzun Savunma Hattı", "Moğol Akınları", "Tuğla Yapı", "Asya Haritası" });
            cardDict.Add("Mevlana", new string[] { "Konya Türbesi", "Mesnevi Eseri", "Şems-i Tebrizi", "Semazen Ritüeli", "13. Yüzyıl" });
            cardDict.Add("Mimar Sinan", new string[] { "Selimiye Camii", "Süleymaniye", "Başmimar Unvanı", "Kalfalık Eseri", "Osmanlı Mimarı" });
            cardDict.Add("Yunus Emre", new string[] { "Risaletü'n Nushiyye", "Tasavvuf Şiiri", "Anadolu Türkçesi", "13. Yüzyıl", "Halk Edebiyatı" });
            cardDict.Add("Zeus", new string[] { "Olimpos Dağı", "Şimşek Sembolü", "Hera Eşi", "Yunan Panteonu", "Tanrıların Kralı" });
            cardDict.Add("Thor", new string[] { "Mjolnir Çekici", "Asgard Diyarı", "Odin'in Oğlu", "İskandinav Mitolojisi", "Gök Gürültüsü" });
            cardDict.Add("Orhan Pamuk", new string[] { "2006 Edebiyat Nobel", "Kar Romanı", "Masumiyet Müzesi", "Stockholm Töreni", "Türk Yazar" });
            cardDict.Add("Malala Yousafzai", new string[] { "2014 Nobel Barış", "Pakistanlı Aktivist", "Kız Çocuk Eğitimi", "En Genç Ödül Sahibi", "Taliban Saldırısı" });
            cardDict.Add("Kleopatra", new string[] { "VII. Ptolemaios", "Marcus Antonius", "Nil Kraliçesi", "MÖ 30", "Aspis Zehri" });
            cardDict.Add("Julius Sezar", new string[] { "Rubicon Nehri", "MÖ 44 Senato", "Brütüs", "Ides of March", "Roma Konsülü" });
            cardDict.Add("Marco Polo", new string[] { "Venedikli Tüccar", "Kubla Han Sarayı", "İpek Yolu Günlüğü", "13. Yüzyıl", "Asya Seyahati" });
            cardDict.Add("Isaac Newton", new string[] { "Principia 1687", "Kraliyet Cemiyeti", "Kalkülüs Tartışması", "Cambridge", "Optik Deneyleri" });
            cardDict.Add("Galileo Galilei", new string[] { "Sidereus Nuncius", "Engizisyon 1633", "Jüpiter Uyduları", "Pisa Kulesi Deneyi", "Heliosantrik Savunma" });
            cardDict.Add("Berlin Duvarı", new string[] { "13 Ağustos 1961", "Brandenburg Geçişi", "Doğu Almanya", "Checkpoint Charlie", "1989 Açılış" });
            cardDict.Add("Sanayi Devrimi", new string[] { "James Watt Buhar Makinesi", "Manchester Tekstil", "18. Yüzyıl İngiltere", "Fabrika Sistemi", "Kömür Enerjisi" });
            cardDict.Add("Amerikan İç Savaşı", new string[] { "1861-1865", "Gettysburg", "Konfederasyon", "Abraham Lincoln", "Kölelik Meselesi" });
            cardDict.Add("Machu Picchu", new string[] { "And Dağları", "İnka İmparatorluğu", "Peru Cusco", "15. Yüzyıl", "Yüksek Rakım" });
            cardDict.Add("Stonehenge", new string[] { "Salisbury Ovası", "Neolitik Dönem", "MÖ 3000", "Taş Halkalar", "Gizemli Yapı" });
            cardDict.Add("Herkül", new string[] { "12 Görev", "Zeus'un Oğlu", "Nemea Aslanı", "Yarı Tanrı", "Yunan Kahramanı" });
            cardDict.Add("Athena", new string[] { "Bilgelik Tanrıçası", "Zeus'un Kafası", "Baykuş Sembolü", "Atina Koruyucusu", "Zırhlı Tasvir" });
        }
        else if (GameManager.Instance.category == "Akademi")
        {
            cardDict.Add("Gerilim", new string[] { "Volt Birimi", "V=IR", "Potansiyel Fark", "DC Kaynak", "Multimetre Ölçümü" });
            cardDict.Add("Akım", new string[] { "Amper Birimi", "Elektron Akışı", "Seri Devre", "I Sembolü", "Ohm Yasası" });
            cardDict.Add("Güç", new string[] { "P=VI", "Watt Birimi", "Enerji Tüketimi", "Fatura Hesabı", "Aktif Yük" });
            cardDict.Add("Frekans", new string[] { "Hertz Birimi", "50 Hz Şebeke", "Periyot T=1/f", "Sinüs Dalga", "Osiloskop" });
            cardDict.Add("Tork", new string[] { "Nm Birimi", "Moment Kolu", "Dönme Hareketi", "Motor Şaftı", "Kuvvet x Mesafe" });
            cardDict.Add("Diyot", new string[] { "Anot-Katot", "PN Junction", "Tek Yönlü Akım", "1N4007", "Doğrultma Devresi" });
            cardDict.Add("Transistör", new string[] { "Base-Emitter", "BJT Tipi", "Amplifikatör", "Switch Modu", "Yarı İletken" });
            cardDict.Add("Direnç", new string[] { "Ohm Renk Kodu", "Seri-Paralel", "Ω Sembolü", "Akım Sınırlama", "V=IR" });
            cardDict.Add("Kondansatör", new string[] { "Farad", "RC Devresi", "Yük Depolama", "Filtreleme", "Elektrolitik" });
            cardDict.Add("Arduino", new string[] { "ATmega328P", "Digital Pin", "AnalogRead()", "IDE Yazılımı", "Mikrodenetleyici Kartı" });
            cardDict.Add("Algoritma", new string[] { "Adım Adım Çözüm", "Akış Diyagramı", "Pseudo Code", "Zaman Karmaşıklığı", "O(n)" });
            cardDict.Add("Debug", new string[] { "Breakpoint", "Hata Ayıklama", "IDE Araçları", "Console Log", "Stack Trace" });
            cardDict.Add("Veritabanı", new string[] { "SQL Sorgu", "Primary Key", "Tablo İlişkisi", "SELECT Komutu", "PostgreSQL" });
            cardDict.Add("API", new string[] { "REST Servis", "HTTP Request", "JSON Format", "Endpoint", "GET-POST" });
            cardDict.Add("Git", new string[] { "commit", "branch", "merge", "push origin", "Versiyon Kontrol" });
            cardDict.Add("Basınç", new string[] { "Pascal Birimi", "P=F/A", "Hidrolik Sistem", "Sıvı Statik", "Manometre" });
            cardDict.Add("Isı Transferi", new string[] { "İletim Konveksiyon", "Radyasyon", "Fourier Yasası", "W/mK", "Termal Analiz" });
            cardDict.Add("Sürtünme", new string[] { "μ Katsayısı", "Normal Kuvvet", "Statik-Kinetik", "Yüzey Teması", "Enerji Kaybı" });
            cardDict.Add("Moment", new string[] { "Kuvvet x Mesafe", "Denge Denklemi", "Statik Analiz", "Serbest Cisim", "Nm Birimi" });
            cardDict.Add("Malzeme Yorulması", new string[] { "S-N Eğrisi", "Tekrarlı Yük", "Çatlak Başlangıcı", "Metal Yorgunluğu", "Dayanım Azalması" });
            cardDict.Add("PID", new string[] { "Proportional", "Integral", "Derivative", "Hata Sinyali", "Kapalı Çevrim" });
            cardDict.Add("Sensör", new string[] { "Analog Çıkış", "ADC Dönüşüm", "Kalibrasyon", "LM35", "Giriş Sinyali" });
            cardDict.Add("Motor", new string[] { "RPM", "DC Motor", "Şaft", "PWM Kontrol", "Tork Üretimi" });
            cardDict.Add("Robotik", new string[] { "Kinematik", "Servo Motor", "End-Effector", "ROS", "Otonom Sistem" });
            cardDict.Add("Optimizasyon", new string[] { "Amaç Fonksiyonu", "Kısıt Denklemi", "Feasible Bölge", "Minimizasyon", "Karar Değişkeni" });
            cardDict.Add("Simülasyon", new string[] { "Monte Carlo", "Rastgele Üretim", "Modelleme", "Senaryo Analizi", "Parametre" });
            cardDict.Add("Lineer Programlama", new string[] { "Simplex Tablosu", "Köşe Noktası", "Dual Problem", "Pivot İşlemi", "Gölge Fiyat" });
            cardDict.Add("Stokastik", new string[] { "Olasılık Dağılımı", "Rastgele Süreç", "Markov Zinciri", "Beklenen Değer", "Varyans" });
            cardDict.Add("Lean Üretim", new string[] { "Kaizen", "Muda İsraf", "Just in Time", "5S", "Toyota Sistemi" });
            cardDict.Add("Ohm Yasası", new string[] { "V=IR", "Georg Simon Ohm", "1827 Yayını", "Direnç Hesabı", "Lineer Devre" });
            cardDict.Add("Kirchhoff", new string[] { "Düğüm Akımı KCL", "Çevre Gerilimi KVL", "1845 Kanunları", "Devre Analizi", "Toplam Sıfır" });
            cardDict.Add("Alternatif Akım", new string[] { "50 Hertz Türkiye", "Sinüs Dalga", "RMS Değeri", "Tesla Sistemi", "Faz Açısı" });
            cardDict.Add("Transformatör", new string[] { "Primer-Sekonder", "Manyetik Nüve", "Sarim Oranı", "Gerilim Dönüşümü", "Faraday Yasası" });
            cardDict.Add("ADC", new string[] { "Analog to Digital", "Bit Çözünürlüğü", "Sampling Rate", "Quantization", "Arduino AnalogRead" });
            cardDict.Add("PWM", new string[] { "Duty Cycle", "Frekans Modülasyonu", "Motor Hız Kontrol", "AnalogWrite()", "Darbe Genişliği" });
            cardDict.Add("MOSFET", new string[] { "Gate-Drain-Source", "Alan Etkili", "N-Channel", "Switching Devresi", "Threshold Voltage" });
            cardDict.Add("Osiloskop", new string[] { "Zaman-Eksen Grafiği", "Prob Bağlantısı", "Frekans Ölçümü", "Trigger Ayarı", "Dalga Formu" });
            cardDict.Add("Regülatör", new string[] { "7805 Entegre", "Gerilim Sabitleme", "Dropout Voltage", "Linear Regulator", "5 Volt Çıkış" });
            cardDict.Add("Filtre Devresi", new string[] { "RC Low Pass", "Cutoff Frequency", "f=1/2πRC", "Sinyal Gürültü", "Kondansatör Etkisi" });
            cardDict.Add("Zaman Karmaşıklığı", new string[] { "Big O Notasyonu", "O(n log n)", "Worst Case", "Algoritma Analizi", "Asimptotik" });
            cardDict.Add("Recursion", new string[] { "Base Case", "Stack Overflow", "Fonksiyon Kendini Çağırır", "Call Stack", "Factorial Örneği" });
            cardDict.Add("Hash Table", new string[] { "Key-Value", "Collision", "Hash Function", "O(1) Erişim", "Bucket" });
            cardDict.Add("Binary Tree", new string[] { "Root Node", "Left-Right Child", "Traversal", "Inorder", "Height" });
            cardDict.Add("Docker", new string[] { "Container", "Image Build", "Dockerfile", "Port Mapping", "Virtualization" });
            cardDict.Add("Thread", new string[] { "Multithreading", "Concurrency", "Race Condition", "Mutex", "Parallel Execution" });
            cardDict.Add("Compiler", new string[] { "Source Code", "Binary Output", "Syntax Analysis", "Linker", "Executable File" });
            cardDict.Add("SQL Join", new string[] { "INNER JOIN", "Primary Key", "Foreign Key", "Relational Model", "SELECT Sorgusu" });
            cardDict.Add("REST", new string[] { "Stateless", "HTTP Method", "Resource URI", "Client-Server", "CRUD" });
            cardDict.Add("Bernoulli", new string[] { "Akışkan Dinamiği", "Basınç-Hız İlişkisi", "Venturi Tüpü", "Enerji Korunumu", "Akım Çizgisi" });
            cardDict.Add("Hooke Yasası", new string[] { "F=kx", "Yay Sabiti", "Elastik Deformasyon", "Uzama", "Lineer Tepki" });
            cardDict.Add("Termodinamik", new string[] { "Entropi", "Isı-İş Dönüşümü", "Birinci Yasa", "Kapalı Sistem", "PV Diyagramı" });
            cardDict.Add("Reynolds Sayısı", new string[] { "Laminer-Türbülans", "Yoğunluk-Hız", "Boyutsuz", "Akış Analizi", "Re<2300" });
            cardDict.Add("Gerilme", new string[] { "σ=F/A", "Çekme Deneyi", "MPa", "Malzeme Dayanımı", "Hooke Bölgesi" });
            cardDict.Add("Verim", new string[] { "η Sembolü", "Çıkış/Giriş", "Enerji Kaybı", "Yüzde Hesap", "Makine Performansı" });
            cardDict.Add("Akışkanlar Mekaniği", new string[] { "Navier-Stokes", "Viskozite", "Süreklilik Denklemi", "Basınç Alanı", "CFD" });
            cardDict.Add("Titreşim", new string[] { "Doğal Frekans", "Sönüm Oranı", "Harmonik Hareket", "Resonans", "kütle-yay" });
            cardDict.Add("Mekanik Güç", new string[] { "P=Fv", "Dönel Sistem", "RPM", "Şaft Çıkışı", "Watt" });
            cardDict.Add("Simplex", new string[] { "Pivot Kolon", "Temel Çözüm", "Tablo Yöntemi", "Köşe Noktası", "LP" });
            cardDict.Add("Dual Problem", new string[] { "Gölge Fiyat", "Primal", "Min-Max İlişkisi", "Kısıt Dönüşümü", "Ekonomik Yorum" });
            cardDict.Add("Genetik Algoritma", new string[] { "Chromosome", "Mutation", "Crossover", "Fitness Function", "Evrimsel" });
            cardDict.Add("Markov Zinciri", new string[] { "Geçiş Matrisi", "Durum Olasılığı", "Stokastik Süreç", "Memoryless", "π Dağılımı" });
            cardDict.Add("Monte Carlo", new string[] { "Rastgele Sayı", "Simülasyon Deneyi", "Olasılık Yaklaşımı", "Tekrar Sayısı", "İstatistiksel Tahmin" });
            cardDict.Add("MRP", new string[] { "Malzeme İhtiyaç Planlama", "BOM", "Lot Size", "Üretim Takvimi", "Stok Kontrol" });
            cardDict.Add("EOQ", new string[] { "Sipariş Miktarı", "Q*", "Talep Oranı", "Sipariş Maliyeti", "Stok Dengesi" });
            cardDict.Add("AHP", new string[] { "İkili Karşılaştırma", "Saaty", "Tutarlılık Oranı", "Ağırlıklandırma", "Karar Matrisi" });
            cardDict.Add("Queuing Theory", new string[] { "M/M/1", "Bekleme Süresi", "λ ve μ", "Servis Oranı", "Poisson" });
            cardDict.Add("Six Sigma", new string[] { "DMAIC", "3.4 Hata", "Sigma Seviyesi", "Kalite Kontrol", "İstatistiksel Süreç" });
            cardDict.Add("Frekans Cevabı", new string[] { "Bode Çizimi", "dB Ölçeği", "Kazanç Eğrisi", "Faz Kayması", "Transfer Fonksiyonu" });
            cardDict.Add("RMS", new string[] { "Root Mean Square", "Etkin Değer", "Sinüs Dalga", "AC Güç Hesabı", "Ortalama Karekök" });
            cardDict.Add("Topraklama", new string[] { "Referans Potansiyel", "Şase Bağlantısı", "Kaçak Akım", "Güvenlik Hattı", "Earth" });
            cardDict.Add("ADC Çözünürlüğü", new string[] { "Bit Sayısı", "2^n Seviye", "Quantization Error", "Analog Sinyal", "Sampling" });
            cardDict.Add("Veri Yapısı", new string[] { "Bellek Organizasyonu", "Liste-Ağaç", "Algoritma Performansı", "Depolama Mantığı", "Soyutlama" });
            cardDict.Add("Exception", new string[] { "Try-Catch", "Runtime Error", "Throw", "Hata Yakalama", "Program Akışı" });
            cardDict.Add("Thread Senkronizasyonu", new string[] { "Mutex", "Critical Section", "Race Condition", "Lock Mekanizması", "Parallel Kod" });
            cardDict.Add("Cache", new string[] { "Geçici Bellek", "Hit-Miss", "L1 L2", "CPU Erişim", "Performans Artışı" });
            cardDict.Add("Emniyet Katsayısı", new string[] { "Safety Factor", "Tasarım Yükü", "Gerçek Dayanım", "Risk Azaltma", "Malzeme Seçimi" });
            cardDict.Add("Serbest Cisim Diyagramı", new string[] { "FBD", "Kuvvet Okları", "Denge Denklemi", "Statik Analiz", "Moment Hesabı" });
            cardDict.Add("Isı İletimi", new string[] { "Fourier Yasası", "k Katsayısı", "Sıcaklık Gradyanı", "Termal Direnç", "W/mK" });
            cardDict.Add("Basınç Düşümü", new string[] { "Boru İçi Akış", "Sürtünme Kaybı", "ΔP", "Pompa Gücü", "Akışkan Direnci" });
            cardDict.Add("Kapasite Planlama", new string[] { "Talep Tahmini", "Üretim Hattı", "Kaynak Kullanımı", "Darboğaz", "Verimlilik" });
            cardDict.Add("Darboğaz", new string[] { "Bottleneck", "Kapasite Kısıtı", "Akış Yavaşlama", "Üretim Süresi", "Sistem Performansı" });
            cardDict.Add("Simülasyon Modeli", new string[] { "Gerçek Sistem Taklidi", "Parametre Değişimi", "Senaryo Testi", "Rastgelelik", "Analiz" });
            cardDict.Add("Kalite Kontrol", new string[] { "Kontrol Grafiği", "Standart Sapma", "Hata Oranı", "SPC", "Proses İzleme" });
            cardDict.Add("Veri Normalizasyonu", new string[] { "Min-Max", "Z-Score", "Ölçekleme", "Model Eğitimi", "Feature Scaling" });
            cardDict.Add("Doğruluk Oranı", new string[] { "Accuracy", "TP-TN", "Sınıflandırma", "Test Verisi", "Performans Ölçümü" });
            cardDict.Add("Eğitim Verisi", new string[] { "Training Set", "Model Öğrenme", "Etiketli Veri", "Dataset Bölme", "Overfitting Riski" });
            cardDict.Add("Parametre", new string[] { "Model Ağırlığı", "Ayarlanabilir Değer", "Optimizasyon", "Hyperparameter Değil", "Algoritma İç Değeri" });
        }
        else if (GameManager.Instance.category == "Günlük")
        {
            cardDict.Add("Dedikodu", new string[] { "Kulaktan Kulağa", "Gizli Konuşma", "Ortam Muhabbeti", "Üçüncü Kişi", "Fısıltı" });
            cardDict.Add("Abartmak", new string[] { "Olayı Büyütmek", "Gerçek Dışı", "Drama Katmak", "Aşırı Tepki", "Ufak Şeyi Dev Yapmak" });
            cardDict.Add("Takıntı", new string[] { "Sürekli Düşünmek", "Kafaya Takmak", "Aynı Konu", "Obsesif Tavır", "Bırakamamak" });
            cardDict.Add("Gaza Gelmek", new string[] { "Motivasyon Artışı", "Arkadaş Etkisi", "Ani Cesaret", "Coşku Patlaması", "Hemen Yapmak" });
            cardDict.Add("Boş Yapmak", new string[] { "Anlamsız Konuşma", "Gereksiz Muhabbet", "İçi Dolu Değil", "Uzatmak", "Alakasız Yorum" });
            cardDict.Add("Keşfet", new string[] { "Algoritma Akışı", "Yeni İçerik", "Kaydırmalı Sayfa", "Trend Video", "Önerilen Post" });
            cardDict.Add("Takipten Çıkmak", new string[] { "Unfollow", "Profil Listesi", "Sessizce Silmek", "Story Görmemek", "Takipçi Azalması" });
            cardDict.Add("Beğeni", new string[] { "Kalp Butonu", "Like Sayısı", "Çift Tık", "Etkileşim Oranı", "Post Altı" });
            cardDict.Add("DM", new string[] { "Özel Mesaj", "Gizli Sohbet", "Instagram Kutusu", "Yanıt Atmak", "Yazışma Ekranı" });
            cardDict.Add("Devamsızlık", new string[] { "Yoklama Listesi", "İmza Atmak", "Yüzde Sınırı", "Hoca Kontrolü", "Derse Girmemek" });
            cardDict.Add("Kopya", new string[] { "Sınav Kağıdı", "Yan Sıra", "Çekmek", "Yakalanmak", "Disiplin" });
            cardDict.Add("Hoca Favorisi", new string[] { "Sürekli Söz Almak", "Ödev Notu Yüksek", "İyi İletişim", "Ekstra İlgi", "Örnek Öğrenci" });
            cardDict.Add("Bariz", new string[] { "Çok Belli", "Gözle Görülür", "Saklanamamak", "Açık Davranış", "Net Durum" });
            cardDict.Add("İnat", new string[] { "Geri Adım Atmamak", "Haklı Çıkma Çabası", "Tartışma Uzatmak", "Karar Değişmemek", "Direnmek" });
            cardDict.Add("Flörtöz", new string[] { "Herkese İlgi", "Göz Teması", "Tatlı Tavır", "Samimi Davranış", "Mesajlaşma Seven" });
            cardDict.Add("Sunum", new string[] { "Slayt Gösterisi", "PowerPoint", "Projeksiyon", "Toplantı Salonu", "Konuşma Yapmak" });
            cardDict.Add("Mesai", new string[] { "Çalışma Saati", "Fazla Kalmak", "Ofiste Uzamak", "Akşam Çıkış", "Yorgunluk" });
            cardDict.Add("Prim", new string[] { "Ek Ödeme", "Performans Artışı", "Satış Hedefi", "Bonus", "Maaş Dışı" });
            cardDict.Add("Viral", new string[] { "Hızlı Yayılmak", "Paylaşım Patlaması", "Gündem Olmak", "Trend Listesi", "Çok İzlenme" });
            cardDict.Add("Challenge", new string[] { "Meydan Okuma", "Trend Hareket", "Video Akımı", "Katılım Zinciri", "Sosyal Medya Görevi" });
            cardDict.Add("Akım", new string[] { "Trend Hareket", "Toplu Katılım", "Popüler İçerik", "Aynı Format", "Gündem Dalgası" });
            cardDict.Add("Simp", new string[] { "Aşırı İlgi", "Tek Taraflı", "Kendini Küçültmek", "Karşılıksız Çaba", "Abartı İlgi" });
            cardDict.Add("NPC", new string[] { "Aynı Tepki", "Robot Gibi", "Ezbere Davranış", "Oyun Karakteri", "Tepkisiz Tip" });
            cardDict.Add("Shiplemek", new string[] { "İkisini Yakıştırmak", "Fan Hayali", "Çift Olsun İstemek", "Dizi Karakteri", "Romantik Beklenti" });
            cardDict.Add("Ertelemek", new string[] { "Sonraya Bırakmak", "Prokrastinasyon", "Bugün Değil", "Teslim Tarihi", "Üşenmek" });
            cardDict.Add("Bahane", new string[] { "Gerçek Sebep Değil", "Uydurma Neden", "Kaçış Yolu", "Sorumluluktan Kaçmak", "Mazeret" });
            cardDict.Add("Şans", new string[] { "Tesadüf", "Kısmet", "Talih", "Beklenmedik İyi Olay", "Uğur" });
            cardDict.Add("Hype", new string[] { "Aşırı Heyecan", "Toplu İlgi", "Önceden Övgü", "Beklenti Patlaması", "Trend Öncesi" });
            cardDict.Add("Manipülasyon", new string[] { "Duygusal Yönlendirme", "Suçluluk Hissettirmek", "Kontrol Etme", "Psikolojik Baskı", "İnce Hesap" });
            cardDict.Add("İma", new string[] { "Dolaylı Söylem", "Açıkça Dememek", "Mesaj Vermek", "Laf Çakmak", "Alt Metin" });
            cardDict.Add("Karizma", new string[] { "Doğal Çekicilik", "Ortam Etkisi", "Lider Aurası", "Duruş", "Manyetik Etki" });
            cardDict.Add("Özgüven", new string[] { "Kendinden Emin", "Göz Teması", "Rahat Tavır", "Dik Duruş", "Cesaretli" });
            cardDict.Add("Alınganlık", new string[] { "Üzerine Almak", "Hemen Kırılmak", "Sözden Etkilenmek", "Hassasiyet", "Yanlış Anlamak" });
            cardDict.Add("Motivasyon", new string[] { "Hedef Odaklı", "İçsel Güç", "Gaza Gelmek", "İstek Artışı", "Başarma Hevesi" });
            cardDict.Add("Kibir", new string[] { "Üstten Bakmak", "Aşırı Ego", "Kendini Büyük Görmek", "Alçakgönüllü Olmamak", "Büyüklük Hissi" });
            cardDict.Add("Samimiyet", new string[] { "İçten Davranış", "Resmiyet Yok", "Sıcak İletişim", "Doğallık", "Yapay Olmamak" });
            cardDict.Add("FOMO", new string[] { "Fear Of Missing Out", "Kaçırma Korkusu", "Sosyal Baskı", "Story Kontrol", "Etkinlik Endişesi" });
            cardDict.Add("Trend", new string[] { "Popüler Akım", "Gündem Hareket", "Viral İçerik", "Moda Olmak", "Keşfet Etkisi" });
            cardDict.Add("Algoritma", new string[] { "Keşfet Sıralama", "Etkileşim Oranı", "İçerik Önerisi", "Gösterim Artışı", "Sistem Mantığı" });
            cardDict.Add("Etkileşim", new string[] { "Like Yorum", "Paylaşım Sayısı", "Geri Dönüş", "Takipçi Aktivitesi", "Post Altı" });
            cardDict.Add("Tıklanma", new string[] { "View Sayısı", "Video İzlenme", "YouTube Analitik", "Başlık Etkisi", "Thumbnail" });
            cardDict.Add("Filtre", new string[] { "Yüz Efekti", "Renk Ayarı", "Story Özelliği", "Görsel Düzenleme", "Uygulama Aracı" });
            cardDict.Add("Sponsorlu", new string[] { "Reklam İş Birliği", "Marka Anlaşması", "Paid Partnership", "PR Ürünü", "Tanıtım Postu" });
            cardDict.Add("Proje Sunumu", new string[] { "Slayt Tasarımı", "Sınıf Önü", "Değerlendirme Kriteri", "Sunum Süresi", "Notlandırma" });
            cardDict.Add("Ortalama", new string[] { "GPA", "Kredi Hesabı", "Ders Notu", "Harflendirme", "Dönem Sonu" });
            cardDict.Add("Danışman", new string[] { "Akademik Hoca", "İmza Onayı", "Ders Seçimi", "Proje Yönlendirme", "Bölüm" });
            cardDict.Add("Kulüp", new string[] { "Topluluk Faaliyeti", "Etkinlik Organizasyon", "Üye Listesi", "Yönetim Kurulu", "Stant Açmak" });
            cardDict.Add("Bütünleme", new string[] { "Final Tekrarı", "Geçme Şansı", "Yaz Okulu Öncesi", "Ek Sınav", "Not Yükseltme" });
            cardDict.Add("Karma", new string[] { "Ettiğini Bulmak", "Evrene İnanmak", "Geri Dönüş", "Enerji Meselesi", "Hak Etmek" });
            cardDict.Add("Flörtleşmek", new string[] { "Tatlı Mesaj", "Göz Teması", "İlgi Göstermek", "Henüz Sevgili Değil", "Emoji Kullanımı" });
            cardDict.Add("Soğumak", new string[] { "İlgi Azalması", "Mesafe Koymak", "Eskisi Gibi Değil", "Heyecan Bitmesi", "Uzaklaşmak" });
            cardDict.Add("Takip Etmek", new string[] { "Profil Kontrol", "Story İzlemek", "Sosyal Medya Gözetleme", "Eski Postlar", "Sessizce Bakmak" });
            cardDict.Add("Barışma Teklifi", new string[] { "Özür Mesajı", "Gurur Yutmak", "Tekrar Denemek", "Gece Mesajı", "Kırgınlık Sonu" });
            cardDict.Add("Performans", new string[] { "Hedef Gerçekleşme", "Aylık Rapor", "Verimlilik Oranı", "Yönetici Değerlendirme", "Prim Sistemi" });
            cardDict.Add("Toplantı Notu", new string[] { "Ajanda Maddesi", "Karar Listesi", "Zoom Kaydı", "Mail Özeti", "Gündem" });
            cardDict.Add("Sunum Taslağı", new string[] { "PowerPoint Şablon", "Başlık Slaytı", "Grafik Ekleme", "Tasarım Düzeni", "Proje Anlatımı" });
            cardDict.Add("Geri Bildirim", new string[] { "Feedback", "Yapıcı Eleştiri", "Performans Yorumu", "İyileştirme Önerisi", "Toplantı Sonrası" });
            cardDict.Add("Terfi", new string[] { "Pozisyon Artışı", "Maaş Yükselmesi", "Yetki Genişleme", "Kariyer Adımı", "Üst Kademe" });
            cardDict.Add("Gaslighting", new string[] { "Gerçekliği Sorgulatmak", "Manipülatif Davranış", "Psikolojik Oyun", "Kendini Suçlu Hissettirmek", "İlişki Terimi" });
            cardDict.Add("Flexlemek", new string[] { "Gösteriş Yapmak", "Lüks Paylaşım", "Başarı Story", "Hava Atmak", "Öne Çıkarmak" });
            cardDict.Add("Lowkey", new string[] { "Fazla Belli Etmeden", "Sessizce", "Abartısız", "Gizli Hoşlanma", "Düşük Profil" });
            cardDict.Add("Highkey", new string[] { "Açıkça", "Net Şekilde", "Saklamadan", "Yüksek Profil", "Belli Etmek" });
            cardDict.Add("Vibe", new string[] { "Enerji Uyumu", "Ortam Hissi", "Aura", "Hava Katmak", "Ruh Hali" });
            cardDict.Add("Ergenlik", new string[] { "Duygusal Dalgalanma", "Kimlik Arayışı", "Asi Tavır", "Büyüme Süreci", "Gençlik Dönemi" });
            cardDict.Add("Bahane Üretmek", new string[] { "Mazeret Uydurmak", "Gerçek Sebep Gizlemek", "Kaçış Planı", "Sorumluluktan Kaçmak", "Zorunlu Değil Demek" });
            cardDict.Add("Sosyalleşmek", new string[] { "Arkadaş Buluşması", "Ortam Kurmak", "Muhabbet", "Toplu Aktivite", "Dışarı Çıkmak" });
            cardDict.Add("Plan Yapmak", new string[] { "Takvim Belirlemek", "Etkinlik Ayarlamak", "Saat Netleştirmek", "Program Oluşturmak", "Buluşma" });
            cardDict.Add("Kariyer", new string[] { "İş Hayatı", "Uzun Vadeli Hedef", "Meslek Planı", "Terfi Süreci", "Profesyonel Yol" });
            cardDict.Add("Dedikodu Zinciri", new string[] { "Kulaktan Kulağa", "Bilgi Yayılması", "Ortam Konuşması", "Abartı Katmak", "Gizli Muhabbet" });
            cardDict.Add("Popülerlik", new string[] { "Çok Tanınmak", "Takipçi Fazla", "Ortamın Gözdesi", "Sosyal İlgi", "Trend Olmak" });
            cardDict.Add("Ön Yargı", new string[] { "Tanımadan Yorum", "Kalip Yargı", "Hızlı Karar", "Peşin Hüküm", "Yanlış Algı" });
            cardDict.Add("Kriz", new string[] { "Ani Sorun", "Stres Artışı", "Çözüm Aramak", "Beklenmedik Olay", "Durum Yönetimi" });
            cardDict.Add("Fırsat", new string[] { "Değerlendirmek", "Avantaj Sağlamak", "Zamanlama", "Şans Yakalamak", "Doğru An" });
            cardDict.Add("Narsisizm", new string[] { "Kendine Hayranlık", "Aşırı Ego", "Empati Eksikliği", "Kişilik Özelliği", "Öz Sevgi Abartısı" });
            cardDict.Add("Pasif Agresif", new string[] { "Dolaylı Tepki", "İma Yoluyla", "Sessiz Tavır", "Soğuk Davranış", "Açıkça Söylememek" });
            cardDict.Add("Manipülatif", new string[] { "Duygusal Yönlendirme", "Suçluluk Hissettirmek", "Kontrol Etmek", "Psikolojik Baskı", "İnce Hesap" });
            cardDict.Add("Yansıtma", new string[] { "Kendi Hatasını", "Karşı Tarafa Atmak", "Psikolojik Savunma", "Suçlama Mekanizması", "Projeksiyon" });
            cardDict.Add("Algı Yönetimi", new string[] { "İmaj Kontrolü", "Kamuoyu Etkisi", "Medya Stratejisi", "Manipülasyon Tekniği", "Görünürlük Ayarı" });
            cardDict.Add("Toksik Pozitiflik", new string[] { "Sürekli İyi Olmak", "Olumsuzluğu Bastırmak", "Gerçekçi Olmamak", "Zorla Mutluluk", "Duyguları Yok Saymak" });
            cardDict.Add("İptal Kültürü", new string[] { "Toplu Tepki", "Boykot Çağrısı", "Sosyal Linç", "Takibi Bırakmak", "Gündemden Silmek" });
            cardDict.Add("Parasosyal", new string[] { "Tek Taraflı Bağ", "Ünlü Hayranlığı", "Gerçek Sanmak", "Sosyal Medya Figürü", "Hayali Yakınlık" });
            cardDict.Add("Love Bombing", new string[] { "Aşırı İlgi", "Hızlı Yoğunluk", "Manipülasyon Başlangıcı", "Abartılı Sevgi", "Sonradan Geri Çekilme" });
            cardDict.Add("Breadcrumbing", new string[] { "Ufak İlgi Kırıntısı", "Oyalamak", "Net Olmamak", "Sürekli Umut Vermek", "Kararsız Davranış" });
            cardDict.Add("Ghosting", new string[] { "Aniden Kaybolmak", "Cevap Vermemek", "İletişimi Kesmek", "Mesaj Görüldü", "Sessiz Ayrılık" });
            cardDict.Add("Situationship", new string[] { "Adı Konmamış", "Belirsiz İlişki", "Netlik Yok", "Sevgili Değil", "Kararsızlık" });
            cardDict.Add("Prokrastinasyon", new string[] { "Erteleme Alışkanlığı", "Son Dakika", "Motivasyon Eksikliği", "Yarın Yapmak", "Zaman Yönetimi Sorunu" });
            cardDict.Add("Empati", new string[] { "Karşı Tarafı Anlamak", "Duygu Paylaşımı", "Kendini Yerine Koymak", "Anlayışlı Tavır", "Duygusal Zeka" });
            cardDict.Add("Kolektif Bilinç", new string[] { "Toplumsal Hafıza", "Ortak Duygu", "Jung Kavramı", "Grup Psikolojisi", "Toplu Tepki" });
            cardDict.Add("Dezenformasyon", new string[] { "Yanlış Bilgi", "Kasıtlı Yayılım", "Medya Manipülasyonu", "Algı Çarpıtma", "Gerçek Dışı Haber" });
            cardDict.Add("Mobbing", new string[] { "Psikolojik Baskı", "İş Yerinde Yıldırma", "Sistematik Davranış", "Çalışan Üzerinde", "Taciz Süreci" });
            cardDict.Add("Networking", new string[] { "Bağlantı Kurmak", "Profesyonel İletişim", "LinkedIn", "Kariyer Fırsatı", "Çevre Edinmek" });
            cardDict.Add("Delegasyon", new string[] { "Görev Devri", "Yetki Aktarma", "Sorumluluk Paylaşımı", "Yönetim Becerisi", "Takım İçinde" });
            cardDict.Add("Kriz Yönetimi", new string[] { "Acil Durum Planı", "Hasar Kontrolü", "Stratejik Karar", "Stres Altında", "Problem Çözme" });
        }


    }

    void InitializeAllCards()
    {
        allCards = new List<string>(cardDict.Keys);
        Shuffle(allCards);
        currentIndex = 0;
    }

    void ShowCard(string key)
    {
        cevapText.text = key;
        string[] y = cardDict[key];
        yasakli1.text = y[0];
        yasakli2.text = y[1];
        yasakli3.text = y[2];
        yasakli4.text = y[3];
        yasakli5.text = y[4];
    }

    public void ShowNext()
    {
        if (allCards.Count == 0) return;

        ShowCard(allCards[currentIndex]);

        currentIndex++;
        if (currentIndex >= allCards.Count)
            currentIndex = 0;
    }


    // Kartı bildim veya pas geç dedik, en sona taşı
    public void MoveCurrentCardToEnd()
    {
        string card = allCards[currentIndex];
        allCards.RemoveAt(currentIndex);
        allCards.Add(card);

        // Eğer son karta geldiysek başa dön
        if (currentIndex >= allCards.Count)
            currentIndex = 0;

        ShowNext();
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int r = Random.Range(i, list.Count);
            (list[i], list[r]) = (list[r], list[i]);
        }
    }
}
