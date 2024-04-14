using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDeputyExtensions"/>.</para>
/// </summary>
public sealed class IDeputyExtensionsTest : UnitTest
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
      AssertionExtensions.Should(() => IDeputyExtensions.Position(null)).ThrowExactly<ArgumentNullException>().WithParameterName("deputy");
      AssertionExtensions.Should(() => new Deputy { Position = "position" }.Position()).ThrowExactly<InvalidOperationException>();

      new Deputy().Position().Should().BeNull();
      new Deputy {Position = "Депутат ГД"}.Position().Should().NotBeNull().And.Be(DeputyPosition.DumaDeputy);
      new Deputy {Position = "Член СФ"}.Position().Should().NotBeNull().And.Be(DeputyPosition.FederationCouncilMember);

      static void Validate()
      {

      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyExtensions.Position<IDeputy>(null, "position")).ThrowExactly<ArgumentNullException>().WithParameterName("deputies");
      AssertionExtensions.Should(() => Enumerable.Empty<IDeputy>().Position(null)).ThrowExactly<ArgumentNullException>().WithParameterName("position");
      AssertionExtensions.Should(() => Enumerable.Empty<IDeputy>().Position(string.Empty)).ThrowExactly<ArgumentException>().WithParameterName("position");

      Enumerable.Empty<IDeputy>().Position("position").Should().NotBeNull().And.BeEmpty();
      var first = new Deputy {Position = "First"};
      var second = new Deputy {Position = "Second"};
      var deputies = first.ToSequence(second, null);
      deputies.Position("first").Should().NotBeNullOrEmpty().And.Equal(first);

      static void Validate()
      {

      }
    }
  }
}