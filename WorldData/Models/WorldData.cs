using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;
using System;

namespace WorldData.Models
{
  public class World
  {
    private int _id = 0;
    private string _country;
    private string _city;

    public World (int id, string country, string city)
    {
      _id = id;
      _country = country;
      _city = city;
    }
    public World (string country)
    {
      _country = country;
    }
    public void SetCountry(string country)
    {
      _country= country;
    }
    public void SetCity (string city)
    {
      _city= city;
    }
    public string GetCountry()
    {
      return _country;
    }
    public string GetCity()
    {
      return _city;
    }
    public static List<World> GetAll()
    {
      List<World> allItems = new List<World> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int worldId = rdr.GetInt32(0);
        string countryName = rdr.GetString(1);
        // string worldCity = rdr.GetString(1);
        World newWorld = new World(countryName);
        allItems.Add(newWorld);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }
  }
}
