using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.Interfaces;
using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;

namespace Clean.Architecture.Infrastructure.Data;
internal class ReadService : IReadService
{
  private ConexionMySQL _conexionMySql;

  public ReadService()
  {
    _conexionMySql = new ConexionMySQL();
  }

  public async Task<bool> existsPerson(int personId, CancellationToken cancellationToken)
  {
    string select = "select * FROM person WHERE pk_person=@id;";

    //DataBase instance is obtained
    MySqlDataReader? mySqlReader;

    MySqlCommand mySqlCommand = new MySqlCommand(select);
    mySqlCommand.Connection = _conexionMySql.GetConnection();


    //Parameters are added into SQLCommand Object
    mySqlCommand.Parameters.Add(new MySqlParameter("@id", personId));
    mySqlReader = await Task.Run(() => mySqlCommand.ExecuteReader());
    
    while (mySqlReader.Read())
    {
      return true;
    }
    return false;
  }

  public async Task<Person> getPerson(int personId, CancellationToken cancellationToken)
  {
    string select = "select * FROM person WHERE pk_person=@id;";

    //DataBase instance is obtained
    MySqlDataReader? mySqlReader;

    MySqlCommand mySqlCommand = new MySqlCommand(select);
    _conexionMySql.GetConnection().Close();
    mySqlCommand.Connection = _conexionMySql.GetConnection();
    

    //Parameters are added into SQLCommand Object
    mySqlCommand.Parameters.Add(new MySqlParameter("@id", personId));
    mySqlReader = await Task.Run(() => mySqlCommand.ExecuteReader());

    while (mySqlReader.Read()) 
    {
      return new Person
        (
        mySqlReader.GetString("fullname"), mySqlReader.GetString("phone_number"), mySqlReader.GetString("gender"), mySqlReader.GetString("nationality"), mySqlReader.GetString("email"), mySqlReader.GetInt16("age")
        );
    }

    return new Person("","","","","",0);
  }

  public Task<List<Person>> getPerson(CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}

