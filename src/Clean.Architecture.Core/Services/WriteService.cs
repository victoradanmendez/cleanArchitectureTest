using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.Interfaces;

namespace Clean.Architecture.Core.Services;
public class WriteService : IWriteService<Person>
{
  public Task<Result> addPerson(Person person, CancellationToken cancellationToken)
  {



    throw new NotImplementedException();
  }

  public Task<int> deletePerson(int personId, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<int> updatePerson(Person person, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<int> updatePerson(int personId, Person person, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  Task<int> IWriteService<Person>.addPerson(Person person, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
