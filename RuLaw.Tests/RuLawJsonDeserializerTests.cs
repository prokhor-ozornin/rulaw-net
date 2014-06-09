using System;
using RestSharp;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="RuLawJsonDeserializer"/>.</para>
  /// </summary>
  public sealed class RuLawJsonDeserializerTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="RuLawJsonDeserializer()"/>
    [Fact]
    public void Constructors()
    {
      var deserializer = new RuLawJsonDeserializer();
      Assert.Null(deserializer.DateFormat);
      Assert.Null(deserializer.Namespace);
      Assert.Null(deserializer.RootElement);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawJsonDeserializer.Deserialize{T}(IRestResponse)"/> method.</para>
    /// </summary>
    [Fact]
    public void Deserialize_Method()
    {
      var subject = Guid.NewGuid();
      Assert.Equal(subject, new RuLawJsonDeserializer().Deserialize<Guid>(new RestResponse { Content = subject.Json() }));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawJsonDeserializer.RootElement"/> property.</para>
    /// </summary>
    [Fact]
    public void RootElement_Property()
    {
      Assert.Equal("rootElement", new RuLawJsonDeserializer { RootElement = "rootElement" }.RootElement);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawJsonDeserializer.Namespace"/> property.</para>
    /// </summary>
    [Fact]
    public void Namespace_Property()
    {
      Assert.Equal("namespace", new RuLawJsonDeserializer { Namespace = "namespace" }.Namespace);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawJsonDeserializer.DateFormat"/> property.</para>
    /// </summary>
    [Fact]
    public void DateFormat_Property()
    {
      Assert.Equal("dateFormat", new RuLawJsonDeserializer { DateFormat = "dateFormat" }.DateFormat);
    }
  }
}