using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Bookva.Business.ImageService
{    
    internal class ImageResizer
    {
        public Image CropImage(Image image, ImageType type)
        {
            var size = type.ToSize();
            
            var cropArea = GetCropArea(size, image.Size);
            Bitmap bmpImage = new Bitmap(image);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        private Rectangle GetCropArea(Size newSize, Size imageSize)
        {
            return new Rectangle
            {
                Height = Math.Min(newSize.Height, imageSize.Height),
                Width = Math.Min(newSize.Width, imageSize.Width)
            };
        }

        public Image ResizeImage(Image image, ImageType type)
        {
            var size = GetNewSize(type, image.Size);
            var destRect = new Rectangle(0, 0, size.Width, size.Height);
            var destImage = new Bitmap(size.Width, size.Height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.AssumeLinear;
                graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                graphics.SmoothingMode = SmoothingMode.HighSpeed;
                graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private Size GetNewSize(ImageType type, Size imageSize)
        {
            var desiredSize = type.ToSize();
            var proportions = 1.0;

            if (imageSize.Width > desiredSize.Width)
            {
                proportions = (double)imageSize.Width / desiredSize.Width;
                imageSize.Width = desiredSize.Width;
                imageSize.Height = (int)Math.Round(imageSize.Height/proportions);
            }
            if (imageSize.Height > desiredSize.Height)
            {
                proportions = (double)imageSize.Height / desiredSize.Height;
                imageSize.Height = desiredSize.Height;
                imageSize.Width = (int)Math.Round(imageSize.Width / proportions);
            }
            return imageSize;
        }
    }
}
