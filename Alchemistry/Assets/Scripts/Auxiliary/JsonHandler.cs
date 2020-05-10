using System.IO;
using UnityEngine;

public class JsonHandler<T> : IReader<T>, IWriter<T>
{
	public T Read(string filePath)
	{
		using (StreamReader streamReader = new StreamReader(filePath))
		{
			string file = streamReader.ReadToEnd();
			return JsonUtility.FromJson<T>(file);
		}
	}

	public void Write(string filePath, T info)
	{
		/*TODO
		 *Пишет все в одну строку, читается плохо
		 * Можно исправить через использование JsonConvert.SerializeObject
		 * Но с его подключением возникли проблемы из-за Unity. Надо позже разобраться.
		 */
		using (StreamWriter streamWriter = new StreamWriter(filePath))
		{
			string temp = JsonUtility.ToJson(info);
			streamWriter.Write(temp);
		}
	}
}
