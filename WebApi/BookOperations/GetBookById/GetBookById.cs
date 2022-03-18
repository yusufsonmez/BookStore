using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBookById
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public BookViewModel Model { get; set; }

        public GetBookById(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
     public BookIdViewModel Handle()
        {
             var book = _dbContext.Books.Where(x=>x.Id==BookId).SingleOrDefault();
            //  BookViewModel vm = new BookViewModel();
                        // BookViewModel  vm= new BookViewModel();

            if (book is null)
            {
                throw new InvalidOperationException("There is no book with this id you given!");
            }
            return new BookIdViewModel()
            {
                PageCount = book.PageCount,
                PublishDate = book.PublishDate,
                Title = book.Title
            };

        }
     public class BookIdViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
    }
    
}




    