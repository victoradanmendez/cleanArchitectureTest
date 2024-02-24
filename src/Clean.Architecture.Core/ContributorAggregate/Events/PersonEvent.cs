using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.ContributorAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a contributor is deleted.
/// The DeleteContributorService is used to dispatch this event.
/// </summary>
internal sealed class PersonEvent(int contributorId) : DomainEventBase
{
  public int ContributorId { get; init; } = contributorId;
}
