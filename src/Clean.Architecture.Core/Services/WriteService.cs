using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.Interfaces;

namespace Clean.Architecture.Core.Services;
public class WriteService : IWriteService<PersonWriteDAO>
{
  public Task<Result> addPerson(PersonWriteDAO person, CancellationToken cancellationToken)
  {



    throw new NotImplementedException();
  }

  public Task<int> deletePerson(int personId, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<int> updatePerson(PersonWriteDAO person, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<int> updatePerson(int personId, PersonWriteDAO person, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  Task<int> IWriteService<PersonWriteDAO>.addPerson(PersonWriteDAO person, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
