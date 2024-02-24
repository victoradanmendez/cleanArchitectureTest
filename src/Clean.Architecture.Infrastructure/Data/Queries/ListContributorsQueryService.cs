using Clean.Architecture.UseCases.Contributors;
using Clean.Architecture.UseCases.Contributors.List;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data.Queries;

public class ListContributorsQueryService(AppDbContext _db) : IListPersonQueryService 
{
  // You can use EF, Dapper, SqlClient, etc. for queries - this is just an example

  public async Task<IEnumerable<PersonDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider
    var result = await _db.Database.SqlQuery<PersonDTO>(
      $"SELECT Id, Name, PhoneNumber_Number FROM Contributors") // don't fetch other big columns
      //.Select(c => new PersonDTO(c.Id, c.Name, c.PhoneNumber?.Number ?? ""))
      .ToListAsync();

    return result;
  }
}
