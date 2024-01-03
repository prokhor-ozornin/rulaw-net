using System.Configuration;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IRequestsApiExtensions"/>.</para>
/// </summary>
public sealed class IRequestsApiExtensionsTest : UnitTest
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  /// <summary>
  ///   <para>Performs testing of <see cref="IRequestsApiExtensions.All(IRequestsApi)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    AssertionExtensions.Should(() => IRequestsApiExtensions.All(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");

    var requests = Api.Requests.All();

    requests.Should().NotBeNullOrEmpty().And.BeOfType<List<DeputyRequest>>();

    var request = requests.First(request => request.Id == 14);
    request.Initiator.Should().Be("Герасименко Н.Ф.");
    request.Date.Should().HaveYear(2004).And.HaveMonth(11).And.HaveDay(10).And.HaveOffset(TimeSpan.Zero);
    request.Name.Should().Be("О присоединении Российской Федерации к Рамочной конвенции Всемирной организации здравоохранения по борьбе против табака (N 1103-IV ГД от 10 ноября 2004 г.).");
    request.ControlDate.Should().HaveYear(2004).And.HaveMonth(11).And.HaveDay(30).And.HaveOffset(TimeSpan.Zero);
    request.SignDate.Should().HaveYear(2004).And.HaveMonth(11).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
    request.DocumentNumber.Should().Be("2.1.2-10/14");
    request.ResolutionNumber.Should().Be("1103-IV ГД");
    request.Answer.Should().NotBeNull();

    request.Signer.Should().NotBeNull().And.BeOfType<DeputyRequestSigner>();
    request.Signer.Id.Should().Be(99100416);
    request.Signer.Name.Should().Be("Чилингаров Артур Николаевич");
    
    request.Addressee.Should().NotBeNull().And.BeOfType<DeputyRequestAddressee>();
    request.Addressee.Id.Should().Be(3);
    request.Addressee.Name.Should().Be(@"Председателю Правительства РФ\М.Е. Фрадкову");
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    Api.Dispose();
  }
}