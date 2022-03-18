using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        // When program running this part will be run first
        public static void Initialize(IServiceProvider serviceProvider)
        
        {
        using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                        // Id's are auto incremented
                        //Id = 1,  
                        Title = "Suc ve Ceza",
                        GenreId = 1, // Novel
                        PageCount = 450,
                        PublishDate = new DateTime(1985, 06, 12),

                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "1984",
                        GenreId = 2, // History
                        PageCount = 400,
                        PublishDate = new DateTime(1984, 03, 10),

                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Aspidistra",
                        GenreId = 1, // Novel
                        PageCount = 200,
                        PublishDate = new DateTime(1999, 09, 20),

                    });
                context.SaveChanges();
            }
        }
    }
}