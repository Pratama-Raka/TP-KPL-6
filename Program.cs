class SayaMusicTrack{
    int id;
    string playCount, title;
    public SayaMusicTrack(string title)
    {
        // asign random id dan inisialisasi title dan playcount
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = "0";
    }
    public void IncreasePlayCount(int count)
    {
        // ubah playcount ke int untuk ditambah dengan count
        int current = int.Parse(this.playCount);
        current += count;
        this.playCount = current.ToString();
    }
    // print semua atribut
    public void PrintTrackDetails()
    {
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("Play Count: " + this.playCount);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        // Membuat objek SayaMusicTrack
        SayaMusicTrack track = new SayaMusicTrack("Too Little, Too Late");

        // Memanggil PrintTrackDetails sebelum increase
        Console.WriteLine("Sebelum IncreasePlayCount:");
        track.PrintTrackDetails();

        // Memanggil IncreasePlayCount
        track.IncreasePlayCount(150);

        // Memanggil PrintTrackDetails setelah increase
        Console.WriteLine("Setelah IncreasePlayCount(150):");
        track.PrintTrackDetails();

    }
}
