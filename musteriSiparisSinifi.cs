using System;
using System.Collections.Generic;

class Siparis
{
    public DateTime Tarih { get; set; }
    public string Durum { get; set; }

    public Siparis()
    {
        Tarih = DateTime.Now;
        Durum = "Yeni";
    }
}

class Musteri
{
    public string Ad { get; set; }
    public string Telefon { get; set; }
    public List<Siparis> Siparisler { get; set; }

    public Musteri(string ad, string telefon)
    {
        Ad = ad;
        Telefon = telefon;
        Siparisler = new List<Siparis>();
    }

    public void SiparisVer()
    {
        Siparis yeniSiparis = new Siparis();
        Siparisler.Add(yeniSiparis);
        Console.WriteLine($"{Ad} adlı müşteri için yeni sipariş oluşturuldu. Tarih: {yeniSiparis.Tarih}, Durum: {yeniSiparis.Durum}");
    }

    public void MusteriBilgileriniYazdir()
    {
        Console.WriteLine($"Müşteri Adı: {Ad}, Telefon: {Telefon}");
        Console.WriteLine("Müşterinin Siparişleri:");
        foreach (var siparis in Siparisler)
        {
            Console.WriteLine($"  Sipariş Tarihi: {siparis.Tarih}, Durum: {siparis.Durum}");
        }
    }
}

namespace musteriSiparisUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Müşteri oluşturma
            Musteri musteri1 = new Musteri("Muharrem Tavlı", "0507-701-8658");
            Musteri musteri2 = new Musteri("Abdulvahap Tavlı", "0543-749-6058");

            // Müşterilere sipariş verme
            musteri1.SiparisVer();
            musteri1.SiparisVer();
            musteri2.SiparisVer();

            // Müşteri bilgilerini yazdırma
            musteri1.MusteriBilgileriniYazdir();
            musteri2.MusteriBilgileriniYazdir();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}