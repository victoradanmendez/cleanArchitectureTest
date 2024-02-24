using FastEndpoints;
using MediatR;
using Ardalis.Result;
using Clean.Architecture.Web.Endpoints.ContributorEndpoints;
using Clean.Architecture.UseCases.Contributors.Get;

namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// Get a Person by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Person record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetPersonByIdRequest, PersonRecord>
{
  public override void Configure()
  {
    Get(GetPersonByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetPersonByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetPersonQuery(request.PersonId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new PersonRecord(request.PersonId, result.Value.Name, result.Value.PhoneNumber, result.Value.Gender, result.Value.Age, result.Value.Email, result.Value.Nationality);
    }
  }
}
