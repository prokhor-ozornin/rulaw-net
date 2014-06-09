using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IActiveExtensions"/>.</para>
  /// </summary>
  public sealed class IActiveExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IActiveExtensions.Active{ENTITY}(IQueryable{ENTITY})"/></description></item>
    ///     <item><description><see cref="IActiveExtensions.Active{ENTITY}(IEnumerable{ENTITY})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Active_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IActiveExtensions.Active<IActive>(null));

      Assert.False(Enumerable.Empty<IActive>().Active().Any());
      Assert.Equal(1, new[] { null, new ActiveEntity { Active = true }, null, new ActiveEntity { Active = false } }.Active().Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IActiveExtensions.Inactive{ENTITY}(IQueryable{ENTITY})"/></description></item>
    ///     <item><description><see cref="IActiveExtensions.Inactive{ENTITY}(IEnumerable{ENTITY})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Inactive_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IActiveExtensions.Inactive<IActive>(null));

      Assert.False(Enumerable.Empty<IActive>().Inactive().Any());
      Assert.Equal(1, new[] { null, new ActiveEntity { Active = true }, null, new ActiveEntity { Active = false } }.Inactive().Count());
    }

    private sealed class ActiveEntity : IActive
    {
      public bool Active { get; set; }
    }
  }
}