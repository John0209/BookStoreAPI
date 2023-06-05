using BookStoreAPI.Core.Model;
using Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ImageService : IImageService
    {
        public Task<bool> CreateImage(ImageBook image)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteImage(string imageId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ImageBook>> GetAllImage()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetImageById(string imageId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateImage(ImageBook image)
        {
            throw new NotImplementedException();
        }
    }
}
