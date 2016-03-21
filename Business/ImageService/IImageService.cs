using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookva.Business.ImageService
{
    public interface IImageService
    {
        Task<string> UploadAsync(Image image, ImageType type, string publicId);
        void Delete();
    }
}
