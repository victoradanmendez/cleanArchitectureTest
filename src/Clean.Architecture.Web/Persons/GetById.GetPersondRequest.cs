namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

public class GetPersonByIdRequest
{
  public const string Route = "/Persons/{PersonId:int}";
  public static string BuildRoute(int PersonId) => Route.Replace("{PersonId:int}", PersonId.ToString());

  public int PersonId { get; set; }
}
