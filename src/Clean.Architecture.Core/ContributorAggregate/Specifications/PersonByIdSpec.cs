using Ardalis.Specification;

namespace Clean.Architecture.Core.ContributorAggregate.Specifications;

public class PersonByIdSpec : Specification<PersonWriteDAO>
{
  public PersonByIdSpec(int contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
