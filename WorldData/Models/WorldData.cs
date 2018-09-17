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

    public World (int id, string country)
    {
      _id = id;
      _country = country;
    }
    public World (string country)
    {
      _country = country;
    }
    public void SetCountry(string country)
    {
      _country= country;
    }

    public string GetCountry()
    {
      return _country;
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
        string worldId = rdr.GetString(0);
        string countryName = rdr.GetString(1);
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
    public static List<World> FilterCountry(string order)
    {
      List<World> sortCountry = new List<World> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country ORDER BY name "+order+";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string worldId = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        World newWorld = new World(countryName);
        sortCountry.Add(newWorld);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return sortCountry;
    }
    public static List<World> FilterContinent(string continent)
    {
      List<World> sortContinent = new List<World> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country WHERE Continent IN ('"+continent+"');";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string worldId = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        World newWorld = new World(countryName);
        sortContinent.Add(newWorld);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return sortContinent;
    }
  }

  public class City
  {
    private string _city;
    private int _population;

    public City (string city, int population)
    {
      _city = city;
      _population = population;
    }
    public void SetCity (string city)
    {
      _city= city;
    }
    public void SetPopulation (int population)
    {
      _population = population;
    }
    public string GetCity()
    {
      return _city;
    }
    public int GetPopulation()
    {
      return _population;
    }
    public static List<City> GetAllCities()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string cityName = rdr.GetString(1);
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityName, cityPopulation);
        allCities.Add(newCity);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
  }
}
