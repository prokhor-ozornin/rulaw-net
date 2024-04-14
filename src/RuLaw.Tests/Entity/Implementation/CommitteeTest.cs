﻿using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Committee"/>.</para>
/// </summary>
public sealed class CommitteeTest : ClassTest<Committee>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Committee()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Committee).Should().BeDerivedFrom<object>().And.Implement<ICommittee>();

    var committee = new Committee();
    committee.Id.Should().BeNull();
    committee.Name.Should().BeNull();
    committee.Active.Should().BeNull();
    committee.FromDate.Should().BeNull();
    committee.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Committee { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Committee { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property()
  {
    new Committee { Active = true }.Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property()
  {
    new Committee { FromDate = DateTimeOffset.MaxValue }.FromDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property()
  {
    new Committee { ToDate = DateTimeOffset.MaxValue }.ToDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.CompareTo(ICommittee)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Committee.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Committee.Equals(ICommittee)"/></description></item>
  ///     <item><description><see cref="Committee.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(Committee.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(Committee.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Committee {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Committee
      {
        Id = 1,
        Active = true,
        FromDate = DateTimeOffset.MinValue,
        Name = "name",
        ToDate = DateTimeOffset.MaxValue
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}