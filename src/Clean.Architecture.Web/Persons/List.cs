using FastEndpoints;
using MediatR;
using Clean.Architecture.Web.Endpoints.ContributorEndpoints;
using Clean.Architecture.UseCases.Contributors.List;

namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// List all Persons
/// </summary>
/// <remarks>
/// List all persons - returns a PersonListResponse containing the Contributors.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<PersonListResponse>
{
  public override void Configure()
  {
    Get("/Persons");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListPersonQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new PersonListResponse
      {
        Contributors = result.Value.Select(c => new PersonRecord(c.Id, c.Name, c.PhoneNumber, c.Gender, c.Age, c.Email, c.Nationality)).ToList()
      };
    }
  }
}
