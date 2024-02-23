using Ardalis.Specification;

namespace Clean.Architecture.Core.ContributorAggregate.Specifications;

public class ContributorByIdSpec : Specification<Person>
{
  public ContributorByIdSpec(int contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
