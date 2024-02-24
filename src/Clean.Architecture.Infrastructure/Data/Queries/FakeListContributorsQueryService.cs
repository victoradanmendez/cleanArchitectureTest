using Clean.Architecture.UseCases.Contributors;
using Clean.Architecture.UseCases.Contributors.List;

namespace Clean.Architecture.Infrastructure.Data.Queries;

public class FakeListContributorsQueryService : IListPersonQueryService
{
  public Task<IEnumerable<PersonDTO>> ListAsync()
  {
    List<PersonDTO> result =
        [new PersonDTO(1, "Fake Person 1", "", "", 0, "", ""),
        new PersonDTO(2, "Fake Person 1", "", "",0,"","")];

    return Task.FromResult(result.AsEnumerable());
  }
}
