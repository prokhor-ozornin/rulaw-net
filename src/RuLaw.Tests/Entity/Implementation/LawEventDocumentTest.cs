using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawEventDocument"/>.</para>
/// </summary>
public sealed class LawEventDocumentTest : ClassTest<LawEventDocument>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawEventDocument()"/>
  [Fact]
  public void Constructors()
  {
    typeof(LawEventDocument).Should().BeDerivedFrom<object>().And.Implement<ILawEventDocument>();

    var document = new LawEventDocument();
    document.Name.Should().BeNull();
    document.Type.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventDocument.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new LawEventDocument { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventDocument.Type"/> property.</para>
  /// </summary>
  [Fact]
  public void Type_Property()
  {
    new LawEventDocument { Type = Guid.Empty.ToString() }.Type.Should().Be(Guid.Empty.ToString());
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
  public void ToString_Method()
  {
    new LawEventDocument {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new LawEventDocument
      {
        Name = "name",
        Type = "type"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}