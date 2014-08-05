using System;

namespace RuLaw
{
  internal sealed class MockJsonObject
  {
    public long Id { get; set; }

    public string PublicProperty { get; set; }

    public string PublicField;

    public DateTime? Date { get; set; }
  }
}