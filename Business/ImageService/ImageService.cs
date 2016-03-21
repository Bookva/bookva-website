using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookva.Business.ImageService
{
    public class ImageService : IImageService
    {
        private ImageResizer resizer;
        private Cloudinary cloudinary;

        public ImageService()
        {
            Account acc = new Account(
                    Properties.Settings.Default.CloudName,
                    Properties.Settings.Default.ApiKey,
                    Properties.Settings.Default.ApiSecret);

            cloudinary = new Cloudinary(acc);
            resizer = new ImageResizer();
        }
        
        public async Task<string> UploadAsync(Image image, ImageType type, string publicId)
        {
            image = resizer.ResizeImage(image, type);
            var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Png);
            stream.Position = 0;
            var result = await cloudinary.UploadAsync(new ImageUploadParams()
            {
                File = new FileDescription(publicId, stream),
                PublicId = publicId,
                Overwrite = true                 
            });

            return result.Uri.ToString();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
        
    }
}
