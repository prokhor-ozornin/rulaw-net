using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDeputyInfoExtensions"/>.</para>
/// </summary>
public sealed class IDeputyInfoExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.FullName{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void FullName_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyInfoExtensions.FullName<IDeputyInfo>(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("deputies");

      Validate([], [], null);
      Validate([], [], "name");

      IDeputyInfo first = new DeputyInfo { FirstName = "Vladimir", LastName = "Putin" };
      IDeputyInfo second = new DeputyInfo { FirstName = "Dmitry", LastName = "Medvedev" };

      Validate([], [null], null);
      Validate([first], [null, first, second, null], first.FullName);
    }

    return;

    static void Validate(IEnumerable<IDeputyInfo> result, IEnumerable<IDeputyInfo> deputies, string name) => deputies.FullName(name).Should().BeAssignableTo<IEnumerable<IDeputyInfo>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.BirthDate{TEntity}(IEnumerable{TEntity}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void BirthDate_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyInfoExtensions.BirthDate<IDeputyInfo>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("deputies");

      Validate([], []);

      var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

      var first = new DeputyInfo { BirthDate = DateTimeOffset.MinValue };
      var second = new DeputyInfo { BirthDate = date };
      var third = new DeputyInfo { BirthDate = DateTimeOffset.MaxValue} ;
      var deputies = new List<IDeputyInfo> { null, first, second, third, null };

      Validate([first, second], deputies, date);
      Validate([first, second], deputies, null, date);
      Validate([first, second, third], deputies, DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    }

    return;

    static void Validate(IEnumerable<IDeputyInfo> result, IEnumerable<IDeputyInfo> deputies, DateTimeOffset? from = null, DateTimeOffset? to = null) => deputies.BirthDate(from, to).Should().BeAssignableTo<IEnumerable<IDeputyInfo>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.WorkDate{TEntity}(IEnumerable{TEntity}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void WorkDate_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyInfoExtensions.WorkDate<IDeputyInfo>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("deputies");

      Validate([], []);

      var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

      var first = new DeputyInfo { WorkStartDate = DateTimeOffset.MinValue };
      var second = new DeputyInfo { WorkStartDate = date };
      var third = new DeputyInfo { WorkStartDate = DateTimeOffset.MaxValue };
      var deputies = new List<IDeputyInfo> { null, first, second, third, null };
      Validate([first, second], deputies, date);
      Validate([first, second, third], deputies, null, date);
      Validate([first, second, third], deputies, DateTimeOffset.MinValue, DateTimeOffset.MaxValue);

      first = new DeputyInfo { WorkStartDate = DateTimeOffset.MinValue, WorkEndDate = DateTimeOffset.MaxValue };
      second = new DeputyInfo { WorkStartDate = date, WorkEndDate = date };
      third = new DeputyInfo { WorkStartDate = DateTimeOffset.MaxValue, WorkEndDate = DateTimeOffset.MaxValue };
      deputies = [null, first, second, third, null];
      Validate([second, third], deputies, date);
      Validate([second], deputies, null, date);
      Validate([second], deputies, date, date);
    }

    return;

    static void Validate(IEnumerable<IDeputyInfo> result, IEnumerable<IDeputyInfo> deputies, DateTimeOffset? from = null, DateTimeOffset? to = null) => deputies.WorkDate(from, to).Should().BeAssignableTo<IEnumerable<IDeputyInfo>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Faction{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Faction_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyInfoExtensions.Faction<IDeputyInfo>(null, "faction")).ThrowExactly<ArgumentNullException>().WithParameterName("deputies");

      Validate([], [], null);
      Validate([], [], "faction");

      var first = new DeputyInfo { FactionName = "first" };
      var second = new DeputyInfo { FactionName = "second" };

      Validate([], [null], null);
      Validate([first], [null, first, second, null], first.FactionName);
    }

    return;

    static void Validate(IEnumerable<IDeputyInfo> result, IEnumerable<IDeputyInfo> deputies, string faction) => deputies.Faction(faction).Should().BeAssignableTo<IEnumerable<IDeputyInfo>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Degree{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Degree_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyInfoExtensions.Degree<IDeputyInfo>(null, "degree")).ThrowExactly<ArgumentNullException>().WithParameterName("deputies");

      Validate([], [], null);
      Validate([], [], "degree");

      var first = new DeputyInfo { Degrees = ["first", "second"] };
      var second = new DeputyInfo { Degrees = ["first", "third"] };
      var deputies = new List<IDeputyInfo> { null, first, second, null };

      Validate([], [null], null);
      Validate([first, second], deputies, "first");
      Validate([first], deputies, "second");
      Validate([second], deputies, "third");
    }

    return;

    static void Validate(IEnumerable<IDeputyInfo> result, IEnumerable<IDeputyInfo> deputies, string degree) => deputies.Degree(degree).Should().BeAssignableTo<IEnumerable<IDeputyInfo>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Rank{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Rank_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyInfoExtensions.Rank<IDeputyInfo>(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("deputies");

      Validate([], [], null);
      Validate([], [], "rank");

      var first = new DeputyInfo { Ranks = ["first", "second"] };
      var second = new DeputyInfo { Ranks = ["first", "third"] };
      var deputies = new List<IDeputyInfo> { null, first, second, null };

      Validate([], [null], null);
      Validate([first, second], deputies, "first");
      Validate([first], deputies, "second");
      Validate([second], deputies, "third");
    }

    return;

    static void Validate(IEnumerable<IDeputyInfo> result, IEnumerable<IDeputyInfo> deputies, string rank) => deputies.Rank(rank).Should().BeAssignableTo<IEnumerable<IDeputyInfo>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.Region{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Region_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyInfoExtensions.Region<IDeputyInfo>(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("deputies");

      Validate([], [], null);
      Validate([], [], "region");

      var first = new DeputyInfo { Regions = ["first", "second"] };
      var second = new DeputyInfo { Regions = ["first", "third"] };
      var deputies = new List<IDeputyInfo> { null, first, second, null };

      Validate([], [null], null);
      Validate([first, second], deputies, "first");
      Validate([first], deputies, "second");
      Validate([second], deputies, "third");
    }

    return;

    static void Validate(IEnumerable<IDeputyInfo> result, IEnumerable<IDeputyInfo> deputies, string region) => deputies.Region(region).Should().BeAssignableTo<IEnumerable<IDeputyInfo>>().And.Equal(result);
  }
}