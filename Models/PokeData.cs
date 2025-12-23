
namespace BasicAvalonia.Models;

public class PokeData{
   public int count{get;set;}
   public string next{get;set;}
   public string previous{get;set;}
   public Pokemon [] results{get;set;}
}

public class Pokemon{
  public string Name{get;set;}
  public string Url{get;set;}
}
