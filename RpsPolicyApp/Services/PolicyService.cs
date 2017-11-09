using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpsPolicyApp.DbContext;
using RpsPolicyApp.DTOs;
using RpsPolicyApp.Models;

namespace RpsPolicyApp.Services
{
  /// <summary>
  /// Business logic for Policy
  /// </summary>
  public class PolicyService
  {
    private readonly PolicyDbContext _dbContext;

    /// <summary>
    /// Init
    /// </summary>
    /// <param name="dbContext"></param>
    public PolicyService(PolicyDbContext dbContext)
    {
      if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
      _dbContext = dbContext;
    }

    /// <summary>
    /// Get only the data needed by the UI from all policies from the database
    /// </summary>
    /// <returns>List of <see cref="PolicyDto"/></returns>
    public List<PolicyDto> GetAllPolicies()
    {
      return _dbContext.Policies
        .Select(p => new PolicyDto
        {
          PolicyNumber = p.PolicyNumber,
          PrimaryInsuredName = p.PrimaryInsuredName,
          PolicyEffectiveDate = p.PolicyEffectiveDate,
          PolicyExpirationDate = p.PolicyExpirationDate
        }).AsNoTracking().ToList();
    }

    /// <summary>
    /// Create a new entry in the Policy database
    /// </summary>
    /// <param name="policy"><see cref="Policy"/></param>
    /// <returns>Boolean</returns>
    public async Task<bool> CreatePolicy(Policy policy)
    {
      if (policy == null) return false;

      try
      {
        _dbContext.Policies.Add(policy);
        await _dbContext.SaveChangesAsync(true);
      }
      catch (Exception e)
      {
        return false;
      }
      return true;
    }
  }
}
