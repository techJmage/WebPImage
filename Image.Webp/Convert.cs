using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;

namespace ImageConversion;

/// <summary>simple and light .netcore service for work with webp images
/// <para>developed by mojtaba moradi (mojtabamoradi.net@outlook.com)</para>
/// <para>inspired by Wrapper for WebP format in C#. (GPL) Jose M. Piñeiro</para>
/// </summary>
public static class Convert
{
    
    public static void ToWebP(Stream imgStream, string destPath, Size? size = null, int quality = 100)
    {
        if (string.IsNullOrEmpty(destPath)) 
            throw new DirectoryNotFoundException();
        if (quality <= 0 || quality > 100) { quality = 100; }
        using WebP webp = new();
        Bitmap bmp = new(imgStream);
        if (size.HasValue)
        {
            var webp_byte = WebP.EncodeLossless(bmp);
            bmp = WebP.GetThumbnailQuality(webp_byte, size.Value.Width, size.Value.Height);
        }
        WebP.Save(bmp, destPath, quality);
        bmp.Dispose();
    }
    
    public static byte[] ToWebPByte(Stream imgStream, Size? size = null, int quality = 100)
    {
        if (quality <= 0 || quality > 100) { quality = 100; }
        using WebP webp = new();
        Bitmap bmp = new(imgStream);
        if (size.HasValue)
        {
            var webp_byte = WebP.EncodeLossless(bmp);
            bmp = WebP.GetThumbnailQuality(webp_byte, size.Value.Width, size.Value.Height);
        }
        var data = WebP.EncodeLossy(bmp, quality);
        bmp.Dispose();
        return data;
    }
    
    public static void Resize(Stream imgStream, string destPath, int width, int height, ImageFormat? format = null, bool compress = false)
    {
        if (string.IsNullOrEmpty(destPath) || width <= 0 || height <= 0)
            throw new DirectoryNotFoundException();        
        using WebP webp = new();
        Bitmap bmp = new(imgStream);
        var webp_byte = WebP.EncodeLossless(bmp);
        if (compress) { bmp = WebP.GetThumbnailFast(webp_byte, width, height); }
        else { bmp = WebP.GetThumbnailQuality(webp_byte, width, height); }
        bmp.Save(destPath, format ?? ImageFormat.Jpeg);
        bmp.Dispose();
    }    

}

