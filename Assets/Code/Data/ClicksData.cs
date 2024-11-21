using System;

namespace Code.Data
{
  [Serializable]
  public struct ClicksData : IEquatable<ClicksData>
  {
    public ulong Value;

    public ClicksData(ulong value)
    {
      Value = value;
    }

    public bool Equals(ClicksData other) => 
      Value == other.Value;

    public override bool Equals(object obj) => 
      obj is ClicksData other && Equals(other);

    public override int GetHashCode() => 
      Value.GetHashCode();

    public static ClicksData operator *(ClicksData clicksData1, ClicksData clicksData2) =>
      new(clicksData1.Value * clicksData2.Value);

    public static ClicksData operator /(ClicksData clicksData1, ClicksData clicksData2) =>
      new(clicksData1.Value / clicksData2.Value);

    public static ClicksData operator +(ClicksData clicksData1, ClicksData clicksData2) =>
      new(clicksData1.Value + clicksData2.Value);

    public static ClicksData operator -(ClicksData clicksData1, ClicksData clicksData2) =>
      new(clicksData1.Value - clicksData2.Value);

    public static bool operator ==(ClicksData clicksData1, ClicksData clicksData2) =>
      clicksData1.Value == clicksData2.Value;

    public static bool operator !=(ClicksData clicksData1, ClicksData clicksData2) =>
      !(clicksData1 == clicksData2);

    public static bool operator <(ClicksData clicksData1, ClicksData clicksData2) =>
      clicksData1.Value < clicksData2.Value;

    public static bool operator >(ClicksData clicksData1, ClicksData clicksData2) =>
      clicksData1.Value > clicksData2.Value;

    public static bool operator >=(ClicksData clicksData1, ClicksData clicksData2) =>
      clicksData1.Value >= clicksData2.Value;

    public static bool operator <=(ClicksData clicksData1, ClicksData clicksData2) =>
      clicksData1.Value <= clicksData2.Value;
  }
}