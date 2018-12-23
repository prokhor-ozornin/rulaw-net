using System.IO;
using System.Xml.Serialization;
using RestSharp.Serializers;
using XmlSerializer = System.Xml.Serialization.XmlSerializer;

namespace RuLaw
{
  internal sealed class RuLawXmlSerializer : IXmlSerializer
  {
    public string Serialize(object subject)
    {
      var serializer = new XmlSerializer(subject.GetType(), new XmlRootAttribute("result"));
      using (var destination = new StringWriter())
      {
        serializer.Serialize(destination, subject);
        return destination.ToString();
      }
    }

    public string RootElement { get; set; }

    public string Namespace { get; set; }

    public string DateFormat { get; set; }

    public string ContentType { get; set; }
  }
}