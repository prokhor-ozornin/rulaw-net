using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ILawEventExtensions"/>.</para>
/// </summary>
public sealed class ILawEventExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ILawEventExtensions.Solution{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Solution_Method()
  {
    AssertionExtensions.Should(() => ILawEventExtensions.Solution<ILawEvent>(null!, "solution")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<ILawEvent>().Solution(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<ILawEvent>().Solution(string.Empty)).ThrowExactly<ArgumentException>();

    Enumerable.Empty<ILawEvent>().Solution("solution").Should().NotBeNull().And.BeEmpty();

    var first = new LawEvent(new {Solution = "FIRST"});
    var second = new LawEvent(new {Solution = "Second"});
    var events = new[] {null, first, second};
    events.Solution("first").Should().NotBeNullOrEmpty().And.Equal(first);
    events.Solution("second").Should().NotBeNullOrEmpty().And.Equal(second);
  }
}