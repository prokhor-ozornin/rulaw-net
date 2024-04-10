using System.Runtime.Serialization;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Authority"/>.</para>
/// </summary>
public sealed class AuthorityTest : ClassTest<Authority>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Authority(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Authority(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property() { new Authority(new {Active = true}).Active.Should().BeTrue(); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property() { new Authority(new {FromDate = DateTimeOffset.MaxValue}).FromDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property() { new Authority(new {ToDate = DateTimeOffset.MaxValue}).ToDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Authority(long?, string?, bool?, DateTimeOffset?, DateTimeOffset?)"/>
  /// <seealso cref="Authority(Authority.Info)"/>
  /// <seealso cref="Authority(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(Authority).Should().BeDerivedFrom<object>().And.Implement<IAuthority>();

    var authority = new Authority();
    authority.Id.Should().BeNull();
    authority.Name.Should().BeNull();
    authority.Active.Should().BeNull();
    authority.FromDate.Should().BeNull();
    authority.ToDate.Should().BeNull();

    authority = new Authority(new Authority.Info());
    authority.Id.Should().BeNull();
    authority.Name.Should().BeNull();
    authority.Active.Should().BeNull();
    authority.FromDate.Should().BeNull();
    authority.ToDate.Should().BeNull();

    authority = new Authority(new {});
    authority.Id.Should().BeNull();
    authority.Name.Should().BeNull();
    authority.Active.Should().BeNull();
    authority.FromDate.Should().BeNull();
    authority.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.CompareTo(IAuthority)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Authority.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Authority.Equals(IAuthority)"/></description></item>
  ///     <item><description><see cref="Authority.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(Authority.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(Authority.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Authority(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }
}

/// <summary>
///   <para>Tests set for class <see cref="Authority.Info"/>.</para>
/// </summary>
public sealed class AuthorityInfoTests : ClassTest<Authority.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Authority.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Authority.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Info.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property() { new Authority.Info {Active = true}.Active.Should().BeTrue(); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Info.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property() { new Authority.Info {FromDate = Guid.Empty.ToString()}.FromDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Info.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property() { new Authority.Info {ToDate = Guid.Empty.ToString()}.ToDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Authority.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Authority.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<IAuthority>>();

    var info = new Authority.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
    info.Active.Should().BeNull();
    info.FromDate.Should().BeNull();
    info.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new Authority.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<Authority>();
      result.Id.Should().BeNull();
      result.Name.Should().BeNull();
      result.Active.Should().BeNull();
      result.FromDate.Should().BeNull();
      result.ToDate.Should().BeNull();
    }

    return;

    static void Validate()
    {
      
    }
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Authority.Info
      {
        Id = 1,
        Name = "name",
        Active = true,
        FromDate = DateTimeOffset.MinValue.AsString(),
        ToDate = DateTimeOffset.MaxValue.AsString()
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}