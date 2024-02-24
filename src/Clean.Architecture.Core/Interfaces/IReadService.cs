using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Architecture.Core.ContributorAggregate;

namespace Clean.Architecture.Core.Interfaces;
public interface IReadService
{
  public Task<PersonWriteDAO> getPerson(int personId, CancellationToken cancellationToken);
  public Task<bool> existsPerson(int personId, CancellationToken cancellationToken);
  public Task<List<PersonReadDAO>> getListPersons(CancellationToken cancellationToken);
 

  
}
