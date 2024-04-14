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
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Authority()"/>
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
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Authority {Id = long.MaxValue}.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Authority {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property()
  {
    new Authority {Active = true}.Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property()
  {
    new Authority {FromDate = DateTimeOffset.MaxValue}.FromDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property()
  {
    new Authority {ToDate = DateTimeOffset.MaxValue}.ToDate.Should().Be(DateTimeOffset.MaxValue);
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
    using (new AssertionScope())
    {
      Validate(string.Empty, new Authority());
      Validate(string.Empty, new Authority { Name = string.Empty });
      //Validate("text", new Authority { Text = "text" });
    }

    return;

    static void Validate(string value, object instance) => instance.ToString().Should().Be(value);

    //new Authority(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Authority
      {
        Id = 1,
        Name = "name",
        Active = true,
        FromDate = DateTimeOffset.MinValue,
        ToDate = DateTimeOffset.MaxValue
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}