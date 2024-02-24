using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Contributors.Get;

public record GetPersonQuery(int PersonId) : IQuery<Result<PersonDTO>>;
