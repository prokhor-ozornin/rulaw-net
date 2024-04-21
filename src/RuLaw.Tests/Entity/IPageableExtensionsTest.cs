using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IPageableExtensions"/>.</para>
/// </summary>
public sealed class IPageableExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IPageableExtensions.Page{TEntity}(IEnumerable{TEntity}, int?, int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IPageableExtensions.Page<IPageable>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("entities");

      Validate([], []);

      var page = 0;

      var first = new PageableEntity { Page = int.MinValue };
      var second = new PageableEntity { Page = 0 };
      var third = new PageableEntity { Page = int.MaxValue };
      var entities = new List<IPageable> { null, first, second, third, null };

      Validate([second, third], entities, page);
      Validate([first, second], entities, null, page);
      Validate([first, second, third], entities, int.MinValue, int.MaxValue);
    }

    return;

    static void Validate(IEnumerable<IPageable> result, IEnumerable<IPageable> sequence, int? from = null, int? to = null) => sequence.Page(from, to).Should().BeAssignableTo<IEnumerable<IPageable>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IPageableExtensions.Page{TEntity}(IEnumerable{TEntity}, int?, int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PageSize_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ((IEnumerable<PageableEntity>) null).Page(0)).ThrowExactly<ArgumentNullException>().WithParameterName("entities");

      Validate([], []);

      var size = 0;

      var first = new PageableEntity { PageSize = int.MinValue };
      var second = new PageableEntity { PageSize = 0 };
      var third = new PageableEntity { PageSize = int.MaxValue };
      var entities = new List<IPageable> { null, first, second, third, null };

      Validate([second, third], entities, size);
      Validate([first, second], entities, null, size);
      Validate([first, second, third], entities, int.MinValue, int.MaxValue);
    }

    return;

    static void Validate(IEnumerable<IPageable> result, IEnumerable<IPageable> sequence, int? from = null, int? to = null) => sequence.PageSize(from, to).Should().BeAssignableTo<IEnumerable<IPageable>>().And.Equal(result);
  }

  private sealed class PageableEntity : IPageable
  {
    public int? Page { get; init; }

    public int? PageSize { get; init; }
  }
}