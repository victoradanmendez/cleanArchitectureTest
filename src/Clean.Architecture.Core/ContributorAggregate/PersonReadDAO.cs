using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.ContributorAggregate;
public class PersonReadDAO(string name, string gender, string eMail, string nationality, string phoneNumber, int age, int personId) : EntityBase, IAggregateRoot
{
  public int PersonId { get; private set; } = Guard.Against.Null(personId, nameof(personId));
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public string PhoneNumber { get; private set; } = Guard.Against.NullOrEmpty(phoneNumber, nameof(phoneNumber));
  public string Gender { get; private set; } = Guard.Against.NullOrEmpty(gender, nameof(gender));
  public int Age { get; private set; } = Guard.Against.Null(age, nameof(age));
  public string Email { get; private set; } = Guard.Against.NullOrEmpty(eMail, nameof(eMail));
  public string Nationality { get; private set; } = Guard.Against.NullOrEmpty(nationality, nameof(nationality));
}
