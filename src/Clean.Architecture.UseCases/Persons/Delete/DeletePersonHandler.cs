using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.Interfaces;
using MediatR;

namespace Clean.Architecture.UseCases.Contributors.Delete;

public class DeletePersonHandler(Core.Interfaces.IWriteService<PersonWriteDAO> _writeService)
  : ICommandHandler<DeletePersonCommand, Result>
{
 
  async Task<Result>  IRequestHandler<DeletePersonCommand, Result>.Handle(DeletePersonCommand request, CancellationToken cancellationToken)
  {
    var result =  await _writeService.deletePerson(request.PersonId, cancellationToken);
    if (result == 0)
    {
      return Result.NotFound();
    }
    return Result.Success();
  }
}
