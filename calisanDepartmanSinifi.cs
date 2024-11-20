using System;
using System.Collections.Generic;

class Departman
{
    public string Ad { get; set; }
    public string Lokasyon { get; set; }

    public Departman(string ad, string lokasyon)
    {
        Ad = ad;
        Lokasyon = lokasyon;
    }
}

class Calisan
{
    public string Ad { get; set; }
    public string Pozisyon { get; set; }
    public Departman Departman { get; set; }

    public Calisan(string ad, string pozisyon)
    {
        Ad = ad;
        Pozisyon = pozisyon;
    }

    public void DepartmanAtama(Departman departman)
    {
        Departman = departman;
    }
}

namespace calisanDepartmanUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Departman oluşturma
            Departman departman1 = new Departman("Program Geliştirme", "Bingöl");
            Departman departman2 = new Departman("Finans", "Bİngöl");

            // Çalışanlar oluşturma
            Calisan calisan1 = new Calisan("Muharrem Tavlı", "Developer");
            Calisan calisan2 = new Calisan("Abdulvahap Tavlı", "Finans Analisti");

            // Çalışanlara departman atama
            calisan1.DepartmanAtama(departman1);
            calisan2.DepartmanAtama(departman2);

            // Çalışan ve departman bilgilerini yazdırma
            List<Calisan> calisanlar = new List<Calisan> { calisan1, calisan2 };

            foreach (var calisan in calisanlar)
            {
                Console.WriteLine($"Çalışan: {calisan.Ad}, Pozisyon: {calisan.Pozisyon}, Departman: {calisan.Departman.Ad}, Lokasyon: {calisan.Departman.Lokasyon}");
            }

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}