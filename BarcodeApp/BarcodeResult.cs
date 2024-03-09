using SkiaSharp;
using ZXing.Common;
using ZXing;
using ZXing.SkiaSharp;

/// <summary> BarcodeResult recod. </summary>
/// <seealso cref="System.IEquatable&lt;TABBotApp.Libs.Workers.Barcode.BarcodeResult&gt;" />
internal sealed record BarcodeResult(string Text, bool HasValue)
{
    /// <summary> Loads the specified path. </summary>
    /// <param name="path"> The path. </param>
    /// <returns> </returns>
    public static BarcodeResult Load(string path)
    {
        using SKBitmap bmp = SKBitmap.Decode(path);
        if (bmp is null)
        {
            Console.WriteLine("image decode error.");
        }

        BarcodeReader reader = new()
        {
            AutoRotate = true,
            Options = new DecodingOptions
            {
                TryInverted = true,
                TryHarder = true,
                PureBarcode = false,
                PossibleFormats = [BarcodeFormat.EAN_13]
            }
        };

        Result? result = reader.Decode(bmp);
        return result is null ? new BarcodeResult(string.Empty, false) : new BarcodeResult(result.Text, true);
    }

    /// <summary> Converts to string. </summary>
    /// <returns> </returns>
    public override string ToString()
    {
        return HasValue ? Text : "[error]";
    }
}