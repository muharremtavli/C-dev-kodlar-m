using System;

class Motor
{
    public int Guç { get; set; }
    public string Tip { get; set; }

    public Motor(int güç, string tip)
    {
        Guç = güç;
        Tip = tip;
    }

    public void MotorBilgisi()
    {
        Console.WriteLine($"Motor Gücü: {Guç} HP, Motor Tipi: {Tip}");
    }
}

class Otomobil
{
    public string Marka { get; set; }
    public Motor Motor { get; set; }

    public Otomobil(string marka)
    {
        Marka = marka;
    }

    public void MotorOlustur(int güç, string tip)
    {
        Motor = new Motor(güç, tip);
    }

    public void OtomobilBilgisi()
    {
        Console.WriteLine($"Otomobil Markası: {Marka}");
        if (Motor != null)
        {
            Motor.MotorBilgisi();
        }
        else
        {
            Console.WriteLine("Bu otomobilin bir motoru yok.");
        }
    }
}

namespace otomobilMotorUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Otomobil oluşturma
            Otomobil otomobil = new Otomobil("Ford Mustang");

            // Motor oluşturma
            otomobil.MotorOlustur(450, "Benzin"); // 450 HP gücünde ve benzinli motor

            // Otomobil bilgilerini yazdırma
            otomobil.OtomobilBilgisi();

            // Programın sonlanmaması için bir tuşa basmayı bekle
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}