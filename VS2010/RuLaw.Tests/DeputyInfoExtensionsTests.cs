using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputyInfoExtensions"/>.</para>
  /// </summary>
  public sealed class DeputyInfoExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfoExtensions.BirthDate(IEnumerable{DeputyInfo}, DateTime?, DateTime?)"/> method.</para>
    /// </summary>
    [Fact]
    public void BirthDate_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyInfoExtensions.BirthDate(null));

      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<DeputyInfo>)null).BirthDate());

      Assert.False(Enumerable.Empty<DeputyInfo>().BirthDate().Any());

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
    ///   <para>Performs testing of <see cref="DeputyInfoExtensions.Degree(IEnumerable{DeputyInfo}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Degree_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyInfoExtensions.Degree(null, "degree"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<DeputyInfo>().Degree(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<DeputyInfo>().Degree(string.Empty));

      Assert.False(Enumerable.Empty<DeputyInfo>().Degree("degree").Any());

      var first = new DeputyInfo { Degrees = new List<string> { "FIRST", "SECOND" } };
      var second = new DeputyInfo { Degrees = new List<string> { "First", "Third" } };
      var deputies = new[] { null, first, second };
      Assert.True(deputies.Degree("first").SequenceEqual(new [] { first, second }));
      Assert.True(ReferenceEquals(first, deputies.Degree("second").Single()));
      Assert.True(ReferenceEquals(second, deputies.Degree("third").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfoExtensions.Faction(IEnumerable{DeputyInfo}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Faction_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyInfoExtensions.Faction(null, "faction"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<DeputyInfo>().Faction(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<DeputyInfo>().Faction(string.Empty));

      Assert.False(Enumerable.Empty<DeputyInfo>().Faction("faction").Any());

      var first = new DeputyInfo { FactionName = "FIRST" };
      var second = new DeputyInfo { FactionName =  "Second" };
      var deputies = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, deputies.Faction("first").Single()));
      Assert.True(ReferenceEquals(second, deputies.Faction("second").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfoExtensions.Name(IEnumerable{DeputyInfo}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Name_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyInfoExtensions.Name(null, "name"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<DeputyInfo>().Name(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<DeputyInfo>().Name(string.Empty));

      Assert.False(Enumerable.Empty<DeputyInfo>().Name("name").Any());

      var first = new DeputyInfo { FirstName = "Vladimir", LastName = "Putin" };
      var second = new DeputyInfo { FirstName = "Dmitry", LastName = "Medvedev" };
      var deputies = new[] { null, first, second };
      
      Assert.True(ReferenceEquals(first, deputies.Name("PUTIN").Single()));
      Assert.True(ReferenceEquals(first, deputies.Name("putin vladimir").Single()));
      Assert.True(ReferenceEquals(second, deputies.Name("MEDVEDEV").Single()));
      Assert.True(ReferenceEquals(second, deputies.Name("medvedev dmitry").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfoExtensions.Rank(IEnumerable{DeputyInfo}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Rank_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyInfoExtensions.Rank(null, "name"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<DeputyInfo>().Rank(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<DeputyInfo>().Rank(string.Empty));

      Assert.False(Enumerable.Empty<DeputyInfo>().Rank("rank").Any());

      var first = new DeputyInfo { Ranks = new List<string> { "FIRST", "SECOND" } };
      var second = new DeputyInfo { Ranks = new List<string> { "First", "Third" } };

      var deputies = new[] { null, first, second };
      Assert.True(deputies.Rank("first").SequenceEqual(new [] { first, second }));
      Assert.True(ReferenceEquals(first, deputies.Rank("second").Single()));
      Assert.True(ReferenceEquals(second, deputies.Rank("third").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfoExtensions.Region(IEnumerable{DeputyInfo}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Region_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyInfoExtensions.Region(null, "name"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<DeputyInfo>().Region(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<DeputyInfo>().Region(string.Empty));

      Assert.False(Enumerable.Empty<DeputyInfo>().Region("region").Any());

      var first = new DeputyInfo { Regions = new List<string> { "FIRST", "SECOND" } };
      var second = new DeputyInfo { Regions = new List<string> { "First", "Third" } };

      var deputies = new[] { null, first, second };
      Assert.True(deputies.Region("first").SequenceEqual(new [] { first, second }));
      Assert.True(ReferenceEquals(first, deputies.Region("second").Single()));
      Assert.True(ReferenceEquals(second, deputies.Region("third").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfoExtensions.WorkDate(IEnumerable{DeputyInfo}, DateTime?, DateTime?)"/> method.</para>
    /// </summary>
    [Fact]
    public void WorkDate_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyInfoExtensions.WorkDate(null));

      Assert.False(Enumerable.Empty<DeputyInfo>().WorkDate().Any());

      var date = new DateTime(2000, 1, 1);

      var first = new DeputyInfo { WorkStartDate = DateTime.MinValue };
      var second = new DeputyInfo { WorkStartDate = date };
      var third = new DeputyInfo { WorkStartDate = DateTime.MaxValue };
      var deputies = new[] { null, first, second, third  };
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