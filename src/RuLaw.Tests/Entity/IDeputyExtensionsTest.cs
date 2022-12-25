using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDeputyExtensions"/>.</para>
/// </summary>
public sealed class IDeputyExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IDeputyExtensions.Position(IDeputy)"/></description></item>
  ///     <item><description><see cref="IDeputyExtensions.Position{TEntity}(IEnumerable{TEntity}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Position_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyExtensions.Position(null!)).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => new Deputy(new { Position = "position" }).Position()).ThrowExactly<InvalidOperationException>();

      new Deputy().Position().Should().BeNull();
      new Deputy(new {Position = "Депутат ГД"}).Position().Should().NotBeNull().And.Be(DeputyPosition.DumaDeputy);
      new Deputy(new {Position = "Член СФ"}).Position().Should().NotBeNull().And.Be(DeputyPosition.FederationCouncilMember);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyExtensions.Position<IDeputy>(null!, "position")).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Enumerable.Empty<IDeputy>().Position(null)).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Enumerable.Empty<IDeputy>().Position(string.Empty)).ThrowExactly<ArgumentException>();

      Enumerable.Empty<IDeputy>().Position("position").Should().NotBeNull().And.BeEmpty();
      var first = new Deputy(new {Position = "First"});
      var second = new Deputy(new {Position = "Second"});
      var deputies = new[] { null, first, second };
      deputies.Position("first").Should().NotBeNullOrEmpty().And.Equal(first);
    }
  }
}