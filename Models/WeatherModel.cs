using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace WeatherApp.Models;

public class WeatherModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string City { get; set; }
    public string Description { get; set; }
    public double Temperature { get; set; }
    public int Humidity { get; set; }
    public float WindSpeed { get; set; }
    public DateTime FetchedAt { get; set; }
}