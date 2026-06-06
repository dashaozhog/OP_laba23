//Спроектувати та реалізувати систему "видавець-підписник". Клас-видавець повинен
//містити подію. У класі Program (або в окремому класі-підписнику) створити метод-обробник
//та підписатися на подію. Продемонструвати, як виклик методу у видавця призводить до
//спрацювання обробника у підписника.

//FileDownloader DownloadCompleted Після імітації
//завантаження файлу
//(затримка 3 секунди).

//Виводити повідомлення: "Файл успішно завантажено!".


// оголошуємо делегат для події
public delegate void Notify(string filePath);

// клас-видавець
class FileDownloaderPublisher
{
    //створюємо подію
    public event Notify DownloadCompleted;

    //метод видавця для завантаження файлу
    public void DownloadFile(string filePath)
    {
        Console.WriteLine($"Downloading {filePath}");
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        //строка завантаження
        for (int i = 0; i < 6; i++) {
            Console.Write("-");
            Thread.Sleep(500);
        } 
        Console.WriteLine();
        //виклик події через protected метод
        OnDownloadCompleted(filePath);
  
    }
    protected virtual void OnDownloadCompleted(string filePath)
    {
        //перевірка чи не null подія, яку збираємось викликати
        DownloadCompleted?.Invoke(filePath);
    }
}

// клас-підписник
class Program
{
   static void Main(string[] args)
    {
        var fd = new FileDownloaderPublisher();
        // до івенту за принципом мультикаст делегатів додається метод
        fd.DownloadCompleted += OnFileDownloaded;
        fd.DownloadFile("test.txt");
        
    }

    static void OnFileDownloaded(string filePath)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"File {filePath} successfully downloaded!");
        Console.ResetColor();
    }
}