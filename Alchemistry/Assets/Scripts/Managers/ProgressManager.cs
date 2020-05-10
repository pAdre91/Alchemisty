using Auxiliary;

public class ProgressManager : IProgressManager
{
	public Data LoadProgress()
	{
		IReader<Data> elementsReader = new JsonHandler<Data>();
		return elementsReader.Read(Constants.progressFilePath);
	}

	public void SaveProgress(Data progressData)
	{
		IWriter<Data> elementsWriter = new JsonHandler<Data>();
		elementsWriter.Write(Constants.progressFilePath, progressData);
	}
}
