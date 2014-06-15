using System;
using Catharsis.Commons;
using RestSharp;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="RuLawXmlDeserializer"/>.</para>
  /// </summary>
  public sealed class RuLawXmlDeserializerTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="RuLawXmlDeserializer()"/>
    [Fact]
    public void Constructors()
    {
      var deserializer = new RuLawXmlDeserializer();
      Assert.Null(deserializer.DateFormat);
      Assert.Null(deserializer.Namespace);
      Assert.Null(deserializer.RootElement);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawXmlDeserializer.Deserialize{T}(IRestResponse)"/> method.</para>
    /// </summary>
    [Fact]
    public void Deserialize_Method()
    {
      object subject = "subject";
      Assert.Equal(subject, new RuLawXmlDeserializer().Deserialize<string>(new RestResponse { Content = @"<?xml version=""1.0""?><result>{0}</result>".FormatSelf(subject) }));

      subject = true;
      Assert.Equal(subject, new RuLawXmlDeserializer().Deserialize<bool>(new RestResponse { Content = @"<?xml version=""1.0""?><result>{0}</result>".FormatSelf(subject).ToLowerInvariant() }));

      subject = 15.5;
      Assert.Equal(subject, new RuLawXmlDeserializer().Deserialize<double>(new RestResponse { Content = @"<?xml version=""1.0""?><result>{0}</result>".FormatInvariant(subject) }));

      subject = Guid.NewGuid();
      Assert.Equal(subject, new RuLawXmlDeserializer().Deserialize<Guid>(new RestResponse { Content = @"<?xml version=""1.0""?><result>{0}</result>".FormatSelf(subject) }));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawXmlDeserializer.RootElement"/> property.</para>
    /// </summary>
    [Fact]
    public void RootElement_Property()
    {
      Assert.Equal("rootElement", new RuLawXmlDeserializer { RootElement = "rootElement" }.RootElement);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawXmlDeserializer.Namespace"/> property.</para>
    /// </summary>
    [Fact]
    public void Namespace_Property()
    {
      Assert.Equal("namespace", new RuLawXmlDeserializer { Namespace = "namespace" }.Namespace);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawXmlDeserializer.DateFormat"/> property.</para>
    /// </summary>
    [Fact]
    public void DateFormat_Property()
    {
      Assert.Equal("dateFormat", new RuLawXmlDeserializer { DateFormat = "dateFormat" }.DateFormat);
    }
  }
}