using Clean.Architecture.UseCases.Contributors;
using Clean.Architecture.UseCases.Contributors.List;

namespace Clean.Architecture.Infrastructure.Data.Queries;

public class FakeListContributorsQueryService : IListContributorsQueryService
{
  public Task<IEnumerable<ContributorDTO>> ListAsync()
  {
    List<ContributorDTO> result =
        [new ContributorDTO(1, "Fake Person 1", "", "", 0, "", ""),
        new ContributorDTO(2, "Fake Person 1", "", "",0,"","")];

    return Task.FromResult(result.AsEnumerable());
  }
}
