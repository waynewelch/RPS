using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpsPolicyApp.DTOs;
using RpsPolicyApp.Models;
using RpsPolicyApp.Services;

namespace RpsPolicyApp.Controllers
{
  /// <summary>
  /// Public API for Policy Management
  /// </summary>
  [Produces("application/json")]
  [Route("api/Policy")]
  public class PolicyController : Controller
  {
    private readonly PolicyService _policyService;

    /// <summary>
    /// Init
    /// </summary>
    /// <param name="policyService"></param>
    public PolicyController(PolicyService policyService)
    {
      _policyService = policyService;
    }

    /// <summary>
    /// Get all entries from Policy database
    /// </summary>
    /// <returns>List of <see cref="Policy"/></returns>
    /// GET: api/Policy
    [HttpGet]
    [ProducesResponseType(typeof(IList<PolicyDto>), 200)]
    public IList<PolicyDto> Get()
    {
      var result = _policyService.GetAllPolicies();
      return result;
    }

    /// <summary>
    /// Create a new Policy database entry
    /// </summary>
    /// <param name="value"><see cref="Policy"/></param>
    /// <returns><see cref="IActionResult"/></returns>
    // POST: api/Policy
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), 201)]
    public async Task<IActionResult> Post([FromBody]Policy value)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      bool success;

      try
      {
        success = await _policyService.CreatePolicy(value);
      }
      catch (Exception e)
      {
        return BadRequest(Json(e));
      }

      return Created("/Policies", success);
    }
  }
}
