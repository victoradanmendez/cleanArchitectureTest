namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

public record DeleteContributorRequest
{
  public const string Route = "/Persons/{PersonId:int}";
  public static string BuildRoute(int contributorId) => Route.Replace("{PersonId:int}", contributorId.ToString());



  public int PersonId { get; set; }
}
