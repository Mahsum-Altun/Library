class MainMenu
{
    public static void mainMenu(string message)
    {
        Console.WriteLine("************************************************************************************");
        Console.WriteLine($"*                                    {message}                                   *");
        Console.WriteLine("************************************************************************************");
        Console.WriteLine("1.Kitap Listesini Görüntüle:");
        Console.WriteLine("2.Ödünç alınan kitapları göster:");
        Console.WriteLine("3.Çıkış");
        int vote = 0;
        while (true)
        {
            Console.WriteLine("\nLütfen bir seçenek girin:");
            if (int.TryParse(Console.ReadLine(), out vote))
            {
                switch (vote)
                {
                    case 1:
                        Console.Clear();
                        BookList.DisplayBookList();
                        break;
                    case 2:
                        Console.Clear();
                        BookList.DisplayBorrowedBooks();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Lütfen geçerli bir sayı girin");
                        break;
                }
            }
        }
    }
}