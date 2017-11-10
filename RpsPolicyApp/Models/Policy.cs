using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RpsPolicyApp.DbContext;

namespace RpsPolicyApp.Models
{
  public class Policy : IPolicy
  {
    #region Properties

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

    #endregion

    #region Methods
    private PolicyDbContext _dbContext;

    public Policy()
    {
    }

    public Policy(PolicyDbContext dbContext)
    {
      if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));

      _dbContext = dbContext;
    }

    public List<Policy> GetAllPolicies()
    {
     return _dbContext.Policies.ToList();
    }

    /// <summary>
    /// Create a new entry in the Policy database
    /// </summary>
    /// <param name="policy"><see cref="Policy"/></param>
    /// <returns>Boolean</returns>
    public async Task<bool> InsertPolicy(Policy policy)
    {
      if (policy == null) return false;

      try
      {
        _dbContext.Policies.Add(policy);
        return await _dbContext.SaveChangesAsync(true) > 0;
      }
      catch (Exception e)
      {
        return false;
      }
    }

    #endregion
  }
}
