using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Contributors.Delete;

public record DeletePersonCommand(int PersonId) : ICommand<Result>;
