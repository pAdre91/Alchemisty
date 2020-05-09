using System.IO;
using UnityEngine;

public class JsonReader<T> : IReader<T>
{
	public T Read(string filePath)
	{
		using (StreamReader streamReader = new StreamReader(filePath))
		{
			string file = streamReader.ReadToEnd();
			return JsonUtility.FromJson<T>(file);
		}
	}
}
