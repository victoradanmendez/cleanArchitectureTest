using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.ContributorAggregate.Specifications;

namespace Clean.Architecture.UseCases.Contributors.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetContributorHandler(Core.Interfaces.IReadService _repository)
  : IQueryHandler<GetContributorQuery, Result<PersonDTO>>
{
  public async Task<Result<PersonDTO>> Handle(GetContributorQuery request, CancellationToken cancellationToken)
  {
    var spec = new ContributorByIdSpec(request.PersonId);
    //Primero validamos si existe el registro
    var resultGet = await _repository.existsPerson(request.PersonId, cancellationToken);
    if (resultGet == false)
    {
      return Result.NotFound();
    }
      //Si existe, se obtiene
      var entity = await _repository.getPerson(request.PersonId, cancellationToken);
      Result.Success();
      return new PersonDTO(entity.Id, entity.Name, entity.PhoneNumber ?? "", entity.Gender, entity.Age, entity.Email, entity.Nationality);
   
  }
}
