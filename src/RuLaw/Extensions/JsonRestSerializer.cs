using RestSharp.Serializers;
using RestSharp;

namespace RuLaw;

internal sealed class JsonRestSerializer : IRestSerializer, ISerializer, IDeserializer
{
  public string Serialize(object subject) => subject?.AsJson();

  public string Serialize(Parameter parameter) => Serialize(parameter.Value);

  public ContentType ContentType { get; set; }

  public T Deserialize<T>(RestResponse response) => response.Content is not null ? response.Content.AsJson<T>() : default;

  public ISerializer Serializer => this;

  public IDeserializer Deserializer => this;

  public string[] AcceptedContentTypes => ContentType.JsonAccept;

  public SupportsContentType SupportsContentType => contentType => contentType.Equals(ContentType.Json);

  public DataFormat DataFormat => DataFormat.Json;
}