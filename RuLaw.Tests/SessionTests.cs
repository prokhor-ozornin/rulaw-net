using System;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Session"/>.</para>
  /// </summary>
  public sealed class SessionTests : UnitTestsBase<Session>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new Session(), new { id = 0, startDate = default(DateTime) });
      this.TestJson(
        new Session
        {
           Id = 1,
           Name = "name",
           FromDate = DateTime.MinValue,
           ToDate = DateTime.MaxValue
        },
        new { id = 1, endDate = DateTime.MaxValue, name = "name", startDate = DateTime.MinValue }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new Session(), "session", new { id = 0, startDate = default(DateTime).ISO8601() });
      this.TestXml(
        new Session
        {
          Id = 1,
          Name = "name",
          FromDate = DateTime.MinValue,
          ToDate = DateTime.MaxValue
        },
        "session",
        new { id = 1, endDate = DateTime.MaxValue.ISO8601(), name = "name", startDate = DateTime.MinValue.ISO8601() }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Session()"/>
    [Fact]
    public void Constructors()
    {
      var session = new Session();
      Assert.Equal(0, session.Id);
      Assert.Equal(default(DateTime), session.FromDate);
      Assert.Null(session.Name);
      Assert.Null(session.ToDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Session.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Session { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Session.FromDate"/> property.</para>
    /// </summary>
    [Fact]
    public void From_Property()
    {
      Assert.Equal(DateTime.MinValue, new Session { FromDate = DateTime.MinValue }.FromDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Session.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new Session { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Session.ToDate"/> property.</para>
    /// </summary>
    [Fact]
    public void ToDate_Property()
    {
      Assert.Equal(DateTime.MaxValue, new Session { ToDate = DateTime.MaxValue }.ToDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Session.CompareTo(Session)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("FromDate", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Session.Equals(Session)"/></description></item>
    ///     <item><description><see cref="Session.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Session.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Session.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Session { Name = "name" }.ToString());
    }
  }
}