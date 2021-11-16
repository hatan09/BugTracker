using AutoMapper;
using BugTracker.Api.DataObjects;
using BugTracker.Core.Entities;
using BugTracker.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerManager _customerManager;
        private readonly IMapper _mapper;

        public CustomerController(CustomerManager customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var customers = await _customerManager.FindAll().ToListAsync(cancellationToken);

            return Ok(_mapper.Map<IEnumerable<GetCustomerDTO>>(customers));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _customerManager.FindByIdAsync(id);
            if (customer is null)
                return NotFound();

            return Ok(_mapper.Map<GetCustomerDTO>(customer));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDTO dto, CancellationToken cancellationToken = default)
        {
            var customer = _mapper.Map<Customer>(dto);
            

            var result = await _customerManager.CreateAsync(customer, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            // Add user to specified roles
            var addtoRoleResullt = await _customerManager.AddToRoleAsync(customer, "customer");
            if (!addtoRoleResullt.Succeeded)
            {
                return BadRequest("Fail to add role");
            }

            return CreatedAtAction(nameof(Get), new { customer.Id }, _mapper.Map<GetCustomerDTO>(customer));
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerDTO dto)
        {
            var customer = await _customerManager.FindByIdAsync(dto.Id);
            if (customer is null || customer.IsDeleted)
                return NotFound();

            _mapper.Map(dto, customer);
            await _customerManager.UpdateAsync(customer);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var customer = await _customerManager.FindByIdAsync(id);
            if (customer is null || customer.IsDeleted)
                return NotFound();

            customer.IsDeleted = true;
            await _customerManager.UpdateAsync(customer);
            return NoContent();
        }
    }
}
