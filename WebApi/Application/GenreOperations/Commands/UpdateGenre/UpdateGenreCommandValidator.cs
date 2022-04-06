using FluentValidation;

namespace WebApi.Application.GenreOperations.UpdateGenre
// namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class UpdateGenreCommandValidator: AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
        }
    }
}