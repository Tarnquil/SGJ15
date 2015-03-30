using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class Sequence
{ 
	[XmlAttribute("number")]
	public string Number;

	[XmlAttribute("name")]
	public string Name;

	[XmlArray("dots")]
	[XmlArrayItem("dot")]
	public List<Dot> Dots = new List<Dot>();

	[XmlArray("bombs")]
	[XmlArrayItem("bomb")]
	public List<Bomb> Bombs = new List<Bomb>();
}