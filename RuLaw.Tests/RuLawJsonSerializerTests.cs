using System;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Performs testing of <see cref="RuLawJsonSerializer"/>.</para>
  /// </summary>
  public sealed class RuLawJsonSerializerTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="RuLawJsonSerializer()"/>
    [Fact]
    public void Constructors()
    {
      var serializer = new RuLawJsonSerializer();
      Assert.Null(serializer.ContentType);
      Assert.Null(serializer.DateFormat);
      Assert.Null(serializer.Namespace);
      Assert.Null(serializer.RootElement);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawJsonSerializer.Serialize(object)"/> method.</para>
    /// </summary>
    [Fact]
    public void Serialize_Method()
    {
      var subject = Guid.NewGuid();
      Assert.Equal(subject.Json(), new RuLawJsonSerializer().Serialize(subject));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawJsonSerializer.RootElement"/> property.</para>
    /// </summary>
    [Fact]
    public void RootElement_Property()
    {
      Assert.Equal("rootElement", new RuLawJsonSerializer { RootElement = "rootElement" }.RootElement);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawJsonSerializer.Namespace"/> property.</para>
    /// </summary>
    [Fact]
    public void Namespace_Property()
    {
      Assert.Equal("namespace", new RuLawJsonSerializer { Namespace = "namespace" }.Namespace);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawJsonSerializer.DateFormat"/> property.</para>
    /// </summary>
    [Fact]
    public void DateFormat_Property()
    {
      Assert.Equal("dateFormat", new RuLawJsonSerializer { DateFormat = "dateFormat" }.DateFormat);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawJsonSerializer.ContentType"/> property.</para>
    /// </summary>
    [Fact]
    public void ContentType_Property()
    {
      Assert.Equal("contentType", new RuLawJsonSerializer { ContentType = "contentType" }.ContentType);
    }
  }
}