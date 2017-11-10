using System.Collections.Generic;
using System.Threading.Tasks;

namespace RpsPolicyApp.Models
{
  public interface IPolicy
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="policy"></param>
    /// <returns></returns>
    Task<bool> InsertPolicy(Policy policy);
    List<Policy> GetAllPolicies();
  }
}