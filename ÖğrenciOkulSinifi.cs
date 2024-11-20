using System;
using System.Collections.Generic;

class Okul
{
    public string Ad { get; set; }
    public string Adres { get; set; }

    public Okul(string ad, string adres)
    {
        Ad = ad;
        Adres = adres;
    }
}

class Ogrenci
{
    public string Ad { get; set; }
    public int Yas { get; set; }
    public Okul Okul { get; set; }

    public Ogrenci(string ad, int yas)
    {
        Ad = ad;
        Yas = yas;
    }

    public void OkulEkle(Okul okul)
    {
        Okul = okul;
    }
}

namespace besinciHaftaUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Okul oluşturma
            Okul okul = new Okul("Fırat Üniversitesi", "Elazığ, Türkiye");

            // Öğrenciler oluşturma
            Ogrenci ogrenci1 = new Ogrenci("Mharrem", 19);
            Ogrenci ogrenci2 = new Ogrenci("Büşra", 19);
            Ogrenci ogrenci3 = new Ogrenci("Medine", 19);

            // Öğrencilere okulu ekleme
            ogrenci1.OkulEkle(okul);
            ogrenci2.OkulEkle(okul);
            ogrenci3.OkulEkle(okul);

            // Öğrenci bilgilerini yazdırma
            List<Ogrenci> ogrenciler = new List<Ogrenci> { ogrenci1, ogrenci2, ogrenci3 };

            foreach (var ogrenci in ogrenciler)
            {
                Console.WriteLine($"Öğrenci Adı: {ogrenci.Ad}, Yaşı: {ogrenci.Yas}, Okulu: {ogrenci.Okul.Ad}, Adresi: {ogrenci.Okul.Adres}");
            }

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
