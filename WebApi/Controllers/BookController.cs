using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBookCommand;
using static WebApi.BookOperations.GetBooks.GetBookById;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;


namespace WebApi.AddConstrollers{

[ApiController]
[Route("[controller]s")]
 public class BookController:ControllerBase
 {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }


         [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookIdViewModel result;

            GetBookById getBookById = new GetBookById(_context);
            

            try
            {
                getBookById.BookId=id;

                getBookById.Handle();   
                result =getBookById.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
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

            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }

         [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook)
        {

            UpdateBookCommand command = new UpdateBookCommand(_context);

             try
            {
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }

          [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x=> x.Id == id);
            if(book is null)
                return BadRequest();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }

 }
}