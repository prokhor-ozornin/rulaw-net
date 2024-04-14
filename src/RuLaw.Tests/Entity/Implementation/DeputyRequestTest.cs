using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DeputyRequest"/>.</para>
/// </summary>
public sealed class DeputyRequestTest : ClassTest<DeputyRequest>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyRequest()"/>
  [Fact]
  public void Constructors()
  {
    typeof(DeputyRequest).Should().BeDerivedFrom<object>().And.Implement<IDeputyRequest>();

    var request = new DeputyRequest();
    request.Id.Should().BeNull();
    request.Name.Should().BeNull();
    request.Date.Should().BeNull();
    request.DocumentNumber.Should().BeNull();
    request.Initiator.Should().BeNull();
    request.Addressee.Should().BeNull();
    request.Answer.Should().BeNull();
    request.Signer.Should().BeNull();
    request.SignDate.Should().BeNull();
    request.ControlDate.Should().BeNull();
    request.ResolutionNumber.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new DeputyRequest { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new DeputyRequest { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new DeputyRequest { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.DocumentNumber"/> property.</para>
  /// </summary>
  [Fact]
  public void DocumentNumber_Property()
  {
    new DeputyRequest { DocumentNumber = Guid.Empty.ToString() }.DocumentNumber.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Initiator"/> property.</para>
  /// </summary>
  [Fact]
  public void Initiator_Property()
  {
    new DeputyRequest { Initiator = Guid.Empty.ToString() }.Initiator.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Addressee"/> property.</para>
  /// </summary>
  [Fact]
  public void Addressee_Property()
  {
    var addressee = new DeputyRequestAddressee();
    new DeputyRequest { Addressee = addressee }.Addressee.Should().BeSameAs(addressee);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Answer"/> property.</para>
  /// </summary>
  [Fact]
  public void Answer_Property()
  {
    new DeputyRequest { Answer = Guid.Empty.ToString() }.Answer.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Signer"/> property.</para>
  /// </summary>
  [Fact]
  public void Signer_Property()
  {
    var signer = new DeputyRequestSigner();
    new DeputyRequest { Signer = signer }.Signer.Should().BeSameAs(signer);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.SignDate"/> property.</para>
  /// </summary>
  [Fact]
  public void SignDate_Property()
  {
    new DeputyRequest { SignDate = DateTimeOffset.MaxValue }.SignDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.ControlDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ControlDate_Property()
  {
    new DeputyRequest { ControlDate = DateTimeOffset.MaxValue }.ControlDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.ResolutionNumber"/> property.</para>
  /// </summary>
  [Fact]
  public void ResolutionNumber_Property()
  {
    new DeputyRequest { ResolutionNumber = Guid.Empty.ToString() }.ResolutionNumber.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.CompareTo(IDeputyRequest)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(DeputyRequest.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="DeputyRequest.Equals(IDeputyRequest)"/></description></item>
  ///     <item><description><see cref="DeputyRequest.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(DeputyRequest.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(DeputyRequest.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new DeputyRequest {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new DeputyRequest
      {
        Id = 1,
        Addressee = new DeputyRequestAddressee(),
        Answer = "answer",
        ControlDate = DateTimeOffset.MinValue,
        Date = DateTimeOffset.MinValue,
        DocumentNumber = "documentNumber",
        Initiator = "initiator",
        Name = "name",
        ResolutionNumber = "resolutionNumber",
        SignDate = DateTimeOffset.MinValue,
        Signer = new DeputyRequestSigner()
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}