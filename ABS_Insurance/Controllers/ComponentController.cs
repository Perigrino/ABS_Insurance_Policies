using ABS_Insurance.Data.Dto;
using ABS_Insurance.Interface;
using ABS_Insurance.Model;
using ABS_Insurance.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ABS_Insurance.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]

    public class ComponentController : ControllerBase
    {
        private readonly IComponentRepository _componentRepository;
        private readonly IPolicyRepository _policyRepository;
        private readonly IMapper _mapper;

        public ComponentController(IComponentRepository componentRepository, IMapper mapper, IPolicyRepository policyRepository)
        {
            _componentRepository = componentRepository;
            _policyRepository = policyRepository;
            _mapper = mapper;
        }

        // GET: api/Component
        [HttpGet]
        public IActionResult GetComponents()
        {
            var components = _mapper.Map<List<ComponentDto>>(_componentRepository.GetComponents().ToList());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(components);
        }

        // GET: api/Component/5
        [HttpGet("{componentId}")]
        public IActionResult GetComponent(int componentId)
        {
            if (componentId == null)
                return BadRequest();
            
            var components = _mapper.Map<ComponentDto>(_componentRepository.GetComponent(componentId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(components);

        }

        // POST: api/Component
        [HttpPost]
        public IActionResult PostComponent([FromQuery] int polcyId, [FromBody] CreateComponentDto createComponents)
        {
            if (createComponents == null)
                return BadRequest(ModelState);
            
            var component = _componentRepository.GetComponents()
                .Where(c => c.ComponentsId == createComponents.ComponentsId)
                .FirstOrDefault();

            if (component != null)
            {
                ModelState.AddModelError("","This component already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var componentMap = _mapper.Map<Components>(createComponents);
            //componentMap.Policy = _policyRepository.GetPolicy(polcyId);

            if (!_componentRepository.CreateComponent(componentMap))
            {
                ModelState.AddModelError("","Something went wrong whiles adding Component");
                return StatusCode(500, ModelState);
            }

            return Ok("Component has been be added successfully");
        }

        // // PUT: api/Component/5
        [HttpPut("{componentId}")]
        public IActionResult PutComponent(int componentId, [FromBody] CreateComponentDto updateComponent)
        {
            if (componentId == null)
                return BadRequest(ModelState);

            if (componentId != updateComponent.ComponentsId)
                return BadRequest(ModelState);

            if (!_componentRepository.ComponentExists(componentId))
                return BadRequest(ModelState);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var componentMap = _mapper.Map<Components>(updateComponent);

            if (!_componentRepository.UpdateComponent(componentMap))
            {
                ModelState.AddModelError("","Something went wrong whiles updating component.");
                return StatusCode(500, ModelState);
            }

            return Ok("Component has been updated successfully");
        }

        //DELETE: api/Component/5
        [HttpDelete("{componentId}")]
        public IActionResult Delete(int componentId)
        {
            if (componentId == null)
                return BadRequest(ModelState);
            
            if (!_componentRepository.ComponentExists(componentId))
                return BadRequest(ModelState);

            var componentToDelete = _componentRepository.GetComponent(componentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_componentRepository.DeleteComponent(componentToDelete))
            {
                ModelState.AddModelError("","Something went wrong whiles deleting component");
                return StatusCode(500, ModelState);
            }

            return Ok("Component has been deleted successfully");
        }
    }
}