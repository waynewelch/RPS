using System;
using System.ComponentModel.DataAnnotations;

namespace RpsPolicyApp.DTOs
{
  public class PolicyDto
  {
    
    /// <summary>
    /// Policy identification number
    /// </summary>
    [Key]
    public int PolicyNumber { get; set; }

    /// <summary>
    /// Policy start date
    /// </summary>
    public DateTime PolicyEffectiveDate { get; set; }

    /// <summary>
    /// Policy end date
    /// </summary>
    public DateTime PolicyExpirationDate { get; set; }

    /// <summary>
    /// Name of policy holder
    /// </summary>
    public string PrimaryInsuredName { get; set; }
  }
}
