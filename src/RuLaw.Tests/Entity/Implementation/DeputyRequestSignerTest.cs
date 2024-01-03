using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DeputyRequestSigner"/>.</para>
/// </summary>
public sealed class DeputyRequestSignerTest : ClassTest<DeputyRequestSigner>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestSigner.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new DeputyRequestSigner(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestSigner.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new DeputyRequestSigner(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyRequestSigner(long?, string?)"/>
  /// <seealso cref="DeputyRequestSigner(DeputyRequestSigner.Info)"/>
  /// <seealso cref="DeputyRequestSigner(object)"/>
  [Fact]
  public void Constructors()
  {
    var signer = new DeputyRequestSigner();
    signer.Id.Should().BeNull();
    signer.Name.Should().BeNull();

    signer = new DeputyRequestSigner(new DeputyRequestSigner.Info());
    signer.Id.Should().BeNull();
    signer.Name.Should().BeNull();

    signer = new DeputyRequestSigner(new {});
    signer.Id.Should().BeNull();
    signer.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestSigner.CompareTo(IDeputyRequestSigner)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(DeputyRequestSigner.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="DeputyRequestSigner.Equals(IDeputyRequestSigner)"/></description></item>
  ///     <item><description><see cref="DeputyRequestSigner.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(DeputyRequestSigner.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestSigner.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(DeputyRequestSigner.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestSigner.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new DeputyRequestSigner(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="DeputyRequestSigner.Info"/>.</para>
/// </summary>
public sealed class DeputyRequestSignerInfoTests : ClassTest<DeputyRequestSigner.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestSigner.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new DeputyRequestSigner.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestSigner.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new DeputyRequestSigner.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyRequestSigner.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new DeputyRequestSigner.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestSigner.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new DeputyRequestSigner.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<DeputyRequestSigner>();
    result.Id.Should().BeNull();
    result.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new DeputyRequestSigner.Info
    {
      Id = 1,
      Name = "name"
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}