namespace RuLaw
{
  using System.IO;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using RestSharp;
  using RestSharp.Deserializers;

  internal sealed class RuLawXmlDeserializer : IDeserializer
  {
    public T Deserialize<T>(IRestResponse response)
    {
      var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("result"));
      using (var source = new StringReader(response.Content))
      {
        return serializer.Deserialize(source).To<T>();
      }
    }

    public string RootElement { get; set; }

    public string Namespace { get; set; }
    
    public string DateFormat { get; set; }
  }
}