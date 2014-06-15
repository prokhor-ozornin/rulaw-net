using RestSharp;
using RestSharp.Deserializers;

namespace RuLaw
{
  internal sealed class RuLawJsonDeserializer : IDeserializer
  {
    public T Deserialize<T>(IRestResponse response)
    {
      return response.Content.Json<T>();
    }

    public string RootElement { get; set; }

    public string Namespace { get; set; }
    
    public string DateFormat { get; set; }
  }
}