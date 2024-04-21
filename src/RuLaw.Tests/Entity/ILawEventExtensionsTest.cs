using Catharsis.Commons;
using FluentAssertions;
using Xunit;
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

      Validate([], [], null);
      Validate([], [], "solution");

      var first = new LawEvent { Solution = "first" };
      var second = new LawEvent { Solution = "second" };
      Validate([], [null], null);
      Validate([first], [null, first, second, null], first.Solution);
    }

    return;

    static void Validate(IEnumerable<ILawEvent> result, IEnumerable<ILawEvent> events, string solution) => events.Solution(solution).Should().BeAssignableTo<IEnumerable<ILawEvent>>().And.Equal(result);
  }
}