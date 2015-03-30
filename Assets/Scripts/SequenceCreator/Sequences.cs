using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("sequencesroot")]
public class Sequences
{
	private List<Sequence> sequences;
	[XmlArray("sequences")]
	[XmlArrayItem("sequence")]
	public List<Sequence> SequenceList {get{return sequences??(sequences=new List<Sequence>());}}

	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(Sequences));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	
	public static Sequences Load(string path)
	{
		var serializer = new XmlSerializer(typeof(Sequences));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as Sequences;
		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static Sequences LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(Sequences));
		return serializer.Deserialize(new StringReader(text)) as Sequences;
	}

}