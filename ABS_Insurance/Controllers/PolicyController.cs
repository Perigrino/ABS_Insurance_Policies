using ABS_Insurance.Data.Dto;
using ABS_Insurance.Interface;
using ABS_Insurance.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ABS_Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly IMapper _mapper;

        public PolicyController(IPolicyRepository policyRepository, IMapper mapper)
        {
            _policyRepository = policyRepository;
            _mapper = mapper;
        }
        // GET: api/Policy
        [HttpGet]
        public IActionResult GetPolicies()
        {
            var policy = _policyRepository.GetPolicies().ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(policy);
        }

        // GET: api/Policy/5
        [HttpGet("{policyId}")]
        public IActionResult GetPolicy(int policyId)
        {
            if (policyId == null)
                return BadRequest();
            var policy = _policyRepository.GetPolicy(policyId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(policy);

        }

        // POST: api/Policy
        [HttpPost]
        public IActionResult PostPolicy([FromBody] CreatePolicyDto createPolicy)
        {
            if (createPolicy == null)
                return BadRequest(ModelState);
            
            var policy = _policyRepository.GetPolicies()
                .Where(pn => pn.PolicyName.ToUpper().Trim() == createPolicy.PolicyName.ToUpper().Trim())
                .FirstOrDefault();

            if (policy != null)
            {
                ModelState.AddModelError("","Policy already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var policyMap = _mapper.Map<Policy>(createPolicy);
            if (!_policyRepository.CreatePolicy(policyMap))
            {
                ModelState.AddModelError("","Something went wrong whiles adding Policy");
                return StatusCode(500, ModelState);
            }

            return Ok("Policy has been created successfully");
        }

        // PUT: api/Policy/5
        [HttpPut("{policyId}")]
        public IActionResult UpdatePolicy(int policyId, [FromBody] UpdatePolicyDto updatePolicy)
        {
            if (updatePolicy == null)
                return BadRequest(ModelState);
            
            if (policyId != updatePolicy.PolicyId)
                return BadRequest(ModelState);
            
            if (!_policyRepository.PolicyExists(policyId))
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var policyMap = _mapper.Map<Policy>(updatePolicy);

            if (!_policyRepository.UpdatePolicy(policyMap))
            {
                ModelState.AddModelError("","Something went wrong whiles updating Policy");
                return StatusCode(500, ModelState);
            }

            return Ok("Policy has been updated successfully");
        }

        
        // DELETE: api/Policy/5
        [HttpDelete("{policyId}")]
        public IActionResult DeletePolicy(int policyId)
        {
            if (policyId == null)
                return BadRequest(ModelState);

            if (!_policyRepository.PolicyExists(policyId))
                return NotFound();

            var policyToDelete = _policyRepository.GetPolicy(policyId);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (!_policyRepository.DeletePolicy(policyToDelete))
            {
                ModelState.AddModelError("", "Something went wrong whiles deleting the Policy");
                return StatusCode(500, ModelState);
            }
            return Ok("Policy deleted successfully");
        }
    }
}