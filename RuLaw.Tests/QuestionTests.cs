using System;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Question"/>.</para>
  /// </summary>
  public sealed class QuestionTests : UnitTestsBase<Question>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new Question(), new { datez = DateTime.MinValue, kodvopr = 0, kodz = 0, nbegin = 0, nend = 0 });
      this.TestJson(
        new Question
        {
          Code = 1,
          Date = DateTime.MinValue,
          EndLine = 2,
          Name = "name",
          SessionCode = 1,
          StartLine = 1
        },
        new { datez = DateTime.MinValue, kodvopr = 1, kodz = 1, name = "name", nbegin = 1, nend = 2 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new Question(), "question", new { datez = DateTime.MinValue.ISO8601(), kodvopr = 0, kodz = 0, nbegin = 0, nend = 0 });
      this.TestXml(
        new Question
        {
          Code = 1,
          Date = DateTime.MinValue,
          EndLine = 2,
          Name = "name",
          SessionCode = 1,
          StartLine = 1
        },
        "question",
        new { datez = DateTime.MinValue.ISO8601(), kodvopr = 1, kodz = 1, name = "name", nbegin = 1, nend = 2 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Question()"/>
    [Fact]
    public void Constructors()
    {
      var question = new Question();
      Assert.Equal(0, question.Code);
      Assert.Equal(default(DateTime), question.Date);
      Assert.Equal(0, question.EndLine);
      Assert.Null(question.Name);
      Assert.Equal(0, question.SessionCode);
      Assert.Equal(0, question.StartLine);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Question.Code"/> property.</para>
    /// </summary>
    [Fact]
    public void Code_Property()
    {
      Assert.Equal(1, new Question { Code = 1 }.Code);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Question.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new Question { Date = DateTime.MinValue }.Date);
    }


    /// <summary>
    ///   <para>Performs testing of <see cref="Question.EndLine"/> property.</para>
    /// </summary>
    [Fact]
    public void EndLine_Property()
    {
      Assert.Equal(1, new Question { EndLine = 1 }.EndLine);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Question.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new Question { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Question.SessionCode"/> property.</para>
    /// </summary>
    [Fact]
    public void SessionCode_Property()
    {
      Assert.Equal(1, new Question { SessionCode = 1 }.SessionCode);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Question.StartLine"/> property.</para>
    /// </summary>
    [Fact]
    public void StartLine_Property()
    {
      Assert.Equal(1, new Question { StartLine = 1 }.StartLine);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Question.CompareTo(Question)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Question.Equals(Question)"/></description></item>
    ///     <item><description><see cref="Question.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Code", 1, 2);
      this.TestEquality("SessionCode", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Question.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Code", 1, 2);
      this.TestHashCode("SessionCode", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Question.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Question { Name = "name" }.ToString());
    }
  }
}