using RestSharp;
using RestSharp.Deserializers;

namespace RuLaw
{
  internal sealed class RuLawXmlDeserializer : IDeserializer
  {
    public T Deserialize<T>(IRestResponse response)
    {
      return response.Content.XmlRuLawResult<T>();
    }

    public string RootElement { get; set; }

    public string Namespace { get; set; }
    
    public string DateFormat { get; set; }
  }
}