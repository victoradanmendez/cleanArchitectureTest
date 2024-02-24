using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeleteContributorValidator : Validator<DeletePersonRequest>
{
  public DeleteContributorValidator()
  {
    RuleFor(x => x.PersonId)
      .GreaterThan(0);
  }
}
