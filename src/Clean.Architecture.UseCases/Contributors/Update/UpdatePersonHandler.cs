using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.ContributorAggregate;

namespace Clean.Architecture.UseCases.Contributors.Update;

public class UpdatePersonHandler(Core.Interfaces.IWriteService<Person> _repository)
  : ICommandHandler<UpdatePersonCommand, Result<ContributorDTO>>
{
  public async Task<Result<ContributorDTO>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
  {
    var updatePerson = new Person
        (request.Name, request.Gender, request.Email, request.Nationality, request.PhoneNumber, request.Age);

    var result = await _repository.updatePerson(request.PersonId, updatePerson, cancellationToken);
    if (result == 0)
    {
      return Result.NotFound();
    }
    return Result.Success();
  }
}
