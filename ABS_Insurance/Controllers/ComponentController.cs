using ABS_Insurance.Data.Dto;
using ABS_Insurance.Interface;
using ABS_Insurance.Model;
using ABS_Insurance.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace ABS_Insurance.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]

    public class ComponentController : ControllerBase
    {
        private readonly IComponentRepository _componentRepository;
        private readonly IMapper _mapper;

        public ComponentController(IComponentRepository componentRepository, IMapper mapper)
        {
            _componentRepository = componentRepository;
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
        // [HttpPost]
        // public IActionResult PostPolicy([FromBody] Components)
        // {
        // }

        // // PUT: api/Component/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // DELETE: api/Component/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}