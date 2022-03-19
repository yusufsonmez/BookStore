using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;
using AutoMapper;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BookViewModel> Handle()
        {
             var bookList = _dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
             List<BookViewModel> vm = _mapper.Map<List<BookViewModel>>(bookList); // new List<BookViewModel>();

          return vm;

        }

        
    }
    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}