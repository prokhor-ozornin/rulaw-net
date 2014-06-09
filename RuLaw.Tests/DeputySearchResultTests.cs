using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputySearchResult"/>.</para>
  /// </summary>
  public sealed class DeputySearchResultTests : UnitTestsBase<DeputySearchResult>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Deputy");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DeputySearchResult()"/>
    [Fact]
    public void Constructors()
    {
      var result = new DeputySearchResult();
      Assert.Null(result.Deputy);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputySearchResult.Deputy"/> property.</para>
    /// </summary>
    [Fact]
    public void Deputy_Property()
    {
      var deputy = new DeputyInfo();
      Assert.True(ReferenceEquals(deputy, new DeputySearchResult { Deputy = deputy }.Deputy));
    }
  }
}