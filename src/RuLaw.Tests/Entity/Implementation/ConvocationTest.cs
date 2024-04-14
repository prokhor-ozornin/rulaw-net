using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Convocation"/>.</para>
/// </summary>
public sealed class ConvocationTest : ClassTest<Convocation>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Convocation()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Convocation).Should().BeDerivedFrom<object>().And.Implement<IConvocation>();

    var convocation = new Convocation();
    convocation.Id.Should().BeNull();
    convocation.Name.Should().BeNull();
    convocation.FromDate.Should().BeNull();
    convocation.ToDate.Should().BeNull();
    convocation.Sessions.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Convocation { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Convocation { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property()
  {
    new Convocation { FromDate = DateTimeOffset.MaxValue }.FromDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Convocation.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property()
  {
    new Convocation { ToDate = DateTimeOffset.MaxValue }.ToDate.Should().Be(DateTimeOffset.MaxValue);
  }

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
  public void ToString_Method()
  {
    new Convocation {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Convocation
      {
        Id = 1,
        FromDate = DateTimeOffset.MinValue,
        Name = "name",
        Sessions = new List<Session> { new() { Id = 2 } },
        ToDate = DateTimeOffset.MaxValue
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}