using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore.Storage;
using MySql.Data.MySqlClient;

namespace Clean.Architecture.Infrastructure.Data;
internal class ConexionMySQL :Conexion
{
  private MySqlConnection connection;
  private string cadenaConexion;
  public ConexionMySQL() 
  {
    cadenaConexion = "Database=" + database +
      "; DataSource=" + server +
      "; User Id=" + user +
      "; Password=" + password;

      connection = new MySqlConnection(cadenaConexion);
  }

  public MySqlConnection GetConnection()
  {
    try
    {
      if (connection.State != System.Data.ConnectionState.Open) 
      {
        connection.Open();
      }

    }
    catch(System.Exception e) 
    {
      Console.WriteLine(e.ToString());
    }
    return connection;
  }

}
