using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Contributors.Get;

public record GetContributorQuery(int PersonId) : IQuery<Result<PersonDTO>>;
