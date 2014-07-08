using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputyRequestExtensions"/>.</para>
  /// </summary>
  public sealed class DeputyRequestExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestExtensions.Answer(IEnumerable{IDeputyRequest}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Answer_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyRequestExtensions.Answer(null, "text"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<IDeputyRequest>().Answer(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<IDeputyRequest>().Answer(string.Empty));

      Assert.False(Enumerable.Empty<IDeputyRequest>().Answer("answer").Any());

      var first = new DeputyRequest { Answer = "FIRST" };
      var second = new DeputyRequest { Answer = "Second" };
      var requests = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, requests.Answer("first").Single()));
      Assert.True(ReferenceEquals(second, requests.Answer("second").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestExtensions.ControlDate(IEnumerable{IDeputyRequest}, DateTime?, DateTime?)"/> method.</para>
    /// </summary>
    [Fact]
    public void ControlDate_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyRequestExtensions.ControlDate(null));

      Assert.False(Enumerable.Empty<IDeputyRequest>().ControlDate().Any());

      var date = new DateTime(2000, 1, 1);

      var first = new DeputyRequest { ControlDate = DateTime.MinValue };
      var second = new DeputyRequest { ControlDate = date };
      var third = new DeputyRequest { ControlDate = DateTime.MaxValue };

      var requests = new[] { null, first, second, third };
      Assert.True(requests.ControlDate(date).SequenceEqual(new[] { second, third }));
      Assert.True(requests.ControlDate(null, date).SequenceEqual(new[] { first, second }));
      Assert.True(requests.ControlDate(DateTime.MinValue, DateTime.MaxValue).SequenceEqual(new[] { first, second, third }));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestExtensions.Initiator(IEnumerable{IDeputyRequest}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Initiator_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyRequestExtensions.Initiator(null, "initiator"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<IDeputyRequest>().Initiator(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<IDeputyRequest>().Initiator(string.Empty));

      Assert.False(Enumerable.Empty<IDeputyRequest>().Initiator("initiator").Any());

      var first = new DeputyRequest { Initiator = "FIRST" };
      var second = new DeputyRequest { Initiator = "Second" };
      var requests = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, requests.Initiator("first").Single()));
      Assert.True(ReferenceEquals(second, requests.Initiator("second").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestExtensions.SignDate(IEnumerable{IDeputyRequest}, DateTime?, DateTime?)"/> method.</para>
    /// </summary>
    [Fact]
    public void SignDate_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyRequestExtensions.SignDate(null));

      var date = new DateTime(2000, 1, 1);

      var first = new DeputyRequest { SignDate = DateTime.MinValue };
      var second = new DeputyRequest { SignDate = date };
      var third = new DeputyRequest { SignDate = DateTime.MaxValue };

      var requests = new[] { null, first, second, third };
      Assert.True(requests.SignDate(date).SequenceEqual(new[] { first, second }));
      Assert.True(requests.SignDate(null, date).SequenceEqual(new[] { first, second }));
      Assert.True(requests.SignDate(DateTime.MinValue, DateTime.MaxValue).SequenceEqual(new[] { first, second, third }));
    }
  }
}