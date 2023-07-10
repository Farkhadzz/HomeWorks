using Async__1.Classes;
using Newtonsoft.Json;

HttpClient client = new HttpClient();
string url = "https://catfact.ninja/fact";
var respone = await client.GetAsync(url);

var cont = await respone.Content.ReadAsStringAsync();
Cat CatFact = JsonConvert.DeserializeObject<Cat>(cont);

Console.WriteLine($"Fact About Cats : \n{CatFact.Fact}");

