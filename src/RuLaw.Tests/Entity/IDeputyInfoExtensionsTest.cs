﻿using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDeputyInfoExtensions"/>.</para>
/// </summary>
public sealed class IDeputyInfoExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.FullName{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void FullName_Method()
  {
    AssertionExtensions.Should(() => IDeputyInfoExtensions.FullName<IDeputyInfo>(null!, "name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IDeputyInfo>().FullName(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IDeputyInfo>().FullName(string.Empty)).ThrowExactly<ArgumentException>();

    Enumerable.Empty<IDeputyInfo>().FullName("name").Should().NotBeNull().And.BeEmpty();
    var first = new DeputyInfo(new {FirstName = "Vladimir", LastName = "Putin"});
    var second = new DeputyInfo(new {FirstName = "Dmitry", LastName = "Medvedev"});
    var deputies = new[] {null, first, second};
    deputies.FullName("PUTIN").Should().NotBeNullOrEmpty().And.Equal(first);
    deputies.FullName("putin vladimir").Should().NotBeNullOrEmpty().And.Equal(first);
    deputies.FullName("MEDVEDEV").Should().NotBeNullOrEmpty().And.Equal(second);
    deputies.FullName("medvedev dmitry").Should().NotBeNullOrEmpty().And.Equal(second);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.BirthDate{TEntity}(IEnumerable{TEntity}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void BirthDate_Method()
  {
    AssertionExtensions.Should(() => IDeputyInfoExtensions.BirthDate<IDeputyInfo>(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => ((IEnumerable<IDeputyInfo>) null!).BirthDate()).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<IDeputyInfo>().BirthDate().Should().NotBeNull().And.BeEmpty();

    var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

    var first = new DeputyInfo(new {BirthDate = DateTimeOffset.MinValue});
    var second = new DeputyInfo(new {BirthDate = date});
    var third = new DeputyInfo(new {BirthDate = DateTimeOffset.MaxValue});

    var deputies = new[] {null, first, second, third};
    deputies.BirthDate(date).Should().NotBeNullOrEmpty().And.Equal(second, third);
    deputies.BirthDate(null, date).Should().NotBeNullOrEmpty().And.Equal(first, second);
    deputies.BirthDate(DateTimeOffset.MinValue, DateTimeOffset.MaxValue).Should().NotBeNullOrEmpty().And.Equal(first, second, third);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.WorkDate{TEntity}(IEnumerable{TEntity}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void WorkDate_Method()
  {
    AssertionExtensions.Should(() => IDeputyInfoExtensions.WorkDate<IDeputyInfo>(null!)).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<IDeputyInfo>().WorkDate().Should().NotBeNull().And.BeEmpty();

    var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

    var first = new DeputyInfo(new {WorkStartDate = DateTimeOffset.MinValue});
    var second = new DeputyInfo(new {WorkStartDate = date});
    var third = new DeputyInfo(new {WorkStartDate = DateTimeOffset.MaxValue});
    var deputies = new[] {null, first, second, third};
    deputies.WorkDate(date).Should().NotBeNullOrEmpty().And.Equal(second, third);
    deputies.WorkDate(null, date).Should().NotBeNullOrEmpty().And.Equal(first, second, third);
    deputies.WorkDate(DateTimeOffset.MinValue, DateTimeOffset.MaxValue).Should().NotBeNullOrEmpty().And.Equal(first, second, third);

    first = new DeputyInfo(new {WorkStartDate = DateTimeOffset.MinValue, WorkEndDate = DateTimeOffset.MaxValue});
    second = new DeputyInfo(new {WorkStartDate = date, WorkEndDate = date});
    third = new DeputyInfo(new {WorkStartDate = DateTimeOffset.MaxValue, WorkEndDate = DateTimeOffset.MaxValue});
    deputies = new[] {null, first, second, third};
    deputies.WorkDate(date).Should().NotBeNullOrEmpty().And.Equal(second, third);
    deputies.WorkDate(null, date).Should().NotBeNullOrEmpty().And.Equal(second);
    deputies.WorkDate(date, date).Should().NotBeNullOrEmpty().And.Equal(second);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Faction{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Faction_Method()
  {
    AssertionExtensions.Should(() => IDeputyInfoExtensions.Faction<IDeputyInfo>(null!, "faction")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IDeputyInfo>().Faction(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IDeputyInfo>().Faction(string.Empty)).Throw<ArgumentException>();

    Enumerable.Empty<IDeputyInfo>().Faction("faction").Should().NotBeNull().And.BeEmpty();

    var first = new DeputyInfo(new {FactionName = "FIRST"});
    var second = new DeputyInfo(new {FactionName = "Second"});
    var deputies = new[] {null, first, second};
    deputies.Faction("first").Should().NotBeNullOrEmpty().And.Equal(first);
    deputies.Faction("second").Should().NotBeNullOrEmpty().And.Equal(second);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Degree{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Degree_Method()
  {
    AssertionExtensions.Should(() => IDeputyInfoExtensions.Degree<IDeputyInfo>(null!, "degree")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IDeputyInfo>().Degree(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IDeputyInfo>().Degree(string.Empty)).ThrowExactly<ArgumentException>();

    Enumerable.Empty<IDeputyInfo>().Degree("degree").Should().NotBeNull().And.BeEmpty();

    var first = new DeputyInfo(new {DegreesOriginal = new List<string> {"FIRST", "SECOND"}});
    var second = new DeputyInfo(new {DegreesOriginal = new List<string> {"First", "Third"}});
    var deputies = new[] {null, first, second};
    deputies.Degree("first").Should().NotBeNullOrEmpty().And.Equal(first, second);
    deputies.Degree("second").Should().NotBeNullOrEmpty().And.Equal(first);
    deputies.Degree("third").Should().NotBeNullOrEmpty().And.Equal(second);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Rank{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Rank_Method()
  {
    AssertionExtensions.Should(() => IDeputyInfoExtensions.Rank<IDeputyInfo>(null!, "name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IDeputyInfo>().Rank(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IDeputyInfo>().Rank(string.Empty)).ThrowExactly<ArgumentException>();

    Enumerable.Empty<IDeputyInfo>().Rank("rank").Should().NotBeNull().And.BeEmpty();

    var first = new DeputyInfo(new {RanksOriginal = new List<string> {"FIRST", "SECOND"}});
    var second = new DeputyInfo(new {RanksOriginal = new List<string> {"First", "Third"}});

    var deputies = new[] {null, first, second};
    deputies.Rank("first").Should().NotBeNullOrEmpty().And.Equal(first, second);
    deputies.Rank("second").Should().NotBeNullOrEmpty().And.Equal(first);
    deputies.Rank("third").Should().NotBeNullOrEmpty().And.Equal(second);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Region{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Region_Method()
  {
    AssertionExtensions.Should(() => IDeputyInfoExtensions.Region<IDeputyInfo>(null!, "name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IDeputyInfo>().Region(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IDeputyInfo>().Region(string.Empty)).ThrowExactly<ArgumentException>();

    Enumerable.Empty<IDeputyInfo>().Region("region").Should().NotBeNull().And.BeEmpty();

    var first = new DeputyInfo(new {RegionsOriginal = new List<string> {"FIRST", "SECOND"}});
    var second = new DeputyInfo(new {RegionsOriginal = new List<string> {"First", "Third"}});

    var deputies = new[] {null, first, second};
    deputies.Region("first").Should().NotBeNullOrEmpty().And.Equal(first, second);
    deputies.Region("second").Should().NotBeNullOrEmpty().And.Equal(first);
    deputies.Region("third").Should().NotBeNullOrEmpty().And.Equal(second);
  }
}