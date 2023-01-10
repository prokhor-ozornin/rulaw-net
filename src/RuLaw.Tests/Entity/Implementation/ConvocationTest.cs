using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Convocation"/>.</para>
/// </summary>
public sealed class ConvocationTest : EntityTest<Convocation>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Convocation(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Convocation(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property() { new Convocation(new {FromDate = DateTimeOffset.MaxValue}).FromDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property() { new Convocation(new {ToDate = DateTimeOffset.MaxValue}).ToDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.Sessions"/> property.</para>
  /// </summary>
  [Fact]
  public void Sessions_Property()
  {
    var convocation = new Convocation();
    var session = new Session();

    var sessions = convocation.Sessions.To<List<Session>>();
    sessions.Add(session);
    convocation.Sessions.Should().ContainSingle().Which.Should().BeSameAs(session);

    sessions.Remove(session);
    convocation.Sessions.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Convocation(long?, string?, DateTimeOffset?, DateTimeOffset?, IEnumerable{ISession}?)"/>
  /// <seealso cref="Convocation(Convocation.Info)"/>
  /// <seealso cref="Convocation(object)"/>
  [Fact]
  public void Constructors()
  {
    var convocation = new Convocation();
    convocation.Id.Should().BeNull();
    convocation.Name.Should().BeNull();
    convocation.FromDate.Should().BeNull();
    convocation.ToDate.Should().BeNull();
    convocation.Sessions.Should().BeEmpty();

    convocation = new Convocation(new Convocation.Info());
    convocation.Id.Should().BeNull();
    convocation.Name.Should().BeNull();
    convocation.FromDate.Should().BeNull();
    convocation.ToDate.Should().BeNull();
    convocation.Sessions.Should().BeEmpty();

    convocation = new Convocation();
    convocation.Id.Should().BeNull();
    convocation.Name.Should().BeNull();
    convocation.FromDate.Should().BeNull();
    convocation.ToDate.Should().BeNull();
    convocation.Sessions.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.CompareTo(IConvocation)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Convocation.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Convocation.Equals(IConvocation)"/></description></item>
  ///     <item><description><see cref="Convocation.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(Convocation.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(Convocation.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new Convocation(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="Convocation.Info"/>.</para>
/// </summary>
public sealed class ConvocationInfoTests : EntityTest<Convocation.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Convocation.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Convocation.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.Info.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property() { new Convocation.Info {FromDate = Guid.Empty.ToString()}.FromDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.Info.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property() { new Convocation.Info {ToDate = Guid.Empty.ToString()}.ToDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.Info.Sessions"/> property.</para>
  /// </summary>
  [Fact]
  public void Sessions_Property()
  {
    var sessions = new List<Session>();
    new Convocation.Info {Sessions = sessions}.Sessions.Should().BeSameAs(sessions);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Convocation.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new Convocation.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
    info.FromDate.Should().BeNull();
    info.ToDate.Should().BeNull();
    info.Sessions.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new Convocation.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<Convocation>();
    result.Id.Should().BeNull();
    result.Name.Should().BeNull();
    result.FromDate.Should().BeNull();
    result.ToDate.Should().BeNull();
    result.Sessions.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new Convocation.Info
    {
      Id = 1,
      FromDate = DateTimeOffset.MinValue.AsString(),
      Name = "name",
      Sessions = new List<Session> {new(new {Id = 2})},
      ToDate = DateTimeOffset.MaxValue.AsString()
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}