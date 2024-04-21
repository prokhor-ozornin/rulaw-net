using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ILawExtensions"/>.</para>
/// </summary>
public sealed class ILawExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ILawExtensions.Number{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Number_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ((IEnumerable<ILaw>) null).Number("number")).ThrowExactly<ArgumentNullException>().WithParameterName("source");

      Validate(null, [], null);
      Validate(null, [], "solution");

      var first = new Law { Number = "first" };
      var second = new Law { Number = "second" };
      Validate(null, [null], null);
      Validate(first, [null, first, second, null], first.Number);
    }
    
    return;

    static void Validate(ILaw result, IEnumerable<ILaw> laws, string number)
    {
      var law = laws.Number(number);

      law?.Should().BeOfType<Law>().And.BeSameAs(result);
    }
  }
}