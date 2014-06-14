using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputyActivity"/>.</para>
  /// </summary>
  public sealed class DeputyActivityTests : UnitTestsBase<DeputyActivity>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new DeputyActivity(), new { subdivisionId = 0 });
      this.TestJson(
        new DeputyActivity
        {
          CommitteeId = 1,
          CommitteeNameGenitive = "committeeNameGenitive",
          Name = "name"
        },
        new { name = "name", subdivisionId = 1, subdivisionNameGenitive = "committeeNameGenitive" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new DeputyActivity(), "activity", new { subdivisionId = 0 });
      this.TestXml(
        new DeputyActivity
        {
          CommitteeId = 1,
          CommitteeNameGenitive = "committeeNameGenitive",
          Name = "name"
        },
        "activity",
        new { name = "name", subdivisionId = 1, subdivisionNameGenitive = "committeeNameGenitive" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DeputyActivity()"/>
    [Fact]
    public void Constructors()
    {
      var activity = new DeputyActivity();
      Assert.Null(activity.Name);
      Assert.Equal(0, activity.CommitteeId);
      Assert.Null(activity.CommitteeNameGenitive);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyActivity.CommitteeId"/> property.</para>
    /// </summary>
    [Fact]
    public void CommitteeId_Property()
    {
      Assert.Equal(1, new DeputyActivity { CommitteeId = 1 }.CommitteeId);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyActivity.CommitteeNameGenitive"/> property.</para>
    /// </summary>
    [Fact]
    public void CommitteeNameGenitive_Property()
    {
      Assert.Equal("name", new DeputyActivity { CommitteeNameGenitive = "name" }.CommitteeNameGenitive);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyActivity.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("institution", new Education { Institution = "institution" }.Institution);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyActivity.CompareTo(DeputyActivity)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="DeputyActivity.Equals(DeputyActivity)"/></description></item>
    ///     <item><description><see cref="DeputyActivity.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyActivity.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyActivity.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new DeputyActivity { Name = "name" }.ToString());
    }
  }
}