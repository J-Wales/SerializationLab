using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationLab
{
	internal class Program
	{
		public void ReadFromFile()
		{

		}
		static void Main(string[] args)
		{
			Event e = new Event();
			e.EventNumber = 1;
			e.Location = "Calgary";

			string fileName = "event.json";
			string j = JsonSerializer.Serialize(e);

			File.WriteAllText(fileName, j);
		}
	}
}
