using System.Xml;
using System.Xml.Serialization;

public class Bomb 
{
	[XmlAttribute("number")]
	public string Number = "";
	
	[XmlAttribute("y")]
	public string Y = "";
	
	[XmlAttribute("x")]
	public string X = "";
}
