using AutoMapper;
using WebApi.BookOperations.GetBooks;
using static WebApi.BookOperations.CreateBookCommand;
using static WebApi.BookOperations.GetBooks.GetBookById;
using WebApi.Entities;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateBook objesi Book objesine maplenebilir olsun
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book,BookIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
        }
    }
}