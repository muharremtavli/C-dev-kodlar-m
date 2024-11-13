using System;

class TicTacToe
{
    static char[] oyunTahtasi = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // Oyun tahtası
    static int mevcutOyuncu = 1; // 1 => Oyuncu 1 (X), 2 => Oyuncu 2 (O)
    static int secenek; // Kullanıcının seçtiği hücre
    static int sonuc = 0; // Durum flag'ı: 0 -> Oyun devam ediyor, 1 -> Bir oyuncu kazandı, -1 -> Beraberlik

    static void Main(string[] args)
    {
        Console.WriteLine("Tik Tak Toe Oyununa Hoşgeldiniz!");

        while (sonuc != 1 && sonuc != -1)
        {
            Console.Clear();
            PrintBoard();
            Console.WriteLine("Oyuncu {0} için bir seçim yapın (1-9): ", mevcutOyuncu);
            secenek = int.Parse(Console.ReadLine());

            // Eğer seçilen hücre boşsa, o hücreye X veya O koyulur
            if (oyunTahtasi[secenek] != 'X' && oyunTahtasi[secenek] != 'O')
            {
                if (mevcutOyuncu == 1)
                {
                    oyunTahtasi[secenek] = 'X'; // Oyuncu 1 X koyuyor
                    mevcutOyuncu = 2;   // Oyuncu 2'ye geçiliyor
                }
                else
                {
                    oyunTahtasi[secenek] = 'O'; // Oyuncu 2 O koyuyor
                    mevcutOyuncu = 1;   // Oyuncu 1'e geçiliyor
                }
            }
            else
            {
                Console.WriteLine("Hücre zaten dolu. Lütfen başka bir hücre seçin.");
                Console.ReadLine();
            }

            sonuc = CheckWin(); // Kazanan var mı kontrol edilir
        }

        Console.Clear();
        PrintBoard();

        // Duruma göre kazananı ya da beraberliği bildiren mesaj
        if (sonuc == 1)
        {
            Console.WriteLine("Tebrikler! Oyuncu {0} kazandı!", mevcutOyuncu == 1 ? 2 : 1);
        }
        else
        {
            Console.WriteLine("Beraberlik! Hiçbir oyuncu kazanamadı.");
        }

        Console.WriteLine("Oyun bitti. Devam etmek için bir tuşa basın.");
        Console.ReadLine();
    }

    // Tahtayı ekrana yazdıran fonksiyon
    static void PrintBoard()
    {
        Console.WriteLine("-----");
        Console.WriteLine("| {0} | {1} | {2} |", oyunTahtasi[1], oyunTahtasi[2], oyunTahtasi[3]);
        Console.WriteLine("-----");
        Console.WriteLine("| {0} | {1} | {2} |", oyunTahtasi[4], oyunTahtasi[5], oyunTahtasi[6]);
        Console.WriteLine("-----");
        Console.WriteLine("| {0} | {1} | {2} |", oyunTahtasi[7], oyunTahtasi[8], oyunTahtasi[9]);
        Console.WriteLine("-----");
    }

    // Kazananı kontrol eden fonksiyon
    static int CheckWin()
    {
        // Yatay kontrol
        if (oyunTahtasi[1] == oyunTahtasi[2] && oyunTahtasi[2] == oyunTahtasi[3] ||
            oyunTahtasi[4] == oyunTahtasi[5] && oyunTahtasi[5] == oyunTahtasi[6] ||
            oyunTahtasi[7] == oyunTahtasi[8] && oyunTahtasi[8] == oyunTahtasi[9])
            return 1;

        // Dikey kontrol
        if (oyunTahtasi[1] == oyunTahtasi[4] && oyunTahtasi[4] == oyunTahtasi[7] ||
            oyunTahtasi[2] == oyunTahtasi[5] && oyunTahtasi[5] == oyunTahtasi[8] ||
            oyunTahtasi[3] == oyunTahtasi[6] && oyunTahtasi[6] == oyunTahtasi[9])
            return 1;

        // Çapraz kontrol
        if (oyunTahtasi[1] == oyunTahtasi[5] && oyunTahtasi[5] == oyunTahtasi[9] ||
            oyunTahtasi[3] == oyunTahtasi[5] && oyunTahtasi[5] == oyunTahtasi[7])
            return 1;

        // Beraberlik durumu (tahta tamamen dolmuşsa)
        bool draw = true;
        for (int i = 1; i <= 9; i++)
        {
            if (oyunTahtasi[i] != 'X' && oyunTahtasi[i] != 'O')
            {
                draw = false;
                break;
            }
        }
        if (draw) return -1;

        // Oyun devam ediyor
        return 0;
    }
}
