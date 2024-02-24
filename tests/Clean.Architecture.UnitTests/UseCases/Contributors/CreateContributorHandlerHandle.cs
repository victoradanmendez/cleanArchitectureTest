using Ardalis.SharedKernel;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.UseCases.Contributors.Create;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.UseCases.Contributors;

public class CreateContributorHandlerHandle
{
  private readonly string _testName = "test name";
  private readonly IRepository<PersonWriteDAO> _repository = Substitute.For<IRepository<PersonWriteDAO>>();



  private PersonWriteDAO CreateContributor()
  {
    return new PersonWriteDAO("",_testName,"","", "",0);
  }


}
