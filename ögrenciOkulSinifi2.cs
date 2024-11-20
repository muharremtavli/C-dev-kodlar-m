using System;
using System.Collections.Generic;
class Ogrenci
{
    public string Ad { get; set; }
    public int Yas { get; set; }

    public Ogrenci(string ad, int yas)
    {
        Ad = ad;
        Yas = yas;
    }

    public void OgrenciBilgisi()
    {
        Console.WriteLine($"Öğrenci Adı: {Ad}, Yaşı: {Yas}");
    }
}

class Okul
{
    public string Ad { get; set; }
    public List<Ogrenci> Ogrenciler { get; set; }

    public Okul(string ad)
    {
        Ad = ad;
        Ogrenciler = new List<Ogrenci>();
    }

    public void OgrenciOlustur(string ad, int yas)
    {
        Ogrenci ogrenci = new Ogrenci(ad, yas);
        Ogrenciler.Add(ogrenci);
    }

    public void OkulBilgileriniYazdir()
    {
        Console.WriteLine($"Okul Adı: {Ad}");
        Console.WriteLine("Öğrenciler:");
        foreach (var ogrenci in Ogrenciler)
        {
            ogrenci.OgrenciBilgisi();
        }
    }
}

namespace okulOgrenciUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Okul oluşturma
            Okul okul = new Okul("Şehir Lisesi");

            // Öğrenciler oluşturma
            okul.OgrenciOlustur("Ali Veli", 16);
            okul.OgrenciOlustur("Ayşe Yılmaz", 15);
            okul.OgrenciOlustur("Mehmet Can", 17);

            // Okul bilgilerini yazdırma
            okul.OkulBilgileriniYazdir();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}