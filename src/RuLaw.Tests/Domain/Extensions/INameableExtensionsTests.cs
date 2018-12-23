using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="INameableExtensions"/>.</para>
  /// </summary>
  public sealed class INameableExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="INameableExtensions.Name{T}(IQueryable{T}, string)"/></description></item>
    ///     <item><description><see cref="INameableExtensions.Name{T}(IEnumerable{T}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Name_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<NameableEntity>)null).Name("currency"));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<NameableEntity>)null).Name("currency"));

      Assert.Empty(Enumerable.Empty<NameableEntity>().AsQueryable().Name(null));
      Assert.Empty(Enumerable.Empty<NameableEntity>().Name(null));

      Assert.Equal(1, new[] { new NameableEntity { Name = "first" }, new NameableEntity { Name = "second" } }.AsQueryable().Name("first").Count());
      Assert.Single(new[] { null, new NameableEntity { Name = "first" }, null, new NameableEntity { Name = "second" } }.Name("first"));
    }

    private sealed class NameableEntity : INameable
    {
      public string Name { get; set; }
    }
  }
}