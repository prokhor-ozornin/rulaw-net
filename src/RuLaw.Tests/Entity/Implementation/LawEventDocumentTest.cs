using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawEventDocument"/>.</para>
/// </summary>
public sealed class LawEventDocumentTest : ClassTest<LawEventDocument>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventDocument.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new LawEventDocument(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventDocument.Type"/> property.</para>
  /// </summary>
  [Fact]
  public void Type_Property() { new LawEventDocument(new {Type = Guid.Empty.ToString()}).Type.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawEventDocument(string?, string?)"/>
  /// <seealso cref="LawEventDocument(LawEventDocument.Info)"/>
  /// <seealso cref="LawEventDocument(object)"/>
  [Fact]
  public void Constructors()
  {
    var document = new LawEventDocument();
    document.Name.Should().BeNull();
    document.Type.Should().BeNull();

    document = new LawEventDocument(new LawEventDocument.Info());
    document.Name.Should().BeNull();
    document.Type.Should().BeNull();

    document = new LawEventDocument(new {});
    document.Name.Should().BeNull();
    document.Type.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventDocument.CompareTo(ILawEventDocument)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(LawEventDocument.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="LawEventDocument.Equals(ILawEventDocument)"/></description></item>
  ///     <item><description><see cref="LawEventDocument.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(LawEventDocument.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventDocument.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(LawEventDocument.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventDocument.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new LawEventDocument(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="LawEventDocument.Info"/>.</para>
/// </summary>
public sealed class LawEventDocumentInfoTests : ClassTest<LawEventDocument.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventDocument.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new LawEventDocument.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventDocument.Info.Type"/> property.</para>
  /// </summary>
  [Fact]
  public void Type_Property() { new LawEventDocument.Info {Type = Guid.Empty.ToString()}.Type.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawEventDocument.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new LawEventDocument.Info();
    info.Name.Should().BeNull();
    info.Type.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventDocument.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new LawEventDocument.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<LawEventDocument>();
    result.Name.Should().BeNull();
    result.Type.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new LawEventDocument.Info
    {
      Name = "name",
      Type = "type"
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}