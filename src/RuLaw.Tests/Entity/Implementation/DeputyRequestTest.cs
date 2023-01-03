using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DeputyRequest"/>.</para>
/// </summary>
public sealed class DeputyRequestTest : UnitTest<DeputyRequest>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new DeputyRequest(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new DeputyRequest(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new DeputyRequest(new {Date = DateTimeOffset.MaxValue}).Date.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.DocumentNumber"/> property.</para>
  /// </summary>
  [Fact]
  public void DocumentNumber_Property() { new DeputyRequest(new {DocumentNumber = Guid.Empty.ToString()}).DocumentNumber.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Initiator"/> property.</para>
  /// </summary>
  [Fact]
  public void Initiator_Property() { new DeputyRequest(new {Initiator = Guid.Empty.ToString()}).Initiator.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Addressee"/> property.</para>
  /// </summary>
  [Fact]
  public void Addressee_Property()
  {
    var addressee = new DeputyRequestAddressee();
    new DeputyRequest(new {Addressee = addressee}).Addressee.Should().BeSameAs(addressee);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Answer"/> property.</para>
  /// </summary>
  [Fact]
  public void Answer_Property() { new DeputyRequest(new {Answer = Guid.Empty.ToString()}).Answer.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Signer"/> property.</para>
  /// </summary>
  [Fact]
  public void Signer_Property()
  {
    var signer = new DeputyRequestSigner();
    new DeputyRequest(new {Signer = signer}).Signer.Should().BeSameAs(signer);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.SignDate"/> property.</para>
  /// </summary>
  [Fact]
  public void SignDate_Property() { new DeputyRequest(new {SignDate = DateTimeOffset.MaxValue}).SignDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.ControlDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ControlDate_Property() { new DeputyRequest(new {ControlDate = DateTimeOffset.MaxValue}).ControlDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.ResolutionNumber"/> property.</para>
  /// </summary>
  [Fact]
  public void ResolutionNumber_Property() { new DeputyRequest(new {ResolutionNumber = Guid.Empty.ToString()}).ResolutionNumber.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyRequest(long?, string?, DateTimeOffset?, string?, string?, IDeputyRequestAddressee?, string?, IDeputyRequestSigner?, DateTimeOffset?, DateTimeOffset?, string?)"/>
  /// <seealso cref="DeputyRequest(DeputyRequest.Info)"/>
  /// <seealso cref="DeputyRequest(object)"/>
  [Fact]
  public void Constructors()
  {
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

    request = new DeputyRequest(new DeputyRequest.Info());
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

    request = new DeputyRequest(new {});
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
  public void ToString_Method() { new DeputyRequest(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="DeputyRequest.Info"/>.</para>
/// </summary>
public sealed class DeputyRequestInfoTests : UnitTest<DeputyRequest.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new DeputyRequest.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new DeputyRequest.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new DeputyRequest.Info {Date = DateTimeOffset.MaxValue}.Date.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.DocumentNumber"/> property.</para>
  /// </summary>
  [Fact]
  public void DocumentNumber_Property() { new DeputyRequest.Info {DocumentNumber = Guid.Empty.ToString()}.DocumentNumber.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.Initiator"/> property.</para>
  /// </summary>
  [Fact]
  public void Initiator_Property() { new DeputyRequest.Info {Initiator = Guid.Empty.ToString()}.Initiator.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.Addressee"/> property.</para>
  /// </summary>
  [Fact]
  public void Addressee_Property()
  {
    var addressee = new DeputyRequestAddressee();
    new DeputyRequest.Info {Addressee = addressee}.Addressee.Should().BeSameAs(addressee);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.Answer"/> property.</para>
  /// </summary>
  [Fact]
  public void Answer_Property() { new DeputyRequest.Info {Answer = Guid.Empty.ToString()}.Answer.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.Signer"/> property.</para>
  /// </summary>
  [Fact]
  public void Signer_Property()
  {
    var signer = new DeputyRequestSigner();
    new DeputyRequest.Info {Signer = signer}.Signer.Should().BeSameAs(signer);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.SignDate"/> property.</para>
  /// </summary>
  [Fact]
  public void SignDate_Property() { new DeputyRequest.Info {SignDate = Guid.Empty.ToString()}.SignDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.ControlDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ControlDate_Property() { new DeputyRequest.Info {ControlDate = Guid.Empty.ToString()}.ControlDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.ResolutionNumber"/> property.</para>
  /// </summary>
  [Fact]
  public void ResolutionNumber_Property() { new DeputyRequest.Info {ResolutionNumber = Guid.Empty.ToString()}.ResolutionNumber.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyRequest.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new DeputyRequest.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
    info.Date.Should().BeNull();
    info.DocumentNumber.Should().BeNull();
    info.Initiator.Should().BeNull();
    info.Addressee.Should().BeNull();
    info.Answer.Should().BeNull();
    info.Signer.Should().BeNull();
    info.SignDate.Should().BeNull();
    info.ControlDate.Should().BeNull();
    info.ResolutionNumber.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequest.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new DeputyRequest.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<DeputyRequest>();
    result.Id.Should().BeNull();
    result.Name.Should().BeNull();
    result.Date.Should().BeNull();
    result.DocumentNumber.Should().BeNull();
    result.Initiator.Should().BeNull();
    result.Addressee.Should().BeNull();
    result.Answer.Should().BeNull();
    result.Signer.Should().BeNull();
    result.SignDate.Should().BeNull();
    result.ControlDate.Should().BeNull();
    result.ResolutionNumber.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new DeputyRequest.Info
    {
      Id = 1,
      Addressee = new DeputyRequestAddressee(),
      Answer = "answer",
      ControlDate = DateTimeOffset.MinValue.AsString(),
      Date = DateTimeOffset.MinValue,
      DocumentNumber = "documentNumber",
      Initiator = "initiator",
      Name = "name",
      ResolutionNumber = "resolutionNumber",
      SignDate = DateTimeOffset.MinValue.AsString(),
      Signer = new DeputyRequestSigner()
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}