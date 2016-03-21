using System;
using System.Drawing;

namespace Bookva.Business.ImageService
{
    public enum ImageType
    { 
        Miniature,
        UserPic,
        BookCover
    }

    static class ImageSizeConverter
    {
        private const int MINIATURE_DIMENTIONS = 120;
        private const int USER_DIMENTIONS = 600;
        private const int BOOKCOVER_DIMENTIONS = 1000;

        public static Size ToSize(this ImageType type)
        {
            switch (type)
            {
                case ImageType.Miniature:
                    return new Size(MINIATURE_DIMENTIONS, MINIATURE_DIMENTIONS);
                case ImageType.UserPic:
                    return new Size(USER_DIMENTIONS, USER_DIMENTIONS);
                case ImageType.BookCover:
                    return new Size(BOOKCOVER_DIMENTIONS, BOOKCOVER_DIMENTIONS);
                default:
                    throw new ArgumentException("Unknown ImageType");
            }
        }
    }
}
