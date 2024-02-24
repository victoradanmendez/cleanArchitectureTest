using Clean.Architecture.Core.ContributorAggregate;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.ContributorAggregate;

public class ContributorConstructor
{
  private readonly string _testName = "test name";
  private PersonWriteDAO? _testContributor;

  private PersonWriteDAO CreateContributor()
  {
    return new PersonWriteDAO("","",_testName, "", "",0);
  }

  [Fact]
  public void InitializesName()
  {
    _testContributor = CreateContributor();

    Assert.Equal(_testName, _testContributor.Name);
  }
}
