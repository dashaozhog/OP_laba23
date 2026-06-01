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
    public event Notify DownloadCompleted = filePath => Console.WriteLine($"File {filePath} successfully downloaded!");
    public void RaiseEvent(string filePath)
    {
        DownloadCompleted?.Invoke(filePath);
    }
}


class Program
{
   delegate List<string> DoubleDel(int count, string elem);

    static List<string> GenList(int count, string elem)
    {
        var list = new List<string>();
        for(int i = 0; i< count; i++)
        {
            list.Add(elem);
        }
        return list;
    }
   static void Main(string[] args)
    {
        DoubleDel method = GenList;
        foreach(string n in method(10, "TEST")) {
            Console.Write(n);
        }
        
    }
}