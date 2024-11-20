using System;
using System.Collections.Generic;

class Kitap
{
    public string Baslik { get; set; }
    public string Yazar { get; set; }

    public Kitap(string baslik, string yazar)
    {
        Baslik = baslik;
        Yazar = yazar;
    }

    public void KitapBilgileriniYazdir()
    {
        Console.WriteLine($"Kitap Başlığı: {Baslik}, Yazar: {Yazar}");
    }
}

class Kutuphane
{
    public string Ad { get; set; }
    public List<Kitap> Kitaplar { get; set; }

    public Kutuphane(string ad)
    {
        Ad = ad;
        Kitaplar = new List<Kitap>();
    }

    public void KitapEkle(Kitap kitap)
    {
        Kitaplar.Add(kitap);
    }

    public void KutuphaneBilgileriniYazdir()
    {
        Console.WriteLine($"Kütüphane Adı: {Ad}");
        Console.WriteLine("Kitaplar:");
        foreach (var kitap in Kitaplar)
        {
            kitap.KitapBilgileriniYazdir();
        }
    }
}

namespace kutuphaneKitapUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kütüphane oluşturma
            Kutuphane kutuphane = new Kutuphane("Şehir Kütüphanesi");

            // Kitaplar oluşturma
            Kitap kitap1 = new Kitap("Benim Adım Kırmızı", "Orhan Pamuk");
            Kitap kitap2 = new Kitap("Yüzyıllık Yalnızlık", "Gabriel García Márquez");
            Kitap kitap3 = new Kitap("1984", "George Orwell");

            // Kitapları kütüphaneye ekleme
            kutuphane.KitapEkle(kitap1);
            kutuphane.KitapEkle(kitap2);
            kutuphane.KitapEkle(kitap3);

            // Kütüphane bilgilerini yazdırma
            kutuphane.KutuphaneBilgileriniYazdir();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}