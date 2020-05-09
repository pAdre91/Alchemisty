using System;

[Serializable]
public class Data
{
	public Element[] progress;
}

[Serializable]
public class Element
{
	public string name;
	public bool open;
}
