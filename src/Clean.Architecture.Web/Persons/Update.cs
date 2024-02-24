using FastEndpoints;
using Clean.Architecture.Web.Endpoints.ContributorEndpoints;
using Clean.Architecture.UseCases.Contributors.Update;
using MediatR;
using Ardalis.Result;
using Clean.Architecture.UseCases.Contributors.Get;

namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// Update an existing Person.
/// </summary>
/// <remarks>
/// Update an existing Person.by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdatePersonRequest, UpdatePersonResponse>
{
  public override void Configure()
  {
    Put(UpdatePersonRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      //XML Docs are used by default but are overridden by these properties:
      s.Summary = "Update a new Person.";
      s.Description = "Update a person.";
      s.ExampleRequest = new CreatePersonRequest { Name = "Mi nuevo nombre", Gender = "Male", PhoneNumber = "1234567890", Age = 85, Email = "adanmendez@gmail.com", Nationality = "German" };

    });
  }
  public override async Task HandleAsync(
    UpdatePersonRequest request,
    CancellationToken cancellationToken)

  {
    var result = await _mediator.Send(new UpdatePersonCommand(request.PersonId, request.Name!, request.Gender!, request.PhoneNumber!, request.Age, request.Email!, request.Nationality!));

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
