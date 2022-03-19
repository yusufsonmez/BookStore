using FluentValidation;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBookByIdValidator : AbstractValidator<GetBookById>
    {
        public GetBookByIdValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}