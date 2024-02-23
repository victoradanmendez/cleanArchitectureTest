using Abp.Domain.Uow;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Clean.Architecture.UseCases.Contributors.Create;

public class CreatePersonHandler(Core.Interfaces.IWriteService<Person> _repository)
  : ICommandHandler<CreatePersonCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreatePersonCommand request,
    CancellationToken cancellationToken)
  {
    var newContributor = new Person(request.Name, request.Gender,  request.Email, request.Nationality, request.PhoneNumber, request.Age);
    var createdItem = await _repository.addPerson(newContributor, cancellationToken);
       
    return createdItem;
  }
}
