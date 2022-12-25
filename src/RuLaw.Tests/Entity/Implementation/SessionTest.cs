using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Session"/>.</para>
/// </summary>
public sealed class SessionTest : UnitTest<Session>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Session.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Session(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Session(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void From_Property() { new Session(new {FromDate = DateTimeOffset.MaxValue}).FromDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property() { new Session(new {ToDate = DateTimeOffset.MaxValue}).ToDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Session(long?, string?, DateTimeOffset?, DateTimeOffset?)"/>
  /// <seealso cref="Session(Session.Info)"/>
  /// <seealso cref="Session(object)"/>
  [Fact]
  public void Constructors()
  {
    var session = new Session();
    session.Id.Should().BeNull();
    session.Name.Should().BeNull();
    session.FromDate.Should().BeNull();
    session.ToDate.Should().BeNull();

    session = new Session(new Session.Info());
    session.Id.Should().BeNull();
    session.Name.Should().BeNull();
    session.FromDate.Should().BeNull();
    session.ToDate.Should().BeNull();

    session = new Session(new {});
    session.Id.Should().BeNull();
    session.Name.Should().BeNull();
    session.FromDate.Should().BeNull();
    session.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.CompareTo(ISession)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Session.FromDate), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Session.Equals(ISession)"/></description></item>
  ///     <item><description><see cref="Session.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(Session.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(Session.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new Session(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="Session.Info"/>.</para>
/// </summary>
public sealed class SessionInfoTests : UnitTest<Session.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Session.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Session.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Session.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.Info.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void From_Property() { new Session.Info {FromDate = Guid.Empty.ToString()}.FromDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.Info.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property() { new Session.Info {ToDate = Guid.Empty.ToString()}.ToDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Session.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new Session.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
    info.FromDate.Should().BeNull();
    info.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.Info.Result()"/> method.</para>
  /// </summary>
  [Fact]
  public void Result_Method()
  {
    var result = new Session.Info().Result();
    result.Should().NotBeNull().And.BeOfType<Session>();
    result.Id.Should().BeNull();
    result.Name.Should().BeNull();
    result.FromDate.Should().BeNull();
    result.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new Session.Info
    {
      Id = 1,
      Name = "name",
      FromDate = DateTimeOffset.MinValue.AsString(),
      ToDate = DateTimeOffset.MaxValue.AsString()
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}