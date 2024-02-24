using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

public class UpdatePersonRequest
{
  public const string Route = "/Persons/{PersonId:int}";
  public static string BuildRoute(int personId) => Route.Replace("{PersonId:int}", personId.ToString());

  public int PersonId { get; set; }

  public string? Name { get; set; }
  public string? Gender { get; set; }
  public string? PhoneNumber { get; set; }
  public int Age { get; set; }
  public string? Email { get; set; }
  public string? Nationality { get; set; }
}
