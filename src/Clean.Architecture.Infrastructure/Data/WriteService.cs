using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Azure;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Infrastructure.Data.Migrations;
using Clean.Architecture.UseCases.Contributors;
using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace Clean.Architecture.Infrastructure.Data;
public class WriteService : Clean.Architecture.Core.Interfaces.IWriteService<PersonWriteDAO>
{
  private ConexionMySQL _conexionMySql;

  public WriteService() {
    _conexionMySql = new ConexionMySQL();
  }


  public async Task<int> addPerson(PersonWriteDAO person, CancellationToken cancellationToken)
  {
    //Query string
    string insert = "INSERT INTO person(fullname, phone_number, gender, age, email, nationality) " +
     "VALUES(@nombre, @phone_number, @gender, @age, @email, @nationality)";
    //DataBase instance is obtained
    MySqlCommand mySqlCommand = new MySqlCommand(insert, connection: _conexionMySql.GetConnection());
    mySqlCommand.Parameters.Add(new MySqlParameter("@nombre", person.Name));
    if (person.PhoneNumber is not null)     
    { 
      mySqlCommand.Parameters.Add(new MySqlParameter("@phone_number", person.PhoneNumber)); 
    }
    //Parameters are added into SQLCommand Object
    mySqlCommand.Parameters.Add(new MySqlParameter("@gender", person.Gender));
    mySqlCommand.Parameters.Add(new MySqlParameter("@age", person.Age));
    mySqlCommand.Parameters.Add(new MySqlParameter("@email", person.Email));
    mySqlCommand.Parameters.Add(new MySqlParameter("@nationality", person.Nationality));
    return await Task.Run(() => mySqlCommand.ExecuteNonQuery());
  }

  public async Task<int> deletePerson(int personId, CancellationToken cancellationToken)
  {
    string delete = "DELETE FROM person WHERE pk_person=@id;";

    //DataBase instance is obtained
    MySqlCommand mySqlCommand = new MySqlCommand(delete, connection: _conexionMySql.GetConnection());

    //Parameters are added into SQLCommand Object
    mySqlCommand.Parameters.Add(new MySqlParameter("@id", personId));
    return await Task.Run(() => mySqlCommand.ExecuteNonQuery());
  }

  public async Task<int> updatePerson(int personId, PersonWriteDAO person, CancellationToken cancellationToken)
  {
    string update = "UPDATE person SET " +
                      "fullname=@nombre, " +
                      "phone_number=@phone_number," +
                      "gender = @gender," +
                      "age=@age," +
                      "email=@email," +
                      "nationality=@nationality " +
                    "WHERE pk_person=@id;";

    //DataBase instance is obtained
    MySqlCommand mySqlCommand = new MySqlCommand(update, connection: _conexionMySql.GetConnection());
    mySqlCommand.Parameters.Add(new MySqlParameter("@nombre", person.Name));
    if (person.PhoneNumber is not null)
    {
      mySqlCommand.Parameters.Add(new MySqlParameter("@phone_number", person.PhoneNumber));
    }

    //Parameters are added into SQLCommand Object
    mySqlCommand.Parameters.Add(new MySqlParameter("@gender", person.Gender));
    mySqlCommand.Parameters.Add(new MySqlParameter("@age", person.Age));
    mySqlCommand.Parameters.Add(new MySqlParameter("@email", person.Email));
    mySqlCommand.Parameters.Add(new MySqlParameter("@nationality", person.Nationality));
    mySqlCommand.Parameters.Add(new MySqlParameter("@id", personId));
    return await Task.Run(() => mySqlCommand.ExecuteNonQuery());
  }
}
