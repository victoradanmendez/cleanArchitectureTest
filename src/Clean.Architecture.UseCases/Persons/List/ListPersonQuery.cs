using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Contributors.List;

public record ListPersonQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<PersonDTO>>>;
