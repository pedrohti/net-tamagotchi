using RestSharp;
using System.Text.Json;
using Tamagotchi;

var client = new RestClient("https://pokeapi.co/api/v2/pokemon");
var request = new RestRequest("/1", Method.Get);
var response = client.Execute(request);

Pet pet = new();

if (response.StatusCode == System.Net.HttpStatusCode.OK)
{
	var mascote = JsonSerializer.Deserialize<Pet>(response.Content);
	Console.WriteLine("Nome do Pokemon: " + mascote?.name);
	Console.WriteLine("Altura: " + mascote?.height);
	Console.WriteLine("Peso: " + mascote?.weight);
	Console.WriteLine("Habilidades: ");
	foreach (var item in mascote?.abilities)
	{
		Console.WriteLine(item?.ability?.name?.ToUpper());
	}
	//Console.WriteLine(mascote?.Name);
}
else
{ Console.WriteLine(response.ErrorMessage); }

Console.ReadKey();