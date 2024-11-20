using System;
using System.Collections.Generic;

class Kitap
{
    public string Baslik { get; set; }
    public string ISBN { get; set; }

    public Kitap(string baslik, string isbn)
    {
        Baslik = baslik;
        ISBN = isbn;
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
}

namespace kitapYazmaUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Yazar oluşturma
            Yazar yazar1 = new Yazar("Orhan Pamuk", "Türkiye");
            Yazar yazar2 = new Yazar("Gabriel García Márquez", "Kolombiya");

            // Kitaplar oluşturma
            Kitap kitap1 = new Kitap("Benim Adım Kırmızı", "9789750780598");
            Kitap kitap2 = new Kitap("Sessiz Ev", "9786050629462");
            Kitap kitap3 = new Kitap("Yüzyıllık Yalnızlık", "9789750712230");

            // Kitapları yazarlara ekleme
            yazar1.KitapEkle(kitap1);
            yazar1.KitapEkle(kitap2);
            yazar2.KitapEkle(kitap3);

            // Yazar ve kitap bilgilerini yazdırma
            List<Yazar> yazarlar = new List<Yazar> { yazar1, yazar2 };

            foreach (var yazar in yazarlar)
            {
                Console.WriteLine($"Yazar: {yazar.Ad}, Ülke: {yazar.Ulke}");
                foreach (var kitap in yazar.Kitaplar)
                {
                    Console.WriteLine($"  Kitap Başlığı: {kitap.Baslik}, ISBN: {kitap.ISBN}");
                }
            }

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}