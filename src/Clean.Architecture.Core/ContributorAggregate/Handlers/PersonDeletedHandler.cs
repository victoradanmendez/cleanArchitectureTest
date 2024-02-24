using Clean.Architecture.Core.ContributorAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Architecture.Core.ContributorAggregate.Handlers;

/// <summary>
/// NOTE: Internal because ContributorDeleted is also marked as internal.
/// </summary>
internal class PersonDeletedHandler(ILogger<PersonDeletedHandler> _logger) : INotificationHandler<PersonEvent>
{
  public async Task Handle(PersonEvent domainEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Handling Contributed Deleted event for {contributorId}", domainEvent.ContributorId);

    // TODO: do meaningful work here
    await Task.Delay(1);
  }
}
