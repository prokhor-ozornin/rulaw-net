using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="QuestionsSearchResult"/>.</para>
/// </summary>
public sealed class QuestionsSearchResultTest : ClassTest<QuestionsSearchResult>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property() { new QuestionsSearchResult(new {Page = int.MaxValue}).Page.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.PageSize"/> property.</para>
  /// </summary>
  [Fact]
  public void PageSize_Property() { new QuestionsSearchResult(new {PageSize = int.MaxValue}).PageSize.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property() { new QuestionsSearchResult(new {Count = int.MaxValue}).Count.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.Questions"/> property.</para>
  /// </summary>
  [Fact]
  public void Questions_Property()
  {
    var result = new QuestionsSearchResult(new {});
    var question = new Question(new {});

    var questions = result.Questions.To<List<Question>>();
    questions.Add(question);
    result.Questions.Should().ContainSingle().Which.Should().BeSameAs(question);

    questions.Remove(question);
    result.Questions.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="QuestionsSearchResult(int?, int?, int?, IEnumerable{IQuestion}?)"/>
  /// <seealso cref="QuestionsSearchResult(QuestionsSearchResult.Info)"/>
  /// <seealso cref="QuestionsSearchResult(object)"/>
  [Fact]
  public void Constructors()
  {
    var result = new QuestionsSearchResult();
    result.Page.Should().BeNull();
    result.PageSize.Should().BeNull();
    result.Count.Should().BeNull();
    result.Questions.Should().BeEmpty();

    result = new QuestionsSearchResult(new QuestionsSearchResult.Info());
    result.Page.Should().BeNull();
    result.PageSize.Should().BeNull();
    result.Count.Should().BeNull();
    result.Questions.Should().BeEmpty();

    result = new QuestionsSearchResult(new {});
    result.Page.Should().BeNull();
    result.PageSize.Should().BeNull();
    result.Count.Should().BeNull();
    result.Questions.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.CompareTo(ILawsSearchResult)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(LawsSearchResult.Count), 1, 2); }
}

/// <summary>
///   <para>Tests set for class <see cref="QuestionsSearchResult.Info"/>.</para>
/// </summary>
public sealed class QuestionsSearchResultInfoTests : ClassTest<QuestionsSearchResult.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.Info.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property() { new QuestionsSearchResult.Info {Page = int.MaxValue}.Page.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.Info.PageSize"/> property.</para>
  /// </summary>
  [Fact]
  public void PageSize_Property() { new QuestionsSearchResult.Info {PageSize = int.MaxValue}.PageSize.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.Info.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property() { new QuestionsSearchResult.Info {Count = int.MaxValue}.Count.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsSearchResult.Info.Questions"/> property.</para>
  /// </summary>
  [Fact]
  public void Questions_Property()
  {
    var questions = new List<Question>();
    new QuestionsSearchResult.Info {Questions = questions}.Questions.Should().BeSameAs(questions);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="QuestionsSearchResult.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new QuestionsSearchResult.Info();
    info.Page.Should().BeNull();
    info.PageSize.Should().BeNull();
    info.Count.Should().BeNull();
    info.Questions.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new LawsSearchResult.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<LawsSearchResult>();
    result.Page.Should().BeNull();
    result.Count.Should().BeNull();
    result.Wording.Should().BeNull();
    result.Laws.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new QuestionsSearchResult.Info
    {
      Count = 1,
      Page = 2,
      PageSize = 3,
      Questions = new List<Question> {new(new {})}
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}