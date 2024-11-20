using System;
using System.Collections.Generic;

class Kitap
{
    public string Baslik { get; set; }
    public DateTime YayınTarihi { get; set; }
    public Yazar Yazar { get; set; }

    public Kitap(string baslik, DateTime yayinTarihi)
    {
        Baslik = baslik;
        YayınTarihi = yayinTarihi;
    }

    public void YazarAtama(Yazar yazar)
    {
        Yazar = yazar;
        yazar.KitapEkle(this); // Kitabı yazara ekliyoruz
    }

    public void KitapBilgileriniYazdir()
    {
        Console.WriteLine($"Kitap Başlığı: {Baslik}, Yayın Tarihi: {YayınTarihi.ToShortDateString()}, Yazar: {Yazar.Ad}");
    }
}

class Yazar
{
    public string Ad { get; set; }
    public string Ulke { get; set; }
    public List<Kitap> Kitaplar { get; set; }

    public Yazar(string ad, string ulke)
    {
        Ad = ad;
        Ulke = ulke;
        Kitaplar = new List<Kitap>();
    }

    public void KitapEkle(Kitap kitap)
    {
        Kitaplar.Add(kitap);
    }

    public void YazarBilgileriniYazdir()
    {
        Console.WriteLine($"Yazar Adı: {Ad}, Ülke: {Ulke}");
        Console.WriteLine("Yazarın Yazdığı Kitaplar:");
        foreach (var kitap in Kitaplar)
        {
            Console.WriteLine($"  Kitap Başlığı: {kitap.Baslik}, Yayın Tarihi: {kitap.YayınTarihi.ToShortDateString()}");
        }
    }
}

namespace kitapYazarUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Yazarlar oluşturma
            Yazar yazar1 = new Yazar("Orhan Pamuk", "Türkiye");
            Yazar yazar2 = new Yazar("Gabriel García Márquez", "Kolombiya");

            // Kitaplar oluşturma
            Kitap kitap1 = new Kitap("Benim Adım Kırmızı", new DateTime(1998, 1, 1));
            Kitap kitap2 = new Kitap("Sessiz Ev", new DateTime(1983, 1, 1));
            Kitap kitap3 = new Kitap("Yüzyıllık Yalnızlık", new DateTime(1967, 1, 1));

            // Kitapların yazarlarını atama
            kitap1.YazarAtama(yazar1);
            kitap2.YazarAtama(yazar1);
            kitap3.YazarAtama(yazar2);

            // Yazar ve kitap bilgilerini yazdırma
            yazar1.YazarBilgileriniYazdir();
            yazar2.YazarBilgileriniYazdir();

            kitap1.KitapBilgileriniYazdir();
            kitap2.KitapBilgileriniYazdir();
            kitap3.KitapBilgileriniYazdir();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}