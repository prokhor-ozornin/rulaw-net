using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ILawEventExtensions"/>.</para>
/// </summary>
public sealed class ILawEventExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ILawEventExtensions.Solution{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Solution_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawEventExtensions.Solution<ILawEvent>(null, "solution")).ThrowExactly<ArgumentNullException>().WithParameterName("events");
      AssertionExtensions.Should(() => Enumerable.Empty<ILawEvent>().Solution(null)).ThrowExactly<ArgumentNullException>().WithParameterName("solution");
      AssertionExtensions.Should(() => Enumerable.Empty<ILawEvent>().Solution(string.Empty)).ThrowExactly<ArgumentException>().WithParameterName("solution");

      Enumerable.Empty<ILawEvent>().Solution("solution").Should().NotBeNull().And.BeEmpty();

      var first = new LawEvent(new {Solution = "FIRST"});
      var second = new LawEvent(new {Solution = "Second"});
      var events = first.ToSequence(second, null);
      events.Solution("first").Should().NotBeNullOrEmpty().And.Equal(first);
      events.Solution("second").Should().NotBeNullOrEmpty().And.Equal(second);
    }

    return;

    static void Validate()
    {

    }
  }
}