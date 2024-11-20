using System;

class Islemci
{
    public int Cekirdekler { get; set; }
    public int Frekans { get; set; } // Frekans MHz cinsinden

    public Islemci(int cekirdekler, int frekans)
    {
        Cekirdekler = cekirdekler;
        Frekans = frekans;
    }

    public void IslemciBilgisi()
    {
        Console.WriteLine($"İşlemci Çekirdekleri: {Cekirdekler}, Frekans: {Frekans} MHz");
    }
}

class Bilgisayar
{
    public string Model { get; set; }
    public Islemci Islemci { get; set; }

    public Bilgisayar(string model)
    {
        Model = model;
    }

    public void IslemciOlustur(int cekirdekler, int frekans)
    {
        Islemci = new Islemci(cekirdekler, frekans);
    }

    public void BilgisayarBilgisi()
    {
        Console.WriteLine($"Bilgisayar Modeli: {Model}");
        if (Islemci != null)
        {
            Islemci.IslemciBilgisi();
        }
        else
        {
            Console.WriteLine("Bu bilgisayarın bir işlemcisi yok.");
        }
    }
}

namespace bilgisayarIslemciUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bilgisayar oluşturma
            Bilgisayar bilgisayar = new Bilgisayar("Dell XPS 15");

            // İşlemci oluşturma
            bilgisayar.IslemciOlustur(8, 2800); // 8 çekirdekli ve 2800 MHz frekanslı işlemci

            // Bilgisayar bilgilerini yazdırma
            bilgisayar.BilgisayarBilgisi();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}