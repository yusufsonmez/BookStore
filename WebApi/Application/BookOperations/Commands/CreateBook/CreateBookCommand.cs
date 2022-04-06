
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.BookOperations
{
    
        public class CreateBookCommand
        {
            public CreateBookModel Model {get;set;}
            private readonly BookStoreDbContext _dbContext;
            private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
            {
            var book = _dbContext.Books.SingleOrDefault(x=> x.Title == Model.Title);
            if(book is not null)
               throw new InvalidOperationException("The book is already exist.");
            // Model ile gelen veriyi book objesine convert et. Zaten CreateBookModelden geliyor burdaki model   
            book = _mapper.Map<Book>(Model); // new Book();

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            }

            public class CreateBookModel
            {
                public string Title { get; set; }
                public int GenreId { get; set; }
                public int PageCount { get; set; }
                public DateTime PublishDate { get; set; }
            }
        }
    }