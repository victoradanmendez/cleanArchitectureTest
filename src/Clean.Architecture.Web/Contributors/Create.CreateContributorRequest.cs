using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

public class CreatePersonRequest

{
  public const string Route = "/Persons";

  [Required]
  public string? Name { get; set; }
  [Required]
  public string? PhoneNumber { get; set; }
  public string? Gender { get; set; }
  public int Age { get; set; }
  public string? Email { get; set; }
  public string? Nationality { get; set; }

}
