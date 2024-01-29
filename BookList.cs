class BookList
{
    private static List<Book> books;

    static BookList()
    {
        books = new List<Book>();
    }

    public static void AddBook(string title, string author, string isbn, int numberOfCopies)
    {
        Book newBook = new Book(title, author, isbn, numberOfCopies);
        books.Add(newBook);
    }
    public static void List()
    {
        AddBook("Zamanin Kiyisinda", "Ahmet Tanpinar", "978-1-234567-89-0", 20);
        AddBook("Kayip Sehir", "Elif Safak", "978-2-345678-90-1", 36);
        AddBook("Gokyuzune Dokulen Ask", "Canan Tan", "978-3-456789-01-2", 7);
        AddBook("Yuregimdeki Deniz", "Ayse Kulin", "978-4-567890-12-3", 6);
        AddBook("Sessizligin Ardinda", "Orhan Pamuk", "978-5-678901-23-4", 17);
        AddBook("Askin Son Yolcusu", "Yalin Alpay", "978-6-789012-34-5", 14);
        AddBook("Gizli Cemiyetin Mirasi", "Baris Mustecaplioglu", "978-7-890123-45-6", 5);
        AddBook("Beyaz Gemi", "Cengiz Aytmatov", "978-8-901234-56-7", 24);
        AddBook("Uykulu Kuytu Sozler", "Ahmet Umit", "978-9-012345-67-8", 17);
        AddBook("Kardesimin Hikayesi", "Zulfu Livaneli", "978-0-123456-78-9", 3);
        AddBook("Kadinlar Arasinda", "Fatma Aliye", "978-0-123456-78-9", 42);
        AddBook("Golgelerin Efendisi", "Ihsan Oktay Anar", "978-1-234567-89-0", 28);
        AddBook("Askin Guncesi", "Buket Uzuner", "978-2-345678-90-1", 21);
        AddBook("Incitme Beni", "Ferit Edgu", "978-3-456789-01-2", 8);
        AddBook("Ayna", "Halit Ziya Usakligil", "978-4-567890-12-3", 7);
        AddBook("Kurk Mantolu Madonna", " Sabahattin Ali", "978-5-678901-23-4", 15);
        AddBook("Bir Gun", "David Nicholls", "978-6-789012-34-5", 28);
        AddBook("Yabanci", "Albert Camus", "978-7-890123-45-6", 26);
        AddBook("Cevapsiz Cagri", "Murat Mentesh", "978-8-901234-56-7", 19);
        AddBook("Beni Asla Birakma", "Kazuo Ishiguro", "978-9-012345-67-8", 33);
    }

    public static void DisplayBookList()
    {
        Console.WriteLine("Kitap Listesi:");
        int i = 1;
        foreach (var book in books)
        {
            Console.WriteLine($"{i}.İsim: {book.Title}, Yazar: {book.Author}, ISBN: {book.Isbn}, Kopya sayısı:{book.NumberOfCopies}");
            i++;
        }
        Console.WriteLine("\n\n1.Listeyi Güncelle");
        Console.WriteLine("2.Ana Menü");
        Console.WriteLine("3.Kitap Ara");
        Console.WriteLine("4.Kitap Seç");
        Console.WriteLine("5.Kitap Ekle");
        Console.WriteLine("6.Kitap Kaldır");
        Console.WriteLine("7.Çıkış");
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
                        DisplayBookList();
                        break;
                    case 2:
                        Console.Clear();
                        MainMenu.mainMenu("HOŞGELDİNİZ");
                        break;
                    case 3:
                        BookSearch();
                        break;
                    case 4:
                        BorrowBookNumber();
                        break;
                    case 5:
                        string title, author, isbn;
                        int numberOfCopies;
                        Console.WriteLine("Kitap ismini girin");
                        title = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Yazar ismini girin");
                        author = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Isbn numarasını girin Örnek: 978-5-678901-23-7");
                        isbn = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Kopya sayısını girin");
                        numberOfCopies = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                        AddBook(title, author, isbn, numberOfCopies);
                        Console.WriteLine("Kitap eklendi");
                        break;
                    case 6:
                        RemoveBookByNumber();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Lütfen geçerli bir sayı girin");
                        break;
                }
            }
        }
    }
    public static void RemoveBookByNumber()
    {
        Console.WriteLine("Kaldırmak istediğiniz kitap numarasını girin:");

        if (int.TryParse(Console.ReadLine(), out int bookNum) && bookNum > 0 && bookNum <= GetBookCount())
        {
            RemoveBook(bookNum);
            Console.WriteLine($"Kitap {bookNum} başarıyla kaldırıldı.");
        }
        else
        {
            Console.WriteLine("Geçerli bir kitap numarası girilmedi.");
        }
    }

    public static void BookSearch()
    {
        Console.WriteLine("\nKitap Ara (isme veya yazara göre arayabilirsin.)");
        string? searchTermNullable;

        do
        {
            searchTermNullable = Console.ReadLine();

            if (searchTermNullable != null)
            {
                string searchTerm = searchTermNullable.ToLowerInvariant();

                var results = books.Where(b => b.Title.ToLowerInvariant().Contains(searchTerm) || b.Author.ToLowerInvariant().Contains(searchTerm));

                if (results.Any())
                {
                    Console.WriteLine("\nArama Sonuçları:");
                    foreach (var result in results)
                    {
                        Console.WriteLine($"{result.Title} - {result.Author}");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("\nArama Sonuçları Bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine("Geçerli bir giriş yapılmadı. Tekrar deneyin.");
            }
        } while (true);

    }
    public static void RemoveBook(int bookNum)
    {
        if (bookNum > 0 && bookNum <= books.Count)
        {
            var removedBook = books.ElementAt(bookNum - 1);
            books.Remove(removedBook);
        }
    }
    public static void BorrowBookNumber()
    {
        Console.WriteLine("Seçmek istediğiniz kitap numarasını girin:");
        if (int.TryParse(Console.ReadLine(), out int bookNum) && bookNum > 0 && bookNum <= GetBookCount())
        {
            BorrowBook(bookNum);
        }
        else
        {
            Console.WriteLine("Geçerli bir kitap numarası girilmedi.");
        }
    }
    public static void BorrowBook(int bookNum)
    {
        if (bookNum > 0 && bookNum <= books.Count)
        {
            var selectedBook = books.ElementAt(bookNum - 1);

            if (selectedBook.BorrowingDate != DateTime.MinValue)
            {
                Console.WriteLine($"Kitap zaten ödünç alındı: {selectedBook.Title}, {selectedBook.Author}");
            }
            else
            {
                Console.WriteLine("Kaç gün süreyle ödünç almak istiyorsunuz?");
                if (int.TryParse(Console.ReadLine(), out int loanperiod) && loanperiod > 0)
                {
                    selectedBook.BorrowingDate = DateTime.Now;
                    selectedBook.LoanPeriod = loanperiod;
                    selectedBook.ReturnDate = DateTime.Now.AddDays(loanperiod);

                    selectedBook.NumberOfCopies -= 1;
                    Console.WriteLine($"Kitap başarıyla ödünç alındı: {selectedBook.Title}, {selectedBook.Author}");
                    Console.WriteLine($"İade Tarihi: {selectedBook.ReturnDate.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine("Geçerli bir gün sayısı girilmedi.");
                }
            }
        }
    }
    public static void DisplayBorrowedBooks()
    {
        var borrowedBooks = books.Where(b => b.BorrowingDate != DateTime.MinValue).ToList();

        if (borrowedBooks.Any())
        {
            int i = 1;
            Console.WriteLine("Ödünç Alınan Kitaplar:");
            foreach (var book in borrowedBooks)
            {
                string returnStatus = book.ReturnDate < DateTime.Now ? "(İade Tarihi Geçmiş)" : "";
                Console.WriteLine($"{i}.{book.Title}, {book.Author} - İade Tarihi: {book.ReturnDate.ToShortDateString()} {returnStatus}");
                i++;
            }
        }
        else
        {
            Console.WriteLine("Ödünç Alınmış Kitap Bulunmamaktadır.");
        }
        int vote = 0;
        Console.WriteLine("\n\n1.İade Et:");
        Console.WriteLine("2.Kitap Listesini Görüntüle:");
        Console.WriteLine("3.Çıkış");
        while (true)
        {
            Console.WriteLine("\nLütfen bir seçenek girin:");
            if (int.TryParse(Console.ReadLine(), out vote))
            {
                switch (vote)
                {
                    case 1:
                        Console.WriteLine("İade etmek istediğiniz kitabın numarasını girin:");
                        if (int.TryParse(Console.ReadLine(), out int bookNum) && bookNum > 0 && bookNum <= borrowedBooks.Count)
                        {
                            var returnedBook = borrowedBooks.ElementAt(bookNum - 1);
                            Console.WriteLine($"Kitap iade edildi: {returnedBook.Title}, {returnedBook.Author}");
                            ReturnBook(returnedBook);
                        }
                        else
                        {
                            Console.WriteLine("Geçerli bir kitap numarası girilmedi.");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        DisplayBookList();
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
    static void ReturnBook(Book returnedBook)
    {
        returnedBook.BorrowingDate = DateTime.MinValue;
        returnedBook.LoanPeriod = 0;
        returnedBook.ReturnDate = DateTime.MinValue;
        returnedBook.NumberOfCopies += 1;
    }

    public static int GetBookCount()
    {
        return books.Count;
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int NumberOfCopies { get; set; }
        public DateTime BorrowingDate { get; set; }
        public int LoanPeriod { get; set; }
        public DateTime ReturnDate { get; set; }

        public Book(string title, string author, string isbn, int numberOfCopies)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            NumberOfCopies = numberOfCopies;
            BorrowingDate = DateTime.MinValue;
            LoanPeriod = 0;
            ReturnDate = DateTime.MinValue;
        }
    }
}
