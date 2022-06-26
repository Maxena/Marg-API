using System.Reflection;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Common;

public static class ImageHelper
{
    private static ILogger _logger;

    /// <summary>
    /// Save Image As .Webp Format With Given Height And Width
    /// </summary>
    /// <param name="inStream"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="path"></param>
    /// <param name="ct"></param>
    public static void SaveImageWithGivenSize(Stream inStream, int width, int height, string path, CancellationToken ct)
    {
        try
        {
            var image = Image.Load(inStream);

            image.Mutate(_ =>
                _.Resize(width, height));

            image.SaveAsWebpAsync(path, ct);
        }
        catch (Exception e)
        {
            _logger.Fatal("Failed To Save Image in function {F} With Exception {E}",
                MethodBase.GetCurrentMethod()!.Name,
                e.ToString());
            throw;
        }
    }

    /// <summary>
    /// Save Image As .Webp Format With Original Height And Width
    /// </summary>
    /// <param name="inStream"></param>
    /// <param name="path"></param>
    /// <param name="ct"></param>
    public static void SaveImageWithOriginalWidthAndHeight(Stream inStream, string path, CancellationToken ct)
    {
        try
        {
            var image = Image.Load(inStream);

            image.SaveAsWebpAsync(path, ct);
        }
        catch (Exception e)
        {
            _logger.Fatal("Failed To Save Image in function {F} With Exception {E}",
                MethodBase.GetCurrentMethod()!.Name,
                e.ToString());
            throw;
        }
    }

    /// <summary>
    /// Set WaterMark Label For Photos 
    /// </summary>
    /// <param name="processingContext"></param>
    /// <returns></returns>
    private static IImageProcessingContext WaterMark(this IImageProcessingContext processingContext)
    {
        try
        {
            var logo = Image.Load("wwwroot/Resources/watermark.png");

            var (imageHeight, imageWidth) = processingContext.GetCurrentSize();

            var wmSize = new Size((int)(imageWidth * 0.2), (int)(imageWidth * 0.2 * logo.Height / logo.Width));

            var location = new Point(imageWidth - wmSize.Width - 10, imageHeight - wmSize.Height - 10);

            logo.Mutate(_ => _.Resize(wmSize));

            return processingContext.DrawImage(logo, location, PixelColorBlendingMode.Normal, 0.8f);
        }
        catch (Exception e)
        {
            _logger.Fatal("Failed To Save Image in function {F} With Exception {E}",
                MethodBase.GetCurrentMethod()!.Name,
                e.ToString());
            throw;
        }
    }
}