using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="QuestionsSearchResult"/>.</para>
/// </summary>
public sealed class QuestionsSearchResultTest : ClassTest<QuestionsSearchResult>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="QuestionsSearchResult()"/>
  [Fact]
  public void Constructors()
  {
    typeof(QuestionsSearchResult).Should().BeDerivedFrom<object>().And.Implement<IQuestionsSearchResult>();

    var result = new QuestionsSearchResult();
    result.Page.Should().BeNull();
    result.PageSize.Should().BeNull();
    result.Count.Should().BeNull();
    result.Questions.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property()
  {
    new QuestionsSearchResult { Page = int.MaxValue }.Page.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.PageSize"/> property.</para>
  /// </summary>
  [Fact]
  public void PageSize_Property()
  {
    new QuestionsSearchResult { PageSize = int.MaxValue }.PageSize.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property()
  {
    new QuestionsSearchResult { Count = int.MaxValue }.Count.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.Questions"/> property.</para>
  /// </summary>
  [Fact]
  public void Questions_Property()
  {
    var result = new QuestionsSearchResult();
    var question = new Question();

    var questions = result.Questions.To<List<Question>>();
    questions.Add(question);
    result.Questions.Should().ContainSingle().Which.Should().BeSameAs(question);

    questions.Remove(question);
    result.Questions.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.CompareTo(ILawsSearchResult)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(LawsSearchResult.Count), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new QuestionsSearchResult
      {
        Count = 1,
        Page = 2,
        PageSize = 3,
        Questions = [new Question()]
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}