//Спроектувати та реалізувати систему "видавець-підписник". Клас-видавець повинен
//містити подію. У класі Program (або в окремому класі-підписнику) створити метод-обробник
//та підписатися на подію. Продемонструвати, як виклик методу у видавця призводить до
//спрацювання обробника у підписника.

//FileDownloader DownloadCompleted Після імітації
//завантаження файлу
//(затримка 3 секунди).

//Виводити повідомлення: "Файл успішно завантажено!".

public delegate void Notify(string filePath);

class FileDownloaderPublisher
{
    public event Notify DownloadCompleted = filePath => 
    {   
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"File {filePath} successfully downloaded!");
        Console.ResetColor();

    };
    private void RaiseEvent(string filePath)
    {
        DownloadCompleted?.Invoke(filePath);
    }

    public void DownloadFile(string filePath)
    {
        Console.WriteLine($"Downloading {filePath}");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        for (int i = 0; i < 10; i++) {
            Console.Write("-");
            Thread.Sleep(500);
        } 
        Console.WriteLine();
        RaiseEvent(filePath);
       
    }
}


class Program
{
   static void Main(string[] args)
    {
        var fd = new FileDownloaderPublisher();
        fd.DownloadFile("test.txt");
        
    }
}