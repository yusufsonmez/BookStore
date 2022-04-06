using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Entities{
   public class Book
   {
       
       // Id auto increment
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
       public string? Title { get; set; }
       public int GenreId { get; set; }
       public int PageCount { get; set; }
       public DateTime PublishDate { get; set; }
   } 
}