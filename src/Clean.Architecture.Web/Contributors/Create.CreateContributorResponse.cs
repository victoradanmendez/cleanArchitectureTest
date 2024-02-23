namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

public class CreatePersonResponse(int id, string name)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
}
