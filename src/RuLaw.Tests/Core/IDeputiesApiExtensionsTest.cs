using System.Configuration;
using Catharsis.Extensions;
using FluentAssertions.Execution;
using FluentAssertions;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IDeputiesApiExtensions"/>.</para>
/// </summary>
public sealed class IDeputiesApiExtensionsTest : UnitTest
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputiesApiExtensions.Find(IDeputiesApi, long)"/> method.</para>
  /// </summary>
  [Fact]
  public void Find_Method()
  {
    AssertionExtensions.Should(() => IDeputiesApiExtensions.Find(null, 1)).ThrowExactly<ArgumentNullException>().WithParameterName("api");

    var deputy = Api.Deputies.Find(99100142);

    deputy.Should().NotBeNull().And.BeOfType<DeputyInfo>();
    
    deputy.LastName.Should().Be("Жириновский");
    deputy.FirstName.Should().Be("Владимир");
    deputy.MiddleName.Should().Be("Вольфович");
    deputy.BirthDate.Should().HaveYear(1946).And.HaveMonth(4).And.HaveDay(25).And.HaveOffset(TimeSpan.Zero);
    deputy.WorkStartDate.Should().HaveYear(2016).And.HaveMonth(9).And.HaveDay(18).And.HaveOffset(TimeSpan.Zero);
    deputy.FactionId.Should().Be(72100005);
    deputy.FactionName.Should().Be("Фракция Политической партии ЛДПР - Либерально-демократической партии России");
    deputy.FactionRole.Trim().Should().Be("00020 Руководитель фракции");
    deputy.Active.Should().BeFalse();
    deputy.FactionRegion.Should().Be("(Общефедеральная часть федерального списка кандидатов).");
    deputy.LawsCount.Should().BePositive();
    deputy.Regions.Should().NotBeNullOrEmpty().And.Contain("все субъекты Российской Федерации");
    deputy.SpeechesCount.Should().BePositive();
    deputy.VoteLink.Should().Be("http://vote.duma.gov.ru/?convocation=AAAAAAA7&deputy=99100142&sort=date_desc");
    deputy.TranscriptLink.Should().Be("http://www.cir.ru/duma/servlet/is4.wwwmain?FormName=ProcessQuery&Action=RunQuery&PDCList=*&QueryString=%2FGD_%C4%C5%CF%D3%D2%C0%D2%3D%22%C6%C8%D0%C8%CD%CE%C2%D1%CA%C8%C9+%C2.%C2.%22");
    deputy.Educations.Should().NotBeNullOrEmpty().And.Contain(education => education.Institution == "Московский государственный университет имени М.В.Ломоносова (институт восточных языков)" && education.Year == 1970);
    deputy.Degrees.Should().NotBeNullOrEmpty().And.Contain("Доктор философских наук");
    deputy.Ranks.Should().NotBeNullOrEmpty().And.Contain(["Профессор", "Действительный член (академик) Международной Академии экологии и природопользования (МАЭП)", "Почетный академик Академии естествознания", "Действительный член Международной Академии информатизации", "Действительный член (академик) Академии социальных наук"]);
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IDeputiesApiExtensions.Search(IDeputiesApi, IDeputiesApiRequest)"/></description></item>
  ///     <item><description><see cref="IDeputiesApiExtensions.Search(IDeputiesApi, Action{IDeputiesApiRequest})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Search_Methods()
  {
    static void Validate(IEnumerable<IDeputy> sequence)
    {
      sequence.Should().NotBeNullOrEmpty().And.BeOfType<List<Deputy>>();

      var deputy = sequence.Single(deputy => deputy.Id == 99100491);
      deputy.Should().NotBeNull().And.BeOfType<Deputy>();
      deputy.Name.Should().Be("Абдулатипов Рамазан Гаджимурадович");
      deputy.Position.Should().Be("Депутат ГД");
      deputy.Active.Should().BeFalse();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputiesApiExtensions.Search(null, new DeputiesApiRequest())).ThrowExactly<ArgumentNullException>().WithParameterName("api");
      AssertionExtensions.Should(() => Api.Deputies.Search((IDeputiesApiRequest) null)).ThrowExactly<TaskCanceledException>();

      var deputies = Api.Deputies.Search(new DeputiesApiRequest().Position(DeputyPosition.DumaDeputy).Current(false).Name("А"));
      Validate(deputies);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputiesApiExtensions.Search(null, _ => {})).ThrowExactly<ArgumentNullException>().WithParameterName("api");
      AssertionExtensions.Should(() => Api.Deputies.Search((Action<IDeputiesApiRequest>) null)).ThrowExactly<TaskCanceledException>();

      var deputies = Api.Deputies.Search(request => request.Position(DeputyPosition.DumaDeputy).Current(false).Name("А"));
      Validate(deputies);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputiesApiExtensions.SearchAsync(IDeputiesApi, Action{IDeputiesApiRequest}, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void SearchAsync_Method()
  {
    AssertionExtensions.Should(() => IDeputiesApiExtensions.SearchAsync(null, _ => {})).ThrowExactly<ArgumentNullException>().WithParameterName("api");
    AssertionExtensions.Should(() => IDeputiesApiExtensions.SearchAsync(Api.Deputies, null, Cancellation)).ThrowExactly<OperationCanceledException>();

    var deputies = Api.Deputies.SearchAsync(request => request.Position(DeputyPosition.DumaDeputy).Current(false).Name("А")).ToListAsync().Await();

    deputies.Should().NotBeNullOrEmpty().And.BeOfType<List<Deputy>>();

    var deputy = deputies.Single(deputy => deputy.Id == 99100491);
    deputy.Name.Should().Be("Абдулатипов Рамазан Гаджимурадович");
    deputy.Position.Should().Be("Депутат ГД");
    deputy.Active.Should().BeFalse();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    Api.Dispose();
  }
}