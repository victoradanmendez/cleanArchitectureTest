using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.Interfaces;
using Google.Protobuf.Compiler;
using Microsoft.Data.SqlClient;
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

  public async Task<PersonWriteDAO> getPerson(int personId, CancellationToken cancellationToken)
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
      return new PersonWriteDAO
        (
        mySqlReader.GetString("fullname"), mySqlReader.GetString("phone_number"), mySqlReader.GetString("gender"),
        mySqlReader.GetString("nationality"), mySqlReader.GetString("email"), mySqlReader.GetInt16("age")
        );
    }

    return new PersonWriteDAO("","","","","",0);
  }

  public async Task<List<PersonReadDAO>> getListPersons(CancellationToken cancellationToken)
  {
    string select = "select * FROM person ";

    //DataBase instance is obtained
    MySqlDataReader? mySqlReader;

    MySqlCommand mySqlCommand = new MySqlCommand(select);
    _conexionMySql.GetConnection().Close();
    mySqlCommand.Connection = _conexionMySql.GetConnection();


    //Parameters are added into SQLCommand Object
    //mySqlCommand.Parameters.Add(new MySqlParameter("@id", personId));
    mySqlReader = await Task.Run(() => mySqlCommand.ExecuteReader());
    List<PersonReadDAO> listPerson = new List<PersonReadDAO>();
    while (mySqlReader.Read())
    {
      PersonReadDAO person = new PersonReadDAO(mySqlReader.GetString("fullname"), mySqlReader.GetString("phone_number"), 
        mySqlReader.GetString("gender"), mySqlReader.GetString("nationality"), mySqlReader.GetString("email"), mySqlReader.GetInt32("age"), mySqlReader.GetInt32("pk_person"));
      listPerson.Add(person);
    }

    return listPerson;
  }

}


