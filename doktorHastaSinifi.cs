using System;
using System.Collections.Generic;

class Hasta
{
    public string Ad { get; set; }
    public string TCno { get; set; }
    public Doktor Doktor { get; set; }

    public Hasta(string ad, string tcno)
    {
        Ad = ad;
        TCno = tcno;
    }

    public void DoktorAtama(Doktor doktor)
    {
        Doktor = doktor;
        doktor.HastaEkle(this); // Hastayı doktora ekliyoruz
    }

    public void HastaBilgileriniYazdir()
    {
        Console.WriteLine($"Hasta Adı: {Ad}, TC No: {TCno}, Doktor: {(Doktor != null ? Doktor.Ad : "Atanmadı")}");
    }
}

class Doktor
{
    public string Ad { get; set; }
    public string Brans { get; set; }
    public List<Hasta> Hastalar { get; set; }

    public Doktor(string ad, string brans)
    {
        Ad = ad;
        Brans = brans;
        Hastalar = new List<Hasta>();
    }

    public void HastaEkle(Hasta hasta)
    {
        Hastalar.Add(hasta);
    }

    public void DoktorBilgileriniYazdir()
    {
        Console.WriteLine($"Doktor Adı: {Ad}, Branş: {Brans}");
        Console.WriteLine("Responsibility: Hastalar:");
        foreach (var hasta in Hastalar)
        {
            Console.WriteLine($"  Hasta Adı: {hasta.Ad}, TC No: {hasta.TCno}");
        }
    }
}

namespace doktorHastaUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Doktorlar oluşturma
            Doktor doktor1 = new Doktor("Dr. Muharrem Tavlı", "Cerrah");
            Doktor doktor2 = new Doktor("Dr. Abdulvahap Tavlı", "Nörolog");

            // Hastalar oluşturma
            Hasta hasta1 = new Hasta("Medine Çığır", "11111111111");
            Hasta hasta2 = new Hasta("Hevi Yurtsever", "22222222222");
            Hasta hasta3 = new Hasta("Şura Aydın", "33333333333");

            // Hastaları doktora atama
            hasta1.DoktorAtama(doktor1);
            hasta2.DoktorAtama(doktor1);
            hasta3.DoktorAtama(doktor2);

            // Doktor ve hasta bilgilerini yazdırma
            doktor1.DoktorBilgileriniYazdir();
            doktor2.DoktorBilgileriniYazdir();

            hasta1.HastaBilgileriniYazdir();
            hasta2.HastaBilgileriniYazdir();
            hasta3.HastaBilgileriniYazdir();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}