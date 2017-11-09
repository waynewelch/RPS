using System;
using System.ComponentModel.DataAnnotations;

namespace RpsPolicyApp.Models
{
  public class Policy
  {
    /// <summary>
    /// Auto-incrimenting primary key assigned by the database
    /// </summary>
    [Key]
    public int? id { get; set; }

    /// <summary>
    /// Policy identification number
    /// </summary>
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

    /// <summary>
    /// Policy holder mailing street address
    /// </summary>
    public string PrimaryInsuredMailingAddress { get; set; }

    /// <summary>
    /// Policy holder mailing city
    /// </summary>
    public string PrimaryInusredCity { get; set; }

    /// <summary>
    /// Policy holder mailing state
    /// </summary>
    public string PrimaryInsuredState { get; set; }

    /// <summary>
    /// Policy holder mailing zip code
    /// </summary>
    public string PrimaryInsuredZipCode { get; set; }

    /// <summary>
    /// Type of construction to be insured
    /// <value><see cref="Enums.RiskConstructionTypes"/></value>
    /// </summary>
    public int RiskConstruction { get; set; }

    /// <summary>
    /// Insured property construction year
    /// </summary>
    public int RiskYearBuilt { get; set; }

    /// <summary>
    /// Insured property street address
    /// </summary>
    public string RiskAddress { get; set; }

    /// <summary>
    /// Insured property city
    /// </summary>
    public string RiskCity { get; set; }

    /// <summary>
    /// Insured property state
    /// </summary>
    public string RiskState { get; set; }

    /// <summary>
    /// Insured property zip code
    /// </summary>
    public string RiskZipCode { get; set; }
  }
}
