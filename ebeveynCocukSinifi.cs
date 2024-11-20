using System;
using System.Collections.Generic;

class Cocuk
{
    public string Ad { get; set; }
    public int Yas { get; set; }
    public Ebeveyn Ebeveyn { get; set; }

    public Cocuk(string ad, int yas)
    {
        Ad = ad;
        Yas = yas;
    }

    public void EbeveynAtama(Ebeveyn ebeveyn)
    {
        Ebeveyn = ebeveyn;
        ebeveyn.CocukEkle(this); // Çocuğu ebeveyne ekliyoruz
    }

    public void CocukBilgileriniYazdir()
    {
        Console.WriteLine($"Çocuk Adı: {Ad}, Yaşı: {Yas}, Ebeveyn: {(Ebeveyn != null ? Ebeveyn.Ad : "Atanmadı")}");
    }
}

class Ebeveyn
{
    public string Ad { get; set; }
    public int Yas { get; set; }
    public List<Cocuk> Cocuklar { get; set; }

    public Ebeveyn(string ad, int yas)
    {
        Ad = ad;
        Yas = yas;
        Cocuklar = new List<Cocuk>();
    }

    public void CocukEkle(Cocuk cocuk)
    {
        Cocuklar.Add(cocuk);
    }

    public void EbeveynBilgileriniYazdir()
    {
        Console.WriteLine($"Ebeveyn Adı: {Ad}, Yaşı: {Yas}");
        Console.WriteLine("Çocuklar:");
        foreach (var cocuk in Cocuklar)
        {
            Console.WriteLine($"  Çocuk Adı: {cocuk.Ad}, Yaşı: {cocuk.Yas}");
        }
    }
}

namespace ebeveynCocukUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ebeveynler oluşturma
            Ebeveyn ebeveyn1 = new Ebeveyn("Muharrem Tavlı", 19);
            Ebeveyn ebeveyn2 = new Ebeveyn("Şura Aydın", 19);

            // Çocuklar oluşturma
            Cocuk cocuk1 = new Cocuk("Alparslan", 1);
            Cocuk cocuk2 = new Cocuk("Umay", 1);
            Cocuk cocuk3 = new Cocuk("Göktuğ", 1);

            // Çocukları ebeveynlere atama
            cocuk1.EbeveynAtama(ebeveyn1);
            cocuk2.EbeveynAtama(ebeveyn1);
            cocuk3.EbeveynAtama(ebeveyn2);

            // Ebeveyn ve çocuk bilgilerini yazdırma
            ebeveyn1.EbeveynBilgileriniYazdir();
            ebeveyn2.EbeveynBilgileriniYazdir();

            cocuk1.CocukBilgileriniYazdir();
            cocuk2.CocukBilgileriniYazdir();
            cocuk3.CocukBilgileriniYazdir();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}