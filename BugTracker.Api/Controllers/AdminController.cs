using AutoMapper;
using BugTracker.Api.DataObjects;
using BugTracker.Core.Entities;
using BugTracker.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminManager _adminManager;
        private readonly IMapper _mapper;

        public AdminController(AdminManager adminManager, IMapper mapper)
        {
            _adminManager = adminManager;
            _mapper = mapper;
        }


        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var admin = await _adminManager.FindByIdAsync(id);
            if (admin is null)
                return NotFound();

            return Ok(_mapper.Map<AdminDTO>(admin));
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdminDTO dto, CancellationToken cancellationToken = default)
        {
            var admin = _mapper.Map<Admin>(dto);


            var result = await _adminManager.CreateAsync(admin, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            // Add user to specified roles
            var addtoRoleResullt = await _adminManager.AddToRoleAsync(admin, "admin");
            if (!addtoRoleResullt.Succeeded)
            {
                return BadRequest("Fail to add role");
            }

            return CreatedAtAction(nameof(Get), new { admin.Id }, _mapper.Map<AdminDTO>(admin));
        }


        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AdminDTO dto)
        {
            var admin = await _adminManager.FindByIdAsync(dto.Id);
            if (admin is null || admin.IsDeleted)
                return NotFound();

            _mapper.Map(dto, admin);
            await _adminManager.UpdateAsync(admin);
            return NoContent();
        }


        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var admin = await _adminManager.FindByIdAsync(id);
            if (admin is null || admin.IsDeleted)
                return NotFound();

            admin.IsDeleted = true;
            await _adminManager.UpdateAsync(admin);
            return NoContent();
        }
    }
}
