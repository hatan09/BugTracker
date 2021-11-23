using AutoMapper;
using BugTracker.Api.DataObjects;
using BugTracker.Core.Entities;
using BugTracker.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly StaffManager _staffManager;
        private readonly IMapper _mapper;

        public StaffController(StaffManager staffManager, IMapper mapper)
        {
            _staffManager = staffManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var staffs = await _staffManager.FindAll().ToListAsync(cancellationToken);

            return Ok(_mapper.Map<IEnumerable<GetStaffDTO>>(staffs));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var staff = await _staffManager.FindByIdAsync(id);
            if (staff is null)
                return NotFound();

            return Ok(_mapper.Map<GetStaffDTO>(staff));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStaffDTO dto)
        {
            var staff = _mapper.Map<Staff>(dto);

            var result = await _staffManager.CreateAsync(staff, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            // Add user to specified roles
            var addtoRoleResullt = await _staffManager.AddToRoleAsync(staff, "staff");
            if (!addtoRoleResullt.Succeeded)
            {
                return BadRequest("Fail to add role");
            }

            return CreatedAtAction(nameof(Get), new { staff.Id }, _mapper.Map<GetStaffDTO>(staff));
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StaffDTO dto)
        {
            var staff = await _staffManager.FindByIdAsync(dto.Id);
            if (staff is null || staff.IsDeleted)
                return NotFound();

            _mapper.Map(dto, staff);
            await _staffManager.UpdateAsync(staff);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var staff = await _staffManager.FindByIdAsync(id);
            if (staff is null || staff.IsDeleted)
                return NotFound();

            staff.IsDeleted = true;
            await _staffManager.UpdateAsync(staff);
            return NoContent();
        }
    }
}
