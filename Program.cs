using System; // Sistem kütüphanesini ekle

class Program // Program sınıfını tanımla
{
    static char[,] board = new char[20, 20]; // 20x20 boyutunda oyun alanı
    static bool[,] revealed = new bool[20, 20]; // Hangi hücrelerin açıldığını takip et
    static int mineCount = 40; // Mayın sayısını tanımla

    static void Main(string[] args) // Ana metod
    {
        InitializeBoard(); // Oyun alanını başlat
        PlaceMines(mineCount); // Mayınları yerleştir
        PlayGame(); // Oyunu başlat
    }

    static void InitializeBoard() // Oyun alanını başlatma metodu
    {
        for (int i = 0; i < 20; i++) // Satırları döngüye al
        {
            for (int j = 0; j < 20; j++) // Sütunları döngüye al
            {
                board[i, j] = '.'; // Her hücreyi başlangıçta '.' ile işaretle
            }
        }
    }

    static void PlaceMines(int count) // Mayın yerleştirme metodu
    {
        Random rand = new Random(); // Rastgele sayı üreteci oluştur
        int placedMines = 0; // Yerleştirilen mayın sayısını sıfırla

        while (placedMines < count) // Belirtilen sayıda mayın yerleştirmek için döngü
        {
            int x = rand.Next(20); // 0-19 arasında rastgele bir satır seç
            int y = rand.Next(20); // 0-19 arasında rastgele bir sütun seç

            if (board[x, y] != '*') // Eğer seçilen hücrede mayın yoksa
            {
                board[x, y] = '*'; // Mayın yerleştir
                placedMines++; // Yerleştirilen mayın sayısını artır
            }
        }

        // Mayınların etrafındaki sayıları güncelle
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (board[i, j] == '*') // Eğer hücrede mayın varsa
                {
                    UpdateSurroundingCells(i, j); // Çevresindeki hücreleri güncelle
                }
            }
        }
    }

    static void UpdateSurroundingCells(int x, int y) // Çevresindeki hücreleri güncelleme metodu
    {
        for (int i = -1; i <= 1; i++) // -1, 0, 1 döngüsünü kullan
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue; // Kendisine bakma

                int newX = x + i; // Yeni satır
                int newY = y + j; // Yeni sütun

                // Eğer yeni hücre geçerliyse
                if (IsValidCell(newX, newY) && board[newX, newY] != '*')
                {
                    if (board[newX, newY] == '.') // Eğer hücre açılmamışsa
                    {
                        board[newX, newY] = '1'; // Başlangıçta '1' ile işaretle
                    }
                    else // Eğer hücre açıksa
                    {
                        // Var olan sayıyı artır
                        board[newX, newY] = (char)(board[newX, newY] + 1);
                    }
                }
            }
        }
    }

    static bool IsValidCell(int x, int y) // Geçerli hücre kontrolü
    {
        return x >= 0 && x < 20 && y >= 0 && y < 20; // Sınırlar içinde mi?
    }

    static void PlayGame() // Oyunu oynama metodu
    {
        while (true) // Sürekli döngü
        {
            PrintBoard(); // Oyun alanını yazdır
            Console.Write("Satır (0-19) girin: "); // Kullanıcıdan satır girmesini iste
            int row = int.Parse(Console.ReadLine()); // Satır değerini al
            Console.Write("Sütun (0-19) girin: "); // Kullanıcıdan sütun girmesini iste
            int col = int.Parse(Console.ReadLine()); // Sütun değerini al

            if (row < 0 || row >= 20 || col < 0 || col >= 20) // Geçersiz hücre kontrolü
            {
                Console.WriteLine("Geçersiz hücre! Lütfen tekrar deneyin."); // Uyarı mesajı
                continue; // Döngüyü başa al
            }

            if (board[row, col] == '*') // Eğer mayına basıldıysa
            {
                Console.WriteLine("Mayına bastınız! Oyun bitti."); // Oyun bitti mesajı
                break; // Döngüden çık
            }
            else
            {
                revealed[row, col] = true; // Hücreyi aç
                RevealSurroundingCells(row, col); // Çevredeki hücreleri aç
            }
        }
    }

    static void RevealSurroundingCells(int x, int y) // Açılmamış hücreleri açma metodu
    {
        if (!IsValidCell(x, y) || revealed[x, y]) // Geçerlilik kontrolü
            return; // Eğer geçerli değilse veya zaten açılmışsa çık

        revealed[x, y] = true; // Hücreyi aç

        if (board[x, y] == '.') // Eğer hücre boşsa
        {
            for (int i = -1; i <= 1; i++) // Çevresindeki hücreleri kontrol et
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue; // Kendisine bakma
                    RevealSurroundingCells(x + i, y + j); // Çevresindeki hücreleri aç
                }
            }
        }
    }

    static void PrintBoard() // Oyun alanını yazdırma metodu
    {
        Console.Clear(); // Konsolu temizle
        for (int i = 0; i < 20; i++) // Satırları döngüye al
        {
            for (int j = 0; j < 20; j++) // Sütunları döngüye al
            {
                if (revealed[i, j]) // Eğer hücre açılmışsa
                    Console.Write(board[i, j] + " "); // Hücreyi yazdır
                else
                    Console.Write(". "); // Açılmamış hücre için '.' yazdır
            }
            Console.WriteLine(); // Satır sonu
        }
    }
}