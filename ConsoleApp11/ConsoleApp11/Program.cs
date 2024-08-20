using System.Runtime.CompilerServices;

public class Film // Film sınıfı
{
    //Kapsülleme
    public string Name { get; set; }
    public double ImdbPoint { get; set; }

    public Film(string name, double imdbPoint) //Film nesnesi oluşturmak için constructor yapısı
    {
        Name = name;
        ImdbPoint = imdbPoint;
    }

    public override string ToString() 
    {
        return $"{Name} - IMDb Puanı: {ImdbPoint}";
    }

}

public class Program
{
    public static void Main()
    {
        List<Film> filmList = new List<Film>(); // Film nesnelerinden oluşan liste oluşturma

        while (true)
        {
       Ask: Console.Write("Lütfen film adı giriniz: ");
            string name= Console.ReadLine();

            Console.Write("Lütfen film puanını giriniz: ");
            double imdbPoint;

            if(!double.TryParse(Console.ReadLine(), out imdbPoint))
            {
                Console.WriteLine("Lütfen geçerli bir puan giriniz.");
                continue; // Kullanıcı yanlış bir değer girerse döngü içinde en başa gönderecek
            }

            filmList.Add(new Film(name, imdbPoint));

            Console.WriteLine("Başka bir film eklemek ister misiniz?");
            string userResponse = Console.ReadLine().ToLower().Trim();

            if(userResponse == "e")
            {
                goto Ask;
            }
           
            Console.WriteLine("\nGirmiş olduğunuz tüm filmlerin listesi:\n");

            foreach(var film in filmList) // Tüm listeyi ekrana yazdırma
            {
                Console.WriteLine(film);
            }

            Console.WriteLine("\nIMDb puanı 4 ile 9 arasında olan filmler:");
            var point = filmList.Where(f => f.ImdbPoint >= 4 && f.ImdbPoint <= 9); //Lambda ve LINQ ile filtreleme
            foreach (var film in point)
            {
                Console.WriteLine(film);
            }

            Console.WriteLine("\nİsmi 'A' ile başlayan filmler:");
            var startswithA = filmList.Where(f => f.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            foreach (var film in startswithA)
            {
                Console.WriteLine(film);
            }
        }
    }
}