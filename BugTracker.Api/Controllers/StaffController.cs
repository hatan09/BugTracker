using AutoMapper;
using BugTracker.Api.DataObjects;
using BugTracker.Contracts;
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
        private readonly IAppRepository _appRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IBugRepository _bugRepository;
        private readonly IMapper _mapper;

        public StaffController(StaffManager staffManager, IAppRepository appRepository, ICompanyRepository companyRepository, IBugRepository bugRepository, IMapper mapper)
        {
            _staffManager = staffManager;
            _appRepository = appRepository;
            _companyRepository = companyRepository;
            _bugRepository = bugRepository;
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


        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetByCompanyId(int companyId, CancellationToken cancellationToken)
        {
            
            var company = await _companyRepository.FindAll()
                .Where(cpn => cpn.Id == companyId)
                .Include(cpn => cpn.Staffs)
                .FirstOrDefaultAsync(cancellationToken);
            if (company is null)
                return BadRequest(new { message = "Company not found" });


            return Ok(_mapper.Map<IEnumerable<StaffDTO>>(company.Staffs));
        }


        [HttpGet("{appId}")]
        public async Task<IActionResult> GetByAppId(int appId, CancellationToken cancellationToken)
        {
            var app = await _appRepository.FindAll()
                .Where(app => app.Id == appId)
                .Include(app => app.Staffs)
                .FirstOrDefaultAsync(cancellationToken);

            if (app is null)
                return BadRequest(new { message = "App not found" });

            return Ok(_mapper.Map<IEnumerable<StaffDTO>>(app.Staffs));
        }


        [HttpGet("{bugId}")]
        public async Task<IActionResult> GetByBugId(int bugId, CancellationToken cancellationToken)
        {
            var bug = await _bugRepository.FindAll()
                .Where(bug => bug.Id == bugId)
                .Include(bug => bug.Staffs)
                .FirstOrDefaultAsync(cancellationToken);

            if (bug is null)
                return BadRequest(" No Bug Found ");

            return Ok(_mapper.Map<IEnumerable<GetStaffDTO>>(bug.Staffs));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStaffDTO dto, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.FindByIdAsync(dto.CompanyId, cancellationToken);
            if (company is null)
                return BadRequest(new { message = "Company not found" });

            var staff = _mapper.Map<Staff>(dto);
            staff.Company = company;

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
