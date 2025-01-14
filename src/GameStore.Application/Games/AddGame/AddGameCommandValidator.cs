using FluentValidation;
using GameStore.Domain.Shared;

namespace GameStore.Application.Games.AddGame;

public sealed class AddGameCommandValidator : AbstractValidator<AddGameCommand>
{
    public AddGameCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(1000);
        RuleFor(x => x.Price)
            .NotEmpty()
            .Matches(@"^\d+(\.\d{1,2})?$");

        RuleFor(x => x.Currency)
            .Must(c => Currency.All.Contains(c))
            .WithMessage("The currency code is invalid");

        RuleFor(x => x.ReleaseDate)
            .Must(x => x.NotInFuture())
            .WithMessage("The release date must not be in the future");
    }
}