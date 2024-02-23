using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Contributors.Update;

public record UpdatePersonCommand(int PersonId, string Name, string Gender, string PhoneNumber, int Age, string Email, string Nationality) : ICommand<Result<ContributorDTO>>;
