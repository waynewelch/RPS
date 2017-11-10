using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RpsPolicyApp.Models;
using RpsPolicyApp.ResponseObjects;

namespace RpsPolicyApp.Services
{
  /// <summary>
  /// Business logic for Policy
  /// </summary>
  public class PolicyService : IPolicyService
  {
    private readonly IPolicyResponse _policyResponse;
    private readonly IPolicy _policy;

    /// <summary>
    /// Init
    /// </summary>
    /// <param name="policyResponse"></param>
    /// <param name="policy"></param>
    public PolicyService(IPolicyResponse policyResponse, IPolicy policy)
    {
      if (policyResponse == null) throw new ArgumentNullException(nameof(policyResponse));
      if (policy == null) throw new ArgumentNullException(nameof(policy));

      _policyResponse = policyResponse;
      _policy = policy;
    }

    /// <summary>
    /// Get only the data needed by the UI from all policies from the database
    /// </summary>
    /// <returns>List of <see cref="PolicyResponse"/></returns>
    public List<PolicyResponse> GetAllPolicies()
    {
      return _policyResponse.GetPolicyResponse();
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
        return await _policy.InsertPolicy(policy);
      }
      catch (Exception e)
      {
        return false;
      }
    }
  }
}
