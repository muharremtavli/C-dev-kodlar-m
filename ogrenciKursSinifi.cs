using System;
using System.Collections.Generic;

class Kurs
{
    public string Ad { get; set; }
    public string Kod { get; set; }
    public List<Ogrenci> Ogrenciler { get; set; }

    public Kurs(string ad, string kod)
    {
        Ad = ad;
        Kod = kod;
        Ogrenciler = new List<Ogrenci>();
    }

    public void OgrenciEkle(Ogrenci ogrenci)
    {
        Ogrenciler.Add(ogrenci);
        ogrenci.KursEkle(this); // Öğrenciye kursu ekliyoruz
    }

    public void KursBilgileriniYazdir()
    {
        Console.WriteLine($"Kurs Adı: {Ad}, Kod: {Kod}");
        Console.WriteLine("Kursa Kayıtlı Öğrenciler:");
        foreach (var ogrenci in Ogrenciler)
        {
            Console.WriteLine($"  Öğrenci Adı: {ogrenci.Ad}, Yaşı: {ogrenci.Yas}");
        }
    }
}

class Ogrenci
{
    public string Ad { get; set; }
    public int Yas { get; set; }
    public List<Kurs> Kurslar { get; set; }

    public Ogrenci(string ad, int yas)
    {
        Ad = ad;
        Yas = yas;
        Kurslar = new List<Kurs>();
    }

    public void KursEkle(Kurs kurs)
    {
        Kurslar.Add(kurs);
    }

    public void OgrenciBilgileriniYazdir()
    {
        Console.WriteLine($"Öğrenci Adı: {Ad}, Yaşı: {Yas}");
        Console.WriteLine("Kayıtlı Kurslar:");
        foreach (var kurs in Kurslar)
        {
            Console.WriteLine($"  Kurs Adı: {kurs.Ad}, Kod: {kurs.Kod}");
        }
    }
}

namespace ogrenciKursUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kurslar oluşturma
            Kurs kurs1 = new Kurs("Matematik", "MATH101");
            Kurs kurs2 = new Kurs("Fizik", "PHYS101");
            Kurs kurs3 = new Kurs("Kimya", "CHEM101");

            // Öğrenciler oluşturma
            Ogrenci ogrenci1 = new Ogrenci("Muharrem ", 19);
            Ogrenci ogrenci2 = new Ogrenci("Abdulvahap", 22);

            // Öğrencileri kurslara ekleme
            kurs1.OgrenciEkle(ogrenci1);
            kurs2.OgrenciEkle(ogrenci1);
            kurs2.OgrenciEkle(ogrenci2);
            kurs3.OgrenciEkle(ogrenci2);

            // Kurs ve öğrenci bilgilerini yazdırma
            kurs1.KursBilgileriniYazdir();
            kurs2.KursBilgileriniYazdir();
            kurs3.KursBilgileriniYazdir();

            ogrenci1.OgrenciBilgileriniYazdir();
            ogrenci2.OgrenciBilgileriniYazdir();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}