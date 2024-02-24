namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

public class GetContributorByIdRequest
{
  public const string Route = "/Persons/{PersonId:int}";
  public static string BuildRoute(int contributorId) => Route.Replace("{PersonId:int}", contributorId.ToString());

  public int PersonId { get; set; }
}
