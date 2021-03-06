using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBookCommand;
using static WebApi.BookOperations.GetBooks.GetBookById;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;


namespace WebApi.Controllers{

[ApiController]
[Route("[controller]s")]
 public class BookController:ControllerBase
 {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }


         [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            
            BookIdViewModel result;
    
            GetBookById command = new GetBookById(_context, _mapper);
            command.BookId=id;

            GetBookByIdValidator validator = new GetBookByIdValidator();

            validator.ValidateAndThrow(command);
            result =command.Handle();
    
           
            return Ok(result);

        }


        // With FROMQUERY
        // [HttpGet]
        // public Book Get( [FromQuery] string id)
        // {
        //     var book = BookList.Where(book=>book.Id==Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            // try
            // {
                command.Model = newBook;
                
                // validation; before handling
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                // ValidationResult result = validator.Validate(command);
                validator.ValidateAndThrow(command);
                // If it gets an error, it will return 500 and there will be explanations in it. Else it will response 200
                command.Handle();


                // If all rules passed IsValid return true, else return false

                // if(!result.IsValid)
                //         foreach(var item in result.Errors)
                //         {
                //             // which property? what is the error?
                //             Console.WriteLine("Property " + item.PropertyName + " - Error Message: " + item.ErrorMessage);
                //         }
                // else
                //     command.Handle();
            // }
            // catch(Exception ex)
            // {
            //     return BadRequest(ex.Message);
            // }
            
            return Ok();
        }

         [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook)
        {

            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updatedBook;
            
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        }

          [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
 
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
        
            return Ok();
        }

 }
}