using Clean.Architecture.Web.ContributorEndpoints;

namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

public class PersonListResponse
{
  public List<PersonRecord> Contributors { get; set; } = [];
}
