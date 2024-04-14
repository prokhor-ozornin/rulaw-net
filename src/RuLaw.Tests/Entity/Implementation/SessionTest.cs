using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Session"/>.</para>
/// </summary>
public sealed class SessionTest : ClassTest<Session>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Session()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Session).Should().BeDerivedFrom<object>().And.Implement<ISession>();

    var session = new Session();
    session.Id.Should().BeNull();
    session.Name.Should().BeNull();
    session.FromDate.Should().BeNull();
    session.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Session { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Session { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void From_Property()
  {
    new Session { FromDate = DateTimeOffset.MaxValue }.FromDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Session.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property()
  {
    new Session { ToDate = DateTimeOffset.MaxValue }.ToDate.Should().Be(DateTimeOffset.MaxValue);
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
  public void ToString_Method()
  {
    new Session {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Session
      {
        Id = 1,
        Name = "name",
        FromDate = DateTimeOffset.MinValue,
        ToDate = DateTimeOffset.MaxValue
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}