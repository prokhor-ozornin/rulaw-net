using System.Configuration;
using Catharsis.Commons;
using FluentAssertions.Execution;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IQuestionsApiExtensions"/>.</para>
/// </summary>
public sealed class IQuestionsApiExtensionsTest : UnitTest
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IQuestionsApiExtensions.Search(IQuestionsApi, IQuestionsApiRequest)"/></description></item>
  ///     <item><description><see cref="IQuestionsApiExtensions.Search(IQuestionsApi, Action{IQuestionsApiRequest})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Search_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IQuestionsApiExtensions.Search(null, new QuestionsApiRequest())).ThrowExactly<ArgumentNullException>();

      var result = Api.Questions.Search(new QuestionsApiRequest().FromDate(new DateTimeOffset(year: 2013, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).ToDate(new DateTimeOffset(year: 2013, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Name("образование").PageSize(PageSize.Five).Page(2));
      Validate(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IQuestionsApiExtensions.Search(null, _ => {})).ThrowExactly<ArgumentNullException>();

      var result = Api.Questions.Search(request => request.FromDate(new DateTimeOffset(year: 2013, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).ToDate(new DateTimeOffset(year: 2013, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Name("образование").PageSize(PageSize.Five).Page(2));
      Validate(result);
    }

    return;

    static void Validate(IQuestionsSearchResult result)
    {
      result.Should().NotBeNull().And.BeOfType<QuestionsSearchResult>();

      result.Count.Should().Be(44);
      result.Page.Should().Be(2);
      result.PageSize.Should().Be((int) PageSize.Five);

      result.Questions.Should().NotBeNullOrEmpty().And.BeOfType<IList<Question>>().And.HaveCount(5);

      var question = result.Questions.ElementAt(0);
      question.Name.Should().Be(@"О проекте федерального закона № 641168-5 ""Об образовании постоянных судебных присутствий в составе некоторых районных судов Ростовской области"".");
      question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(19).And.HaveOffset(TimeSpan.Zero);
      question.SessionCode.Should().Be(1367);
      question.Code.Should().Be(8);
      question.StartLine.Should().Be(1379);
      question.EndLine.Should().Be(6569);

      question = result.Questions.ElementAt(1);
      question.Name.Should().Be(@"О проекте федерального закона № 641168-5 ""Об образовании постоянных судебных присутствий в составе некоторых районных судов Ростовской области"" (принят в первом чтении 11 октября 2013 года с наименованием ""Об образовании в некоторых районных судах Ростовской области постоянных судебных присутствий"").");
      question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(15).And.HaveOffset(TimeSpan.Zero);
      question.SessionCode.Should().Be(1366);
      question.Code.Should().Be(18);
      question.StartLine.Should().Be(2096);
      question.EndLine.Should().Be(5763);

      question = result.Questions.ElementAt(2);
      question.Name.Should().Be(@"О проекте федерального закона № 249992-6 ""О внесении изменений в Федеральный закон ""Об общих принципах организации местного самоуправления в Российской Федерации"" (в части установления порядка избрания главы муниципального образования в поселениях с численностью жителей, обладающих избирательным правом, более 30 тысяч человек).");
      question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(15).And.HaveOffset(TimeSpan.Zero);
      question.SessionCode.Should().Be(1366);
      question.Code.Should().Be(27);
      question.StartLine.Should().Be(1299);
      question.EndLine.Should().Be(1343);

      question = result.Questions.ElementAt(3);
      question.Name.Should().Be(@"О проекте федерального закона № 228222-6 ""О внесении изменений в статью 11 Федерального закона ""О трудовых пенсиях в Российской Федерации"" (по вопросу о включении в страховой стаж для назначения пенсии периода получения высшего образования по очной форме обучения в государственных или муниципальных организациях высшего образования).");
      question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(15).And.HaveOffset(TimeSpan.Zero);
      question.SessionCode.Should().Be(1366);
      question.Code.Should().Be(29);
      question.StartLine.Should().Be(3867);
      question.EndLine.Should().Be(5943);

      question = result.Questions.ElementAt(4);
      question.Name.Should().Be(@"О проекте федерального закона № 193817-6 ""О внесении изменения в статью 19-1 Федерального закона ""Об обороте земель сельскохозяйственного назначения"" (в части продления срока осуществления органами местного самоуправления мероприятий по образованию земельных участков сельскохозяйственного назначения из земельных участков, находящихся в общей собственности).");
      question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
      question.SessionCode.Should().Be(1364);
      question.Code.Should().Be(40);
      question.StartLine.Should().Be(6225);
      question.EndLine.Should().Be(6278);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IQuestionsApiExtensions.SearchAsync(IQuestionsApi, Action{IQuestionsApiRequest}, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void SearchAsync_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IQuestionsApiExtensions.SearchAsync(null)).ThrowExactlyAsync<ArgumentNullException>().Await();
      AssertionExtensions.Should(() => IQuestionsApiExtensions.SearchAsync(Api.Questions, null, Attributes.CancellationToken())).ThrowExactlyAsync<OperationCanceledException>().Await();

      var result = Api.Questions.SearchAsync(request => request.FromDate(new DateTimeOffset(year: 2013, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).ToDate(new DateTimeOffset(year: 2013, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Name("образование").PageSize(PageSize.Five).Page(2)).Await();
      Validate(result);
    }

    return;

    static void Validate(IQuestionsSearchResult result)
    {
      result.Should().NotBeNull().And.BeOfType<QuestionsSearchResult>();

      result.Count.Should().Be(44);
      result.Page.Should().Be(2);
      result.PageSize.Should().Be((int) PageSize.Five);

      result.Questions.Should().NotBeNullOrEmpty().And.BeOfType<IList<Question>>().And.HaveCount(5);

      var question = result.Questions.ElementAt(0);
      question.Name.Should().Be(@"О проекте федерального закона № 641168-5 ""Об образовании постоянных судебных присутствий в составе некоторых районных судов Ростовской области"".");
      question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(19).And.HaveOffset(TimeSpan.Zero);
      question.SessionCode.Should().Be(1367);
      question.Code.Should().Be(8);
      question.StartLine.Should().Be(1379);
      question.EndLine.Should().Be(6569);

      question = result.Questions.ElementAt(1);
      question.Name.Should().Be(@"О проекте федерального закона № 641168-5 ""Об образовании постоянных судебных присутствий в составе некоторых районных судов Ростовской области"" (принят в первом чтении 11 октября 2013 года с наименованием ""Об образовании в некоторых районных судах Ростовской области постоянных судебных присутствий"").");
      question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(15).And.HaveOffset(TimeSpan.Zero);
      question.SessionCode.Should().Be(1366);
      question.Code.Should().Be(18);
      question.StartLine.Should().Be(2096);
      question.EndLine.Should().Be(5763);

      question = result.Questions.ElementAt(2);
      question.Name.Should().Be(@"О проекте федерального закона № 249992-6 ""О внесении изменений в Федеральный закон ""Об общих принципах организации местного самоуправления в Российской Федерации"" (в части установления порядка избрания главы муниципального образования в поселениях с численностью жителей, обладающих избирательным правом, более 30 тысяч человек).");
      question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(15).And.HaveOffset(TimeSpan.Zero);
      question.SessionCode.Should().Be(1366);
      question.Code.Should().Be(27);
      question.StartLine.Should().Be(1299);
      question.EndLine.Should().Be(1343);

      question = result.Questions.ElementAt(3);
      question.Name.Should().Be(@"О проекте федерального закона № 228222-6 ""О внесении изменений в статью 11 Федерального закона ""О трудовых пенсиях в Российской Федерации"" (по вопросу о включении в страховой стаж для назначения пенсии периода получения высшего образования по очной форме обучения в государственных или муниципальных организациях высшего образования).");
      question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(15).And.HaveOffset(TimeSpan.Zero);
      question.SessionCode.Should().Be(1366);
      question.Code.Should().Be(29);
      question.StartLine.Should().Be(3867);
      question.EndLine.Should().Be(5943);

      question = result.Questions.ElementAt(4);
      question.Name.Should().Be(@"О проекте федерального закона № 193817-6 ""О внесении изменения в статью 19-1 Федерального закона ""Об обороте земель сельскохозяйственного назначения"" (в части продления срока осуществления органами местного самоуправления мероприятий по образованию земельных участков сельскохозяйственного назначения из земельных участков, находящихся в общей собственности).");
      question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
      question.SessionCode.Should().Be(1364);
      question.Code.Should().Be(40);
      question.StartLine.Should().Be(6225);
      question.EndLine.Should().Be(6278);
    }
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    Api.Dispose();
  }
}