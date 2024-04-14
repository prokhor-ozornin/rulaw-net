using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Question"/>.</para>
/// </summary>
public sealed class QuestionTest : ClassTest<Question>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Question()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Question).Should().BeDerivedFrom<object>().And.Implement<IQuestion>();

    var question = new Question();
    question.Name.Should().BeNull();
    question.Date.Should().BeNull();
    question.Code.Should().BeNull();
    question.SessionCode.Should().BeNull();
    question.StartLine.Should().BeNull();
    question.EndLine.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Question.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Question { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Question.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new Question { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Question.Code"/> property.</para>
  /// </summary>
  [Fact]
  public void Code_Property()
  {
    new Question { Code = int.MaxValue }.Code.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Question.SessionCode"/> property.</para>
  /// </summary>
  [Fact]
  public void SessionCode_Property()
  {
    new Question { SessionCode = int.MaxValue }.SessionCode.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Question.StartLine"/> property.</para>
  /// </summary>
  [Fact]
  public void StartLine_Property()
  {
    new Question { StartLine = int.MaxValue }.StartLine.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Question.EndLine"/> property.</para>
  /// </summary>
  [Fact]
  public void EndLine_Property()
  {
    new Question { EndLine = int.MaxValue }.EndLine.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Question.CompareTo(IQuestion)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Question.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Question.Equals(IQuestion)"/></description></item>
  ///     <item><description><see cref="Question.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Question.Code), 1, 2);
    TestEquality(nameof(Question.SessionCode), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Question.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Question.Code), 1, 2);
    TestHashCode(nameof(Question.SessionCode), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Question.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Question {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Question
      {
        Code = 1,
        Date = DateTimeOffset.MinValue,
        EndLine = 2,
        Name = "name",
        SessionCode = 1,
        StartLine = 1
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}