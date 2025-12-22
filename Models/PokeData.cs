
namespace BasicAvalonia.Models;

public class PokeData{
   int count{get;set;}
   string next{get;set;}
   string previous{get;set;}
   Pokemon [] results{get;set;}
}

public class Pokemon{
   string name{get;set;}
   string url{get;set;}
}
