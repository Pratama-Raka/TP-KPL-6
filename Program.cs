using System.Diagnostics;

class SayaMusicTrack{
    int id, playCount;
    string title;
    public SayaMusicTrack(string title)
    {
        // Precondition: title tidak null dan maksimal 100 karakter
        Debug.Assert(title != null, "Precondition failed: Judul track tidak boleh null.");
        Debug.Assert(title.Length <= 100, "Precondition failed: Judul track maksimal 100 karakter.");

        // asign random id dan inisialisasi title dan playcount
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int count)
    {
        // Precondition: count tidak melebihi 10.000.000
        Debug.Assert(count <= 10_000_000, "Precondition failed: Input penambahan play count maksimal 10.000.000.");

        try
        {
            // playcount ditambah dengan input count
            this.playCount = checked(this.playCount + count);
        }
        catch (OverflowException)
        {
            Console.WriteLine($"[EXCEPTION] OverflowException: Penambahan play count melebihi batas maksimum integer. PlayCount tetap: {playCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[EXCEPTION] Terjadi kesalahan: {ex.Message}");
        }
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
        Console.WriteLine("===== UJI PRECONDITION =====\n");

        // Uji title null — Assert langsung gagal & hentikan program
        Console.WriteLine(">> Uji: Title null");
        SayaMusicTrack track1 = new SayaMusicTrack(null);

        // Uji title > 100 karakter
        Console.WriteLine(">> Uji: Title lebih dari 100 karakter");
        SayaMusicTrack track2 = new SayaMusicTrack(new string('A', 101));

        // Uji count > 10.000.000
        Console.WriteLine(">> Uji: IncreasePlayCount dengan count > 10.000.000");
        SayaMusicTrack track3 = new SayaMusicTrack("Satu Bulan");
        track3.IncreasePlayCount(10_000_001);

        Console.WriteLine("\n===== UJI OVERFLOW (checked) =====\n");

        // Uji overflow menggunakan for loop
        SayaMusicTrack trackOverflow = new SayaMusicTrack("Overflow Song");
        Console.WriteLine("Kondisi awal:");
        trackOverflow.PrintTrackDetails();

        Console.WriteLine("\n>> Menambahkan play count hingga overflow...");
        for (int i = 0; i < 220; i++)
        {
            trackOverflow.IncreasePlayCount(10_000_000);
        }

        Console.WriteLine("\nKondisi setelah percobaan overflow:");
        trackOverflow.PrintTrackDetails();

        Console.WriteLine("\n===== UJI NORMAL =====\n");

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
