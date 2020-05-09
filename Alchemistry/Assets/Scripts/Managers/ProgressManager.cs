using Auxiliary;

public class ProgressManager : IProgressManager
{
	private IReader<Data> elementsReader = new JsonReader<Data>();

	public Data LoadProgress()
	{
		return elementsReader.Read(Constants.progressFilePath);
	}

	public void SaveProgress()
	{
		throw new System.NotImplementedException();
	}
}
