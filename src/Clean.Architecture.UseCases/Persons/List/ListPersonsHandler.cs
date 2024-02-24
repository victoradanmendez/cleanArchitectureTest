using Abp.Collections.Extensions;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.Interfaces;

namespace Clean.Architecture.UseCases.Contributors.List;

public class ListPersonsHandler(IReadService _query)
  : IQueryHandler<ListPersonQuery, Result<IEnumerable<PersonDTO>>>
{
  /// <summary>
  /// This class is like "Controller Handler" of the actions ""
  /// </summary>
  /// <param name="request"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public async Task<Result<IEnumerable<PersonDTO>>> Handle(ListPersonQuery request, CancellationToken cancellationToken)
  {
    var lstPersons = await _query.getListPersons(cancellationToken);
    //Maps data base result from ADO to DTO
    return convertLstPersonADOToDTO(lstPersons);
    
  }
  /// <summary>
  /// Maps data base result from ADO to DTO
  /// </summary>
  /// <param name="lstPersons"></param>
  /// <returns></returns>
  private Result<IEnumerable<PersonDTO>> convertLstPersonADOToDTO(List<PersonReadDAO> lstPersons)
  {
    List<PersonDTO> lstPersonDTOs = new List<PersonDTO>();
    foreach (var person in lstPersons)
    {
      lstPersonDTOs.Add
        (
        new PersonDTO(person.PersonId, person.Name, person.PhoneNumber, person.Gender, person.Age, person.Email, person.Nationality
        ));
    }
    return lstPersonDTOs;
  }
}
