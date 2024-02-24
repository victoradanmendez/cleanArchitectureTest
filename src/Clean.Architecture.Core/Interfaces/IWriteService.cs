using Ardalis.Result;
using Clean.Architecture.Core.ContributorAggregate;

namespace Clean.Architecture.Core.Interfaces;
public interface IWriteService<T>
{
  public Task<int> addPerson(PersonWriteDAO person, CancellationToken cancellationToken);
  public Task<int> updatePerson(int personId, PersonWriteDAO person, CancellationToken cancellationToken);
  public Task<int> deletePerson(int personId, CancellationToken cancellationToken);
}
