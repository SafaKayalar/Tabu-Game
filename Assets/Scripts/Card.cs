using System.Collections.Generic;
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
        InitializeAllCards(); // Tüm kartlarý listeye al
        ShowNext();
    }

    void BuildWordList()
    {
        cardDict.Clear();
        if(GameManager.Instance.category == "Oyun")
        {        
            cardDict.Add("Strateji", new string[] { "hamle", "düþman", "kaynak", "savunma", "zafer" });
            cardDict.Add("Rol Yapma", new string[] { "karakter", "geliþim", "görev", "savaþ", "büyü" });
            cardDict.Add("Bulmaca", new string[] { "zeka", "çözüm", "ipucu", "labirent", "karmaþýk" });
            cardDict.Add("Kart Oyunu", new string[] { "destek", "taktik", "el", "puan", "rakip" });
            cardDict.Add("Simülasyon", new string[] { "kontrol", "senaryo", "gerçeklik", "model", "ayarlama" });
            cardDict.Add("Macera", new string[] { "keþif", "engel", "harita", "gizem", "hikaye" });
            cardDict.Add("Aksiyon", new string[] { "saldýrý", "refleks", "silah", "hýz", "tehlike" });
            cardDict.Add("Savaþ", new string[] { "strateji", "ordular", "kuþatma", "müttefik", "kayýp" });
            cardDict.Add("Zindan", new string[] { "tuzaðý", "anahtar", "canavar", "hazine", "karanlýk" });
            cardDict.Add("Hayatta Kalma", new string[] { "açlýk", "barýnak", "su", "savunma", "tehdit" });
            cardDict.Add("Spor", new string[] { "puan", "hakem", "turnuva", "antrenman", "rekabet" });
            cardDict.Add("Yarýþ", new string[] { "hýz", "viraj", "rakip", "kaza", "zafer" });
            cardDict.Add("Platform", new string[] { "zýplama", "engel", "düþme", "denge", "hedef" });
            cardDict.Add("Korku", new string[] { "hayalet", "karanlýk", "gerilim", "tuzaðý", "kaçýþ" });
            cardDict.Add("MOBA", new string[] { "kahraman", "minyon", "koridor", "taktik", "eþya" });
            cardDict.Add("FPS", new string[] { "niþan", "cephane", "hedef", "refleks", "kalkan" });
            cardDict.Add("Taktik", new string[] { "pozisyon", "koordine", "savunma", "saldýrý", "öngörü" });
            cardDict.Add("Mücadele", new string[] { "direniþ", "zafer", "rakip", "strateji", "risk" });
            cardDict.Add("Zeka Oyunu", new string[] { "mantýk", "analiz", "çözüm", "tahmin", "karmaþýk" });
            cardDict.Add("Roguelike", new string[] { "rastgele", "tekrar", "zorluk", "keþif", "hayatta kalma" });
            cardDict.Add("Arena", new string[] { "dövüþ", "rakip", "strateji", "zafer", "taktik" });
            cardDict.Add("Ekonomi", new string[] { "yatýrým", "kaynak", "bütçe", "piyasa", "kar" });
            cardDict.Add("Uzay", new string[] { "yýldýz", "gemi", "galaksi", "rota", "karadelik" });
            cardDict.Add("Zombi", new string[] { "bulaþýcý", "kaçýþ", "sýðýnak", "tehdit", "silah" });
            cardDict.Add("Casusluk", new string[] { "gizli", "görev", "kod", "kamera", "kaçýþ" });
            cardDict.Add("Korsan", new string[] { "hazine", "gemi", "rota", "savaþ", "deniz" });
            cardDict.Add("Mitoloji", new string[] { "tanrý", "efsane", "canavar", "görev", "büyü" });
            cardDict.Add("Vampir", new string[] { "gece", "kan", "gölge", "av", "gizem" });
            cardDict.Add("Sihirbazlýk", new string[] { "ikna", "büyü", "kart", "hile", "taktik" });
            cardDict.Add("Robot", new string[] { "program", "çip", "sensör", "görev", "kontrol" });
            cardDict.Add("F", new string[] { "Saygý", "Cenaze", "Tuþ", "Basmak", "Call of Duty" });
            cardDict.Add("Rush B", new string[] { "CS:GO", "Saldýrmak", "Taktik", "Dust 2", "P90" });
            cardDict.Add("Rage Quit", new string[] { "Sinir", "Çýkmak", "Alt F4", "Klavye", "Kýrmak" });
            cardDict.Add("Camper", new string[] { "Pusucu", "Beklemek", "Köþe", "Çadýr", "Sniper" });
            cardDict.Add("GG", new string[] { "Good Game", "Ýyi", "Bitti", "Tebrik", "Kolay" });
            cardDict.Add("AFK", new string[] { "Uzak", "Klavye", "Gitmek", "Hareket", "Durmak" });
            cardDict.Add("Nerf", new string[] { "Güçsüz", "Zayýflatmak", "Silah", "Karakter", "Yama" });
            cardDict.Add("Smurf", new string[] { "Hesap", "Mavi", "Düþük", "Profesyonel", "Ezmek" });
            cardDict.Add("Teabag", new string[] { "Çömelmek", "Kalkmak", "Ceset", "Hareket", "Dalga" });
            cardDict.Add("P2W", new string[] { "Para", "Kazanmak", "Zengin", "Ücretli", "Avantaj" });
            cardDict.Add("Troll", new string[] { "Þaka", "Bozmak", "Ciddi", "Feed", "Kýzdýrmak" });
            cardDict.Add("Git Gud", new string[] { "Öðren", "Beceriksiz", "Dark Souls", "Kötü", "Tavsiye" });
            cardDict.Add("Speedrun", new string[] { "Hýzlý", "Bitirmek", "Rekor", "Süre", "Glitch" });
            cardDict.Add("Ez", new string[] { "Kolay", "Basit", "Easy", "Noob", "Yenmek" });
            cardDict.Add("Mainlemek", new string[] { "Karakter", "Sürekli", "Oynamak", "Favori", "Seçmek" });
            cardDict.Add("Carry", new string[] { "Taþýmak", "Sýrtlamak", "Takým", "Güçlü", "Kazandýrmak" });
            cardDict.Add("Support", new string[] { "Destek", "Yardým", "Heal", "Yan", "Koruma" });
            cardDict.Add("Tank", new string[] { "Zýrh", "Can", "Dayanýklý", "Ön", "Hasar" });
            cardDict.Add("Jungler", new string[] { "Ormancý", "Gank", "Lane", "Koridor", "Canavar" });
            cardDict.Add("Feeder", new string[] { "Beslemek", "Ölmek", "Bilerek", "Rakip", "Kötü" });
            cardDict.Add("Tryhard", new string[] { "Ciddi", "Terlemek", "Zorlamak", "Eðlence", "Kazanmak" });
            cardDict.Add("Ban", new string[] { "Yasak", "Hesap", "Atýlmak", "Perma", "Süreli" });
            cardDict.Add("Report", new string[] { "Þikayet", "Bildirmek", "Ban", "Küfür", "Oyun Sonu" });
            cardDict.Add("KDA", new string[] { "Skor", "Oran", "Kill", "Death", "Assist" });
            cardDict.Add("Buff", new string[] { "Güçlendirme", "Özellik", "Yama", "Artý", "Nerf" });
            cardDict.Add("Ulti", new string[] { "Yetenek", "Son", "Güçlü", "R Tuþu", "Bekleme" });
            cardDict.Add("Lobby", new string[] { "Bekleme", "Oda", "Baþlamak", "Davet", "Arkadaþ" });
            cardDict.Add("Grind", new string[] { "Kasmak", "Tekrar", "Level", "Eþya", "Sýkýcý" });
            cardDict.Add("Drop", new string[] { "Düþmek", "FPS", "Kutu", "Ýnternet", "Þans" });
            cardDict.Add("Hitbox", new string[] { "Vuruþ", "Alan", "Karakter", "Mermi", "Deðmek" });
            cardDict.Add("RGB", new string[] { "Iþýk", "Renkli", "Klavye", "Oyuncu", "Led" });
            cardDict.Add("Mekanik", new string[] { "Klavye", "Ses", "Switch", "Tuþ", "Pahalý" });
            cardDict.Add("Hz", new string[] { "Hertz", "Monitör", "Ekran", "Yenileme", "144" });
            cardDict.Add("SSD", new string[] { "Hýzlý", "Disk", "Depolama", "Yükleme", "Harddisk" });
            cardDict.Add("GPU", new string[] { "Ekran Kartý", "Grafik", "Görüntü", "Ýþlemci", "Pahalý" });
            cardDict.Add("Console Peasant", new string[] { "Konsol", "PC", "Fakir", "30 FPS", "Kol" });
            cardDict.Add("PC Master Race", new string[] { "Bilgisayar", "Üstün", "Toplamak", "Kasa", "Performans" });
            cardDict.Add("Son El", new string[] { "Yalan", "Uyumak", "Gece", "Oynamak", "Kapatmak" });
            cardDict.Add("Alt F4", new string[] { "Kapatmak", "Çýkmak", "Kýsayol", "Sinir", "Hile" });
            cardDict.Add("Backseat", new string[] { "Karýþmak", "Arkadan", "Söylemek", "Öðretmek", "Ýzlemek" });
            cardDict.Add("Spoiler", new string[] { "Söylemek", "Sonu", "Hikaye", "Tat", "Film" });
            cardDict.Add("Clickbait", new string[] { "Týklamak", "Yalan", "Baþlýk", "Video", "Resim" });
            cardDict.Add("Gaben", new string[] { "Steam", "Valve", "Half Life 3", "Ýndirim", "Cüzdan" });
            cardDict.Add("Lore", new string[] { "Hikaye", "Evren", "Geçmiþ", "Derin", "Arka Plan" });
            cardDict.Add("Easter Egg", new string[] { "Gizli", "Sürpriz", "Yumurta", "Paskalya", "Bulmak" });
            cardDict.Add("Save", new string[] { "Kaydetmek", "Dosya", "Kaldýðýn Yer", "Hafýza", "Yüklemek" });
            cardDict.Add("Checkpoint", new string[] { "Nokta", "Kayýt", "Dönmek", "Ölünce", "Bayrak" });
            cardDict.Add("Tutorial", new string[] { "Eðitim", "Öðretici", "Baþlangýç", "Göstermek", "Ders" });
            cardDict.Add("Loading", new string[] { "Yükleniyor", "Ekran", "Beklemek", "Dolmak", "Yüzde" });
            cardDict.Add("Open World", new string[] { "Açýk Dünya", "Harita", "Gezmek", "Özgür", "GTA" });
            cardDict.Add("Battle Pass", new string[] { "Bilet", "Sezon", "Ödül", "Seviye", "Paralý" });
            cardDict.Add("Co-op", new string[] { "Beraber", "Arkadaþ", "Ýki Kiþilik", "Yardýmlaþma", "Takým" });
            cardDict.Add("Crossplay", new string[] { "Platform", "Konsol", "PC", "Birlikte", "Eþleþme" });
            cardDict.Add("Quick Time Event", new string[] { "Tuþ", "Basmak", "Zaman", "Sinematik", "Refleks" });
            cardDict.Add("Craft", new string[] { "Yapmak", "Üretmek", "Birleþtirmek", "Masa", "Eþya" });
            cardDict.Add("Headshot", new string[] { "Kafa", "Vurmak", "Tek", "Niþan", "Kritik" });
            cardDict.Add("Wallhack", new string[] { "Duvar", "Görmek", "Hile", "Arka", "Saydam" });
            cardDict.Add("Aimbot", new string[] { "Otomatik", "Niþan", "Hile", "Kafa", "Program" });
            cardDict.Add("Clutch", new string[] { "Tek Baþýna", "Kazandýrmak", "Son", "Çevirmek", "Heyecan" });
            cardDict.Add("Ace", new string[] { "Herkes", "Vurmak", "Takým", "Temizlemek", "5 Kiþi" });
            cardDict.Add("One Shot", new string[] { "Tek", "Can", "Vuruþ", "Ölmek", "Mermi" });
            cardDict.Add("Spray", new string[] { "Taramak", "Sekmek", "Duvar", "Desen", "Basýlý Tutmak" });
            cardDict.Add("Stun", new string[] { "Sersem", "Durdurmak", "Hareket", "Bayýlmak", "Kitlemek" });
            cardDict.Add("Friendly Fire", new string[] { "Dost", "Ateþ", "Vurmak", "Takým", "Zarar" });
            cardDict.Add("Streamer", new string[] { "Yayýncý", "Twitch", "Kamera", "Canlý", "Ýzleyici" });
            cardDict.Add("Discord", new string[] { "Konuþmak", "Sesli", "Sunucu", "Arkadaþ", "Uygulama" });
            cardDict.Add("Toxic", new string[] { "Zehirli", "Küfür", "Kötü", "Davranýþ", "Sinir" });
            cardDict.Add("Mod", new string[] { "Deðiþiklik", "Yama", "Dosya", "Eklemek", "Orijinal" });
            cardDict.Add("Emulator", new string[] { "Program", "Konsol", "PC", "Eski", "Çalýþtýrmak" });
            cardDict.Add("Jumpscare", new string[] { "Korkmak", "Zýplamak", "Aniden", "Çýðlýk", "Ekrana Fýrlamak" });
            cardDict.Add("DLC", new string[] { "Ek Paket", "Ýçerik", "Satýn Almak", "Ýndirmek", "Geniþleme" });
            cardDict.Add("Gank", new string[] { "Baskýn", "Sayýca Üstün", "Pusu", "Koridor", "Yardým" });
            cardDict.Add("Mousepad", new string[] { "Fare", "Altlýk", "Kaymak", "Kumaþ", "Masa" });
        }
        else if(GameManager.Instance.category == "Mutfak")
        {
            cardDict.Add("Çatal", new string[] { "Kaþýk", "Býçak", "Yemek", "Batýrmak", "Akþam" });
            cardDict.Add("Tencere", new string[] { "Ocak", "Piþirmek", "Yemek", "Tava", "Fýrýn" });
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


    // Kartý bildim veya pas geç dedik, en sona taþý
    public void MoveCurrentCardToEnd()
    {
        string card = allCards[currentIndex];
        allCards.RemoveAt(currentIndex);
        allCards.Add(card);

        // Eðer son karta geldiysek baþa dön
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
