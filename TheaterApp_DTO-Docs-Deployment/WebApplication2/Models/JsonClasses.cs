using System.Collections.Generic;

namespace WebApplication2.Models
{
  
  //class Actors
  //{
  //  public List<string> names { get; set; }

  //}

  //class Director
  //{
  //  public string name { get; set; }

  //}

  class Geometry
  {
    public string Type { get; set; }
    public float[] Coordinates { get; set; }

  }
  class Properties
  {
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Borough { get; set; }
    public string Neighborhood { get; set; }

    public string County { get; set; }
    public string Zip { get; set; }
  }
  class Features
  {
    public string Type { get; set; }

    public Geometry Geometry { get; set; }

    public  Properties Properties { get; set; }
  }

  class FeaturesCollection
  {
    public string Type { get; set; }

    public List<Features> Features { get; set; }
  }

}
