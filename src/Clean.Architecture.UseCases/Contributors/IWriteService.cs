using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Clean.Architecture.Core.ContributorAggregate;

namespace Clean.Architecture.UseCases.Contributors;
public interface IWriteService<T>
{
  Task<Result<int>> MiMetodoAgregar(Person contributor, CancellationToken cancellationToken);
}
