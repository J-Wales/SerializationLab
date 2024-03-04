using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationLab
{
	internal class Program
	{
		static void ReadFromFile(string file)
		{
			// Use StreamWriter to write a line in the file that says Hackathon
			using (StreamWriter writer = new StreamWriter(file))
			{
				writer.Write("Hackathon");
			}

			Console.WriteLine("In Word: Hackathon");

			// Use FileStream to find the first, middle, and last character in the string.
			using (FileStream stream = new FileStream(file, FileMode.Open))
			{
				stream.Seek(0, SeekOrigin.Begin);
				int firstChar = stream.ReadByte();

				stream.Seek(stream.Length / 2, SeekOrigin.Begin);
				int middleChar = stream.ReadByte();

				stream.Seek(-1, SeekOrigin.End);
				int lastChar = stream.ReadByte();

				Console.WriteLine($"The First Character is: \"{(char)firstChar}\"\nThe Middle Character is: \"{(char)middleChar}\"\nThe Last Character is: \"{(char)lastChar}\"");
			}
		}
		static void Main(string[] args)
		{
			// Create an instance of the Event class.
			Event newEvent = new Event { EventNumber = 1, Location = "Calgary" };

			string fileName = "event.json";
			string jsonString = JsonSerializer.Serialize(newEvent);
			File.WriteAllText(fileName, jsonString);

			jsonString = File.ReadAllText("event.json");
			Console.WriteLine($"Event Number: {JsonSerializer.Deserialize<Event>(jsonString).EventNumber}\nLocation: {JsonSerializer.Deserialize<Event>(jsonString).Location}");

			ReadFromFile(fileName);
		}
	}
}
