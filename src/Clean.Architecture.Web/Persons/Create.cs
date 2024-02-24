using FastEndpoints;
using Clean.Architecture.Web.Endpoints.ContributorEndpoints;
using Clean.Architecture.UseCases.Contributors.Create;
using MediatR;
using Clean.Architecture.Infrastructure.Data;

namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// Create a new Person
/// </summary>
/// <remarks>
/// Creates a new Person given a name, age, gender, etc..
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreatePersonRequest, CreatePersonResponse>
{
  public override void Configure()
  {
    Post(CreatePersonRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      //XML Docs are used by default but are overridden by these properties:
      s.Summary = "Create a new Person.";
      s.Description = "Create a new persons. A valid name is required.";
      s.ExampleRequest = new CreatePersonRequest { Name = "Víctor Adán Méndez Medrano", Gender ="Male", PhoneNumber= "4772365478", Age=33,Email="adanmendezeng@gmail.com", Nationality= "Mexican" };
    });
  }

  public override async Task HandleAsync(
    CreatePersonRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreatePersonCommand(request.Name!, request.Gender!, request.PhoneNumber!, request.Age, request.Email!, request.Nationality!));

    if(result.IsSuccess)
    {
      Response = new CreatePersonResponse(result.Value, request.Name!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
