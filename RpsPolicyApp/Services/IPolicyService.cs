using System.Collections.Generic;
using System.Threading.Tasks;
using RpsPolicyApp.Models;
using RpsPolicyApp.ResponseObjects;

namespace RpsPolicyApp.Services
{
  public interface IPolicyService
  {
    Task<bool> CreatePolicy(Policy policy);
    List<PolicyResponse> GetAllPolicies();
  }
}