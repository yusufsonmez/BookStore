using FluentValidation;

namespace WebApi.Application.GenreOperations.DeleteGenre
// namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class DeleteGenreCommandValidator: AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}