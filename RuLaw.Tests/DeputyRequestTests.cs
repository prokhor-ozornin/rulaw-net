using System;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputyRequest"/>.</para>
  /// </summary>
  public sealed class DeputyRequestTests : UnitTestsBase<DeputyRequest>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Id", "Name");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new DeputyRequest(), new { controlDate = default(DateTime), requestDate = default(DateTime), requestId = 0, signedDate = default(DateTime) });
      this.TestJson(
        new DeputyRequest
        {
          Id = 1,
          Addressee = new DeputyRequestAddressee(),
          Answer = "answer",
          ControlDate = DateTime.MinValue,
          Date = DateTime.MinValue,
          DocumentNumber = "documentNumber",
          Initiator = "initiator",
          Name = "name",
          ResolutionNumber = "resolutionNumber",
          SignDate = DateTime.MinValue,
          Signer = new DeputyRequestSigner()
        },
        new { addressee = new { id = 0 }, answer = "answer", controlDate = DateTime.MinValue, documentNumber = "documentNumber", initiator = "initiator", name = "name", requestDate = DateTime.MinValue, requestId = 1, resolution = "resolutionNumber", signedBy = new { id = 0 }, signedDate = DateTime.MinValue }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new DeputyRequest(), "request", new { controlDate = default(DateTime).ISO8601(), requestDate = default(DateTime).ISO8601(), requestId = 0, signedDate = default(DateTime).ISO8601() });
      this.TestXml(
        new DeputyRequest
        {
          Id = 1,
          Addressee = new DeputyRequestAddressee(),
          Answer = "answer",
          ControlDate = DateTime.MinValue,
          Date = DateTime.MinValue,
          DocumentNumber = "documentNumber",
          Initiator = "initiator",
          Name = "name",
          ResolutionNumber = "resolutionNumber",
          SignDate = DateTime.MinValue,
          Signer = new DeputyRequestSigner()
        },
        "request",
        new { answer = "answer", controlDate = DateTime.MinValue.ISO8601(), documentNumber = "documentNumber", initiator = "initiator", name = "name", requestDate = DateTime.MinValue.ISO8601(), requestId = 1, resolution = "resolutionNumber", signedDate = DateTime.MinValue.ISO8601() }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DeputyRequest()"/>
    [Fact]
    public void Constructors()
    {
      var signer = new DeputyRequestSigner();
      Assert.Equal(0, signer.Id);
      Assert.Null(signer.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new DeputyRequest { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.Addressee"/> property.</para>
    /// </summary>
    [Fact]
    public void Addressee_Property()
    {
      var addressee = new DeputyRequestAddressee();
      Assert.True(ReferenceEquals(new DeputyRequest { Addressee = addressee }.Addressee, addressee));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.Answer"/> property.</para>
    /// </summary>
    [Fact]
    public void Answer_Property()
    {
      Assert.Equal("answer", new DeputyRequest { Answer = "answer" }.Answer);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.ControlDate"/> property.</para>
    /// </summary>
    [Fact]
    public void ControlDate_Property()
    {
      Assert.Equal(DateTime.MinValue, new DeputyRequest { ControlDate = DateTime.MinValue }.ControlDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new DeputyRequest { Date = DateTime.MinValue }.Date);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.DocumentNumber"/> property.</para>
    /// </summary>
    [Fact]
    public void DocumentNumber_Property()
    {
      Assert.Equal("documentNumber", new DeputyRequest { DocumentNumber = "documentNumber" }.DocumentNumber);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.ResolutionNumber"/> property.</para>
    /// </summary>
    [Fact]
    public void ResolutionNumber_Property()
    {
      Assert.Equal("resolutionNumber", new DeputyRequest { ResolutionNumber = "resolutionNumber" }.ResolutionNumber);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.Initiator"/> property.</para>
    /// </summary>
    [Fact]
    public void Initiator_Property()
    {
      Assert.Equal("initiator", new DeputyRequest { Initiator = "initiator" }.Initiator);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new DeputyRequest { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.SignDate"/> property.</para>
    /// </summary>
    [Fact]
    public void SignDate_Property()
    {
      Assert.Equal(DateTime.MinValue, new DeputyRequest { SignDate = DateTime.MinValue }.SignDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.Signer"/> property.</para>
    /// </summary>
    [Fact]
    public void Signer_Property()
    {
      var signer = new DeputyRequestSigner();
      Assert.True(ReferenceEquals(new DeputyRequest { Signer = signer }.Signer, signer));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.CompareTo(DeputyRequest)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="DeputyRequest.Equals(DeputyRequest)"/></description></item>
    ///     <item><description><see cref="DeputyRequest.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequest.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new DeputyRequest { Name = "name" }.ToString());
    }
  }
}