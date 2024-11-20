using System;
using System.Collections.Generic;

class Calisan
{
    public string Ad { get; set; }
    public int Maas { get; set; }
    public Sirket Sirket { get; set; }

    public Calisan(string ad, int maas)
    {
        Ad = ad;
        Maas = maas;
    }

    public void SirketAtama(Sirket sirket)
    {
        Sirket = sirket;
        sirket.CalisanEkle(this); // Çalışanı şirkete ekliyoruz
    }

    public void CalisanBilgileriniYazdir()
    {
        Console.WriteLine($"Çalışan Adı: {Ad}, Maaş: {Maas} TL, Şirket: {(Sirket != null ? Sirket.Ad : "Atanmadı")}");
    }
}

class Sirket
{
    public string Ad { get; set; }
    public string Konum { get; set; }
    public List<Calisan> Calisanlar { get; set; }

    public Sirket(string ad, string konum)
    {
        Ad = ad;
        Konum = konum;
        Calisanlar = new List<Calisan>();
    }

    public void CalisanEkle(Calisan calisan)
    {
        Calisanlar.Add(calisan);
    }

    public void SirketBilgileriniYazdir()
    {
        Console.WriteLine($"Şirket Adı: {Ad}, Konum: {Konum}");
        Console.WriteLine("Çalışanlar:");
        foreach (var calisan in Calisanlar)
        {
            Console.WriteLine($"  Çalışan Adı: {calisan.Ad}, Maaş: {calisan.Maas} TL");
        }
    }
}

namespace sirketCalisanUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Şirketler oluşturma
            Sirket sirket1 = new Sirket("TAVLI Softek", "Bingöl");
            Sirket sirket2 = new Sirket("TAVLI Nakliyat", "Bingöl");

            // Çalışanlar oluşturma
            Calisan calisan1 = new Calisan("Muharrem Tavlı", 10000);
            Calisan calisan2 = new Calisan("Abdulvahap Tavlı", 10000);
            Calisan calisan3 = new Calisan("Melik Tavlı", 10000);

            // Çalışanları şirketlere atama
            calisan1.SirketAtama(sirket1);
            calisan2.SirketAtama(sirket1);
            calisan3.SirketAtama(sirket2);

            // Şirket ve çalışan bilgilerini yazdırma
            sirket1.SirketBilgileriniYazdir();
            sirket2.SirketBilgileriniYazdir();

            calisan1.CalisanBilgileriniYazdir();
            calisan2.CalisanBilgileriniYazdir();
            calisan3.CalisanBilgileriniYazdir();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}