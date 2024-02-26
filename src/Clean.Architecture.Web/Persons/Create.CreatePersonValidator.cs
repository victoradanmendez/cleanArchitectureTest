using Clean.Architecture.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreateContributorValidator : Validator<CreatePersonRequest>
{
  public CreateContributorValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    RuleFor(x => x.PhoneNumber)
      .NotEmpty()
      .WithMessage("PhoneNumbe is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_PHONE_LENGTH);



    RuleFor(x => x.Gender)
      .NotEmpty()
      .WithMessage("Gender is required.")
      .MinimumLength(4)
      .MaximumLength(6);

    RuleFor(x => x.Email).NotEmpty().WithMessage("Email is requiered");

  }
}
