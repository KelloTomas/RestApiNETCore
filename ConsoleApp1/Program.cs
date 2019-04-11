using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using be;
using Newtonsoft.Json;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			f().GetAwaiter().GetResult();
			//Task.Run((Action)(() => f()));
		}

		static async Task f()
		{
			System.Threading.Thread.Sleep(2000);
			var client = new HttpClient();
			//test get
			//var x = await client.GetAsync("http://localhost:43255/api/values");
			//Console.WriteLine($"{x}");
			//if (x.IsSuccessStatusCode)
			//{
			//	var content = await x.Content.ReadAsJsonAsync<string[]>();
			//	Console.WriteLine($"{string.Join(",", content)}");
			//}

			//test post
			var vl = new Vlak()
			{
				ID = 2,
				Cislo = 120,
				Nazov = "Kosican",
				Odchod = DateTime.Now
			};

			Console.WriteLine($"Odchod1: {vl.Odchod}");
/*			var jsobCom = JsonConvert.SerializeObject(vl);
			HttpContent httpContent = new StringContent(jsobCom, Encoding.UTF8, "application/json");*/
			var x = await client.PostAsync("http://localhost:43255/api/values", vl.ToHttpContent());
			Console.WriteLine($"{x}");
			if (x.IsSuccessStatusCode)
			{
				var content = await x.Content.ReadAsJsonAsync<Vlak>();
				Console.WriteLine($"Odchod2: {content.Odchod}");
			}
			else
			{
				Console.WriteLine("Error");
			}
			Console.ReadLine();
		}
	}
}
