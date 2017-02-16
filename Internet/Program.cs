using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

class Program
{
	static void Main(string[] args)
	{
		GetHtml();

		Console.ReadKey(true);		
	}

	private static async void GetHtml()
	{
		HttpClient http = new HttpClient();
		string uri = "https://suqingfa.top";
		HttpResponseMessage response =await http.GetAsync(uri);
		if(response.IsSuccessStatusCode)
		{
			Console.WriteLine(response);

			Console.WriteLine();
			HttpContent content = response.Content;
			Console.WriteLine(await content.ReadAsStringAsync());
		}
	}
}
