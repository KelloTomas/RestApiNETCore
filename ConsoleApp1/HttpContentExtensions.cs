using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
	public static class HttpContentExtensions
	{
		public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
		{
			string json = await content.ReadAsStringAsync();
			T value = JsonConvert.DeserializeObject<T>(json);
			return value;
		}
		public static HttpContent ToHttpContent<T>(this T obj)
		{
			var str = JsonConvert.SerializeObject(obj);
			return new StringContent(str, Encoding.UTF8, "application/json");
		}
	}
}
