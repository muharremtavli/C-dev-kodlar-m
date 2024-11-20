using System;
using System.Collections.Generic;

class Urun
{
    public string Ad { get; set; }
    public int Fiyat { get; set; }

    public Urun(string ad, int fiyat)
    {
        Ad = ad;
        Fiyat = fiyat;
    }

    public void UrunBilgileriniYazdir()
    {
        Console.WriteLine($"  Ürün Adı: {Ad}, Fiyat: {Fiyat} TL");
    }
}

class Siparis
{
    public DateTime Tarih { get; set; }
    public string Durum { get; set; }
    public List<Urun> Urunler { get; set; }

    public Siparis()
    {
        Tarih = DateTime.Now;
        Durum = "Yeni";
        Urunler = new List<Urun>();
    }

    public void UrunBilgisi(Urun urun)
    {
        Urunler.Add(urun);
    }

    public void SiparisBilgileriniYazdir()
    {
        Console.WriteLine($"Sipariş Tarihi: {Tarih}, Durum: {Durum}");
        Console.WriteLine("Ürünler:");
        foreach (var urun in Urunler)
        {
            urun.UrunBilgileriniYazdir();
        }
    }
}

namespace urunSiparisUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ürünler oluşturma
            Urun urun1 = new Urun("Laptop", 15000);
            Urun urun2 = new Urun("Akıllı Telefon", 5000);
            Urun urun3 = new Urun("Kulaklık", 300);

            // Sipariş oluşturma
            Siparis siparis = new Siparis();
            siparis.UrunBilgisi(urun1);
            siparis.UrunBilgisi(urun2);
            siparis.UrunBilgisi(urun3);

            // Sipariş bilgilerini yazdırma
            siparis.SiparisBilgileriniYazdir();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
}