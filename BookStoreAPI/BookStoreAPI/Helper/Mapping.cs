using AutoMapper;
using BookStoreAPI.Core.DTO;
using BookStoreAPI.Core.Model;

namespace BookStoreAPI.Helper
{
    public class Mapping:Profile
    {
        public Mapping()
        { 
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<BookDetailDTO,Book>().ReverseMap(); 
            CreateMap<ImageDTO,ImageBook>().ReverseMap();
        }

    }
}
