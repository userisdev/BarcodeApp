using SkiaSharp;

var imagePath = args.FirstOrDefault();
if (!File.Exists(imagePath))
{
    Console.WriteLine("not found.");
    Console.ReadKey(true);
    Environment.Exit(1);
}

var data = File.ReadAllBytes(imagePath);
Console.WriteLine($"size={data.Length}");
using var bmp = SKBitmap.Decode(data);
var result = BarcodeResult.Load(imagePath);

Console.WriteLine($"result={result}");

Console.WriteLine("press any key to exit . . .");
Console.ReadKey(true);
Environment.Exit(0);