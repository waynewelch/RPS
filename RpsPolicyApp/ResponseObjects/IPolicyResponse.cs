using System.Collections.Generic;

namespace RpsPolicyApp.ResponseObjects
{
  public interface IPolicyResponse
  {
    List<PolicyResponse> GetPolicyResponse();
  }
}