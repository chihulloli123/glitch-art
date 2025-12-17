using System; 
using System.Text;

class Program
{
    static Random rng = new Random();

    static void Main()
    {
        Console.WriteLine("Type Something:   ");
        var input = Console.ReadLine();

        double intensity = 0.25;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(Glitch(input, intensity));
            intensity = Math.Min(1.0, intensity + 0.05);
            System.Threading.Thread.Sleep(400);
        }
    }

    static string Glitch(string text, double intensity)
    {
        var sb = new StringBuilder();

        foreach (char c in text)
        {
            sb.Append(c);

            if (rng.NextDouble() < intensity)
                sb.Append(GlitchChar());
        }

        return sb.ToString();
    }

    static char GlitchChar()
    {
        int[] ranges = { 0x0300, 0x2000, 0x25A0, 0x2580 };
        int baseChar = ranges[rng.Next(ranges.Length)];
        return (char)(baseChar + rng.Next(0, 64));
    }
}