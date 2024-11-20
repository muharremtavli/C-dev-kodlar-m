using System;
using System.Collections.Generic;

class Oda
{
    public string Boyut { get; set; }
    public string Tip { get; set; }

    public Oda(string boyut, string tip)
    {
        Boyut = boyut;
        Tip = tip;
    }

    public void OdaBilgileriniYazdir()
    {
        Console.WriteLine($"Oda Boyutu: {Boyut}, Oda Tipi: {Tip}");
    }
}

class Ev
{
    public string Ad { get; set; }
    public List<Oda> Odalar { get; set; }

    public Ev(string ad)
    {
        Ad = ad;
        Odalar = new List<Oda>();
    }

    public void OdaEkle(Oda oda)
    {
        Odalar.Add(oda);
    }

    public void EvBilgileriniYazdir()
    {
        Console.WriteLine($"Ev Adı: {Ad}");
        Console.WriteLine("Oda Bilgileri:");
        foreach (var oda in Odalar)
        {
            oda.OdaBilgileriniYazdir();
        }
    }
}

namespace evOdaUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ev oluşturma
            Ev ev1 = new Ev("Bahçe Evim");

            // Oda oluşturma
            Oda oda1 = new Oda("20 m²", "Yatak Odası");
            Oda oda2 = new Oda("15 m²", "Oturma Odası");
            Oda oda3 = new Oda("10 m²", "Mutfak");

            // Odaları eve ekleme
            ev1.OdaEkle(oda1);
            ev1.OdaEkle(oda2);
            ev1.OdaEkle(oda3);

            // Ev bilgilerini yazdırma
            ev1.EvBilgileriniYazdir();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}