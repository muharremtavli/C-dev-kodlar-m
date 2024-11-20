using System;
using System.Collections.Generic;

class Calisan
{
    public string Ad { get; set; }
    public string Pozisyon { get; set; }

    public Calisan(string ad, string pozisyon)
    {
        Ad = ad;
        Pozisyon = pozisyon;
    }

    public void CalisanBilgisi()
    {
        Console.WriteLine($"Çalışan Adı: {Ad}, Pozisyon: {Pozisyon}");
    }
}

class Sirket
{
    public string Ad { get; set; }
    public List<Calisan> Calisanlar { get; set; }

    public Sirket(string ad)
    {
        Ad = ad;
        Calisanlar = new List<Calisan>();
    }

    public void CalisanEkle(Calisan calisan)
    {
        Calisanlar.Add(calisan);
    }

    public void SirketBilgileriniYazdir()
    {
        Console.WriteLine($"Şirket Adı: {Ad}");
        Console.WriteLine("Çalışanlar:");
        foreach (var calisan in Calisanlar)
        {
            calisan.CalisanBilgisi();
        }
    }
}

namespace sirketCalisanUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Şirket oluşturma
            Sirket sirket1 = new Sirket("ABC Teknoloji");

            // Çalışanlar oluşturma
            Calisan calisan1 = new Calisan("Ali Veli", "Yazılım Mühendisi");
            Calisan calisan2 = new Calisan("Ayşe Demir", "Proje Yöneticisi");
            Calisan calisan3 = new Calisan("Mehmet Can", "Sistem Analisti");

            // Çalışanları şirkete ekleme
            sirket1.CalisanEkle(calisan1);
            sirket1.CalisanEkle(calisan2);
            sirket1.CalisanEkle(calisan3);

            // Şirket bilgilerini yazdırma
            sirket1.SirketBilgileriniYazdir();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
