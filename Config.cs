using System.Xml.Serialization;

namespace PowerDisplay
{
    [XmlRoot(ElementName = "Config")]
    public class Config
    {
        [XmlElement(ElementName = "DisplayOnInspect")]
        public bool DisplayOnInspect { get; set; }
    }
}