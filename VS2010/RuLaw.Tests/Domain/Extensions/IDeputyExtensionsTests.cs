using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IDeputyExtensions"/>.</para>
  /// </summary>
  public sealed class IDeputyExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IDeputyExtensions.Position(IDeputy)"/></description></item>
    ///     <item><description><see cref="IDeputyExtensions.Position{ENTITY}(IEnumerable{ENTITY}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Position_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputyExtensions.Position(null));
      Assert.Throws<ArgumentNullException>(() => IDeputyExtensions.Position<IDeputy>(null, "position"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<IDeputy>().Position(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<IDeputy>().Position(string.Empty));

      Assert.Null(new Deputy().Position());
      Assert.Throws<InvalidOperationException>(() => new Deputy { Position = "position" }.Position());
      Assert.Equal(DeputyPosition.DumaDeputy, new Deputy { Position = "Депутат ГД" }.Position());
      Assert.Equal(DeputyPosition.FederationCouncilMember, new Deputy { Position = "Член СФ" }.Position());

      Assert.False(Enumerable.Empty<IDeputy>().Position("position").Any());
      var first = new Deputy { Position = "First" };
      var second = new Deputy { Position = "Second" };
      var deputies = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, deputies.Position("first").Single()));
    }
  }
}