namespace Chirp.Tools
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    public class ImageProcessing
    {
        public static byte[] CropTop(byte[] imageBytes, string contentType, int cropHeight = 400)
        {
            if (imageBytes is null)
                throw new ArgumentNullException(nameof(imageBytes));
            if (imageBytes.Length == 0)
                throw new ArgumentException("imageBytes darf nicht leer sein.", nameof(imageBytes));
            if (cropHeight <= 0)
                throw new ArgumentException("cropHeight muss größer als 0 sein.", nameof(cropHeight));

            using var inMs = new MemoryStream(imageBytes);
            using var bmp = new Bitmap(inMs);

            int width = bmp.Width;
            int height = Math.Min(cropHeight, bmp.Height);

            var cropRect = new Rectangle(0, 0, width, height);

            using var cropped = bmp.Clone(cropRect, bmp.PixelFormat);

            using var outMs = new MemoryStream();
            var format = GetImageFormat(contentType) ?? ImageFormat.Jpeg;
            cropped.Save(outMs, format);

            return outMs.ToArray();
        }

        private static ImageFormat GetImageFormat(string contentType)
        {
            if (string.IsNullOrEmpty(contentType)) return null;
            contentType = contentType.ToLowerInvariant();

            return contentType switch
            {
                "image/png" => ImageFormat.Png,
                "image/gif" => ImageFormat.Gif,
                "image/bmp" => ImageFormat.Bmp,
                "image/webp" => ImageFormat.Jpeg, 
                "image/jpeg" or "image/jpg" => ImageFormat.Jpeg,
                _ => ImageFormat.Jpeg
            };
        }
    }
}