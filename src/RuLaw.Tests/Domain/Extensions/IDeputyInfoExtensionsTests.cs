using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IDeputyInfoExtensions"/>.</para>
  /// </summary>
  public sealed class IDeputyInfoExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IDeputyInfoExtensions.FullName(IDeputyInfo)"/> method.</description></item>
    ///     <item><description><see cref="IDeputyInfoExtensions.FullName{ENTITY}(IEnumerable{ENTITY}, string)"/> method.</description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void FullName_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputyInfoExtensions.FullName(null));
      Assert.Throws<ArgumentNullException>(() => IDeputyInfoExtensions.FullName<IDeputyInfo>(null, "name"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<IDeputyInfo>().FullName(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<IDeputyInfo>().FullName(string.Empty));

      Assert.Equal("LastName FirstName MiddleName", new DeputyInfo { FirstName = "FirstName", LastName = "LastName", MiddleName = "MiddleName" }.FullName());
      Assert.Equal("LastName FirstName", new DeputyInfo { FirstName = "FirstName", LastName = "LastName" }.FullName());

      Assert.Empty(Enumerable.Empty<IDeputyInfo>().FullName("name"));
      var first = new DeputyInfo { FirstName = "Vladimir", LastName = "Putin" };
      var second = new DeputyInfo { FirstName = "Dmitry", LastName = "Medvedev" };
      var deputies = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, deputies.FullName("PUTIN").Single()));
      Assert.True(ReferenceEquals(first, deputies.FullName("putin vladimir").Single()));
      Assert.True(ReferenceEquals(second, deputies.FullName("MEDVEDEV").Single()));
      Assert.True(ReferenceEquals(second, deputies.FullName("medvedev dmitry").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.BirthDate{ENTITY}(IEnumerable{ENTITY}, DateTime?, DateTime?)"/> method.</para>
    /// </summary>
    [Fact]
    public void BirthDate_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputyInfoExtensions.BirthDate<IDeputyInfo>(null));

      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<IDeputyInfo>) null).BirthDate());

      Assert.Empty(Enumerable.Empty<IDeputyInfo>().BirthDate());

      var date = new DateTime(2000, 1, 1);

      var first = new DeputyInfo { BirthDate = DateTime.MinValue };
      var second = new DeputyInfo { BirthDate = date };
      var third = new DeputyInfo { BirthDate = DateTime.MaxValue };

      var deputies = new[] { null, first, second, third };
      Assert.True(deputies.BirthDate(date).SequenceEqual(new[] { second, third }));
      Assert.True(deputies.BirthDate(null, date).SequenceEqual(new[] { first, second }));
      Assert.True(deputies.BirthDate(DateTime.MinValue, DateTime.MaxValue).SequenceEqual(new[] { first, second, third }));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Degree{ENTITY}(IEnumerable{ENTITY}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Degree_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputyInfoExtensions.Degree<IDeputyInfo>(null, "degree"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<IDeputyInfo>().Degree(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<IDeputyInfo>().Degree(string.Empty));

      Assert.Empty(Enumerable.Empty<IDeputyInfo>().Degree("degree"));

      var first = new DeputyInfo { DegreesOriginal = new List<string> { "FIRST", "SECOND" } };
      var second = new DeputyInfo { DegreesOriginal = new List<string> { "First", "Third" } };
      var deputies = new[] { null, first, second };
      Assert.True(deputies.Degree("first").SequenceEqual(new[] { first, second }));
      Assert.True(ReferenceEquals(first, deputies.Degree("second").Single()));
      Assert.True(ReferenceEquals(second, deputies.Degree("third").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Faction{ENTITY}(IEnumerable{ENTITY}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Faction_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputyInfoExtensions.Faction<IDeputyInfo>(null, "faction"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<IDeputyInfo>().Faction(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<IDeputyInfo>().Faction(string.Empty));

      Assert.Empty(Enumerable.Empty<IDeputyInfo>().Faction("faction"));

      var first = new DeputyInfo { FactionName = "FIRST" };
      var second = new DeputyInfo { FactionName = "Second" };
      var deputies = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, deputies.Faction("first").Single()));
      Assert.True(ReferenceEquals(second, deputies.Faction("second").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Rank{ENTITY}(IEnumerable{ENTITY}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Rank_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputyInfoExtensions.Rank<IDeputyInfo>(null, "name"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<IDeputyInfo>().Rank(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<IDeputyInfo>().Rank(string.Empty));

      Assert.Empty(Enumerable.Empty<IDeputyInfo>().Rank("rank"));

      var first = new DeputyInfo { RanksOriginal = new List<string> { "FIRST", "SECOND" } };
      var second = new DeputyInfo { RanksOriginal = new List<string> { "First", "Third" } };

      var deputies = new[] { null, first, second };
      Assert.True(deputies.Rank("first").SequenceEqual(new[] { first, second }));
      Assert.True(ReferenceEquals(first, deputies.Rank("second").Single()));
      Assert.True(ReferenceEquals(second, deputies.Rank("third").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Region{ENTITY}(IEnumerable{ENTITY}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Region_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputyInfoExtensions.Region<IDeputyInfo>(null, "name"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<IDeputyInfo>().Region(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<IDeputyInfo>().Region(string.Empty));

      Assert.Empty(Enumerable.Empty<IDeputyInfo>().Region("region"));

      var first = new DeputyInfo { RegionsOriginal = new List<string> { "FIRST", "SECOND" } };
      var second = new DeputyInfo { RegionsOriginal = new List<string> { "First", "Third" } };

      var deputies = new[] { null, first, second };
      Assert.True(deputies.Region("first").SequenceEqual(new[] { first, second }));
      Assert.True(ReferenceEquals(first, deputies.Region("second").Single()));
      Assert.True(ReferenceEquals(second, deputies.Region("third").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.WorkDate{ENTITY}(IEnumerable{ENTITY}, DateTime?, DateTime?)"/> method.</para>
    /// </summary>
    [Fact]
    public void WorkDate_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputyInfoExtensions.WorkDate<IDeputyInfo>(null));

      Assert.Empty(Enumerable.Empty<IDeputyInfo>().WorkDate());

      var date = new DateTime(2000, 1, 1);

      var first = new DeputyInfo { WorkStartDate = DateTime.MinValue };
      var second = new DeputyInfo { WorkStartDate = date };
      var third = new DeputyInfo { WorkStartDate = DateTime.MaxValue };
      var deputies = new[] { null, first, second, third };
      Assert.True(deputies.WorkDate(date).SequenceEqual(new[] { second, third }));
      Assert.True(deputies.WorkDate(null, date).SequenceEqual(new[] { first, second, third }));
      Assert.True(deputies.WorkDate(DateTime.MinValue, DateTime.MaxValue).SequenceEqual(new[] { first, second, third }));

      first = new DeputyInfo { WorkStartDate = DateTime.MinValue, WorkEndDate = DateTime.MaxValue };
      second = new DeputyInfo { WorkStartDate = date, WorkEndDate = date };
      third = new DeputyInfo { WorkStartDate = DateTime.MaxValue, WorkEndDate = DateTime.MaxValue };
      deputies = new[] { null, first, second, third };
      Assert.True(deputies.WorkDate(date).SequenceEqual(new[] { second, third }));
      Assert.True(ReferenceEquals(second, deputies.WorkDate(null, date).Single()));
      Assert.True(ReferenceEquals(second, deputies.WorkDate(date, date).Single()));
    }
  }
}