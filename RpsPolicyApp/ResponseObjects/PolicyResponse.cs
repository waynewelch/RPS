using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RpsPolicyApp.DbContext;
using RpsPolicyApp.Models;

namespace RpsPolicyApp.ResponseObjects
{
  public class PolicyResponse : IPolicyResponse
  {
    #region Properties

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

    #endregion

    #region Methods


    private readonly PolicyDbContext _dbContext;
    private readonly IPolicy _policy;

    public PolicyResponse(PolicyDbContext dbContext, IPolicy policy)
    {
      if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
      if (policy == null) throw new ArgumentNullException(nameof(policy));

      _dbContext = dbContext;
      _policy = policy;
    }

    /// <summary>
    /// Get list of policies from the Policy class and format it for the UI
    /// </summary>
    /// <returns>List of <see cref="PolicyResponse"/></returns>
    public List<PolicyResponse> GetPolicyResponse()
    {
      List<Policy> policies = _policy.GetAllPolicies();

      return policies.ConvertAll(x => new PolicyResponse(_dbContext, _policy)
      {
        PolicyNumber = x.PolicyNumber,
        PolicyExpirationDate = x.PolicyExpirationDate,
        PolicyEffectiveDate = x.PolicyEffectiveDate,
        PrimaryInsuredName = x.PrimaryInsuredName
      });
    }

    #endregion

  }
}
