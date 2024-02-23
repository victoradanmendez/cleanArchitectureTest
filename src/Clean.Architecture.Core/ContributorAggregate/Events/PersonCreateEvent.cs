using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.ContributorAggregate.Events;
internal sealed class PersonCreateEvent(string personName) : DomainEventBase
{
  public string PersonName { get; init; } = personName;

}
