using Clean.Architecture.Web.ContributorEndpoints;

namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

public class UpdatePersonResponse(PersonRecord person)
{
  public PersonRecord Contributor { get; set; } = person;
}
