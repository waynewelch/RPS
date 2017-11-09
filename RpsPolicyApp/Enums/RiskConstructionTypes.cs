using System.Runtime.Serialization;

namespace RpsPolicyApp.Enums
{
  /// <summary>
  /// Construction types for Policy object
  /// </summary>
  public enum RiskConstructionTypes
  {
    [EnumMember(Value = "Site Built Home")]
    SiteBuiltHome = 0,
    [EnumMember(Value = "Modular Home")]
    ModularHome = 1,
    [EnumMember(Value = "Single Wide Manufactured Home")]
    SingleWideManufacturedHome = 2,
    [EnumMember(Value = "Double Wide Manufactured Home")]
    DoubleWideManufacturedHome = 3
  }
}
