using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ILawExtensions"/>.</para>
/// </summary>
/// <seealso cref="ILawExtensions"/>
public sealed class ILawExtensionsTest : Test
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

      Test(null, [], null);
      Test(null, [], "solution");

      var first = new Law { Number = "first" };
      var second = new Law { Number = "second" };
      Test(null, [null], null);
      Test(first, [null, first, second, null], first.Number);
    }
    
    return;

    static void Test(ILaw result, IEnumerable<ILaw> laws, string number)
    {
      var law = laws.Number(number);

      law?.Should().BeOfType<Law>().And.BeSameAs(result);
    }
  }
}