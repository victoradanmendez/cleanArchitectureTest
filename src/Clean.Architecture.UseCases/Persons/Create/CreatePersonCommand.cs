using Ardalis.Result;

namespace Clean.Architecture.UseCases.Contributors.Create;

/// <summary>
/// Create a new Person.
/// </summary>
/// <param name="Name"></param>
//public record CreatePersonCommand(string Name, string? PhoneNumber) : Ardalis.SharedKernel.ICommand<Result<int>>;
public record CreatePersonCommand(string Name, string Gender, string PhoneNumber, int Age,  string Email, string Nationality) : Ardalis.SharedKernel.ICommand<Result<int>>;
