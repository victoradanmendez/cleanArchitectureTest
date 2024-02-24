

using FastEndpoints;
using Ardalis.Result;
using MediatR;
using Clean.Architecture.Web.Endpoints.ContributorEndpoints;
using Clean.Architecture.UseCases.Contributors.Delete;

namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// Delete a Person.
/// </summary>
/// <remarks>
/// Delete a Person by providing a valid integer id.
/// </remarks>
public class Delete(IMediator _mediator)
  : Endpoint<DeleteContributorRequest>
{
  public override void Configure()
  {
    Delete(DeleteContributorRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteContributorRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeletePersonCommand(request.PersonId);

    var result = await _mediator.Send(command);
    if (result.Status == ResultStatus.NotFound)
    {

      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.Status == ResultStatus.Ok)
    {
      // Se puede manejar una acción, como publicar en un esquema "Publisher-Suscriber"
      return;
    }
  }
}
