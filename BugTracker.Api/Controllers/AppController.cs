using AutoMapper;
using BugTracker.Api.DataObjects;
using BugTracker.Api.Models;
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
    public class AppController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IAppRepository _appRepository;
        private readonly StaffManager _staffManager;
        private readonly IMapper _mapper;

        public AppController(ICompanyRepository companyRepository, IAppRepository appRepository, StaffManager staffManager, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _appRepository = appRepository;
            _staffManager = staffManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var apps = await _appRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<AppDTO>>(apps));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            var app = await _appRepository.FindByIdAsync(id, cancellationToken);
            if (app is null)
                return NotFound();

            return Ok(_mapper.Map<AppDTO>(app));
        }


        [HttpGet("{staffId}")]
        public async Task<IActionResult> GetByStaffId (string staffId, CancellationToken cancellationToken = default)
        {
            var staff = await _staffManager.FindAll()
                .Where(stf => stf.Id.Equals(staffId))
                .Include(stf => stf.Apps)
                .FirstOrDefaultAsync(cancellationToken);

            if (staff is null || staff.IsDeleted)
                return BadRequest(new { message = "Staff not found or deleted" });

            return Ok(_mapper.Map<IEnumerable<AppDTO>>(staff.Apps));
        }


        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetByCompanyId(int companyId, CancellationToken cancellationToken = default)
        {
            var company = await _companyRepository.FindAll()
                .Where(cpn => cpn.Id == companyId)
                .Include(cpn => cpn.Apps)
                .FirstOrDefaultAsync(cancellationToken);

            if (company is null || company.IsDeleted)
                return BadRequest(new { message = "Company not found or deleted" });

            return Ok(_mapper.Map<IEnumerable<AppDTO>>(company.Apps));
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> SearchByName(string name, CancellationToken cancellationToken = default)
        {
            var apps = await _appRepository.SearchByName(name).ToListAsync(cancellationToken);
            if (apps is null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<AppDTO>>(apps));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppDTO dto, CancellationToken cancellationToken = default)
        {
            var company = await _companyRepository.FindByIdAsync(dto.CompanyId, cancellationToken);
            if (company is null || company.IsDeleted)
                return BadRequest(new { message = "Company not found" });

            var app = _mapper.Map<App>(dto);
            app.IsDeleted = false;

            _appRepository.Add(app);
            await _appRepository.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(Get), new { app.Id }, _mapper.Map<AppDTO>(app));
        }


        [HttpPut]
        public async Task<IActionResult> AssignStaff(UpdateStaffAppModel model, CancellationToken cancellationToken = default)
        {
            var app = await _appRepository.FindAll()
                .Where(app => app.Id == model.AppId)
                .Include(app => app.Staffs)
                .FirstOrDefaultAsync(cancellationToken);
            if (app is null || app.IsDeleted)
                return BadRequest(new { message = "App not found or deleted" });

            foreach(var id in model.StaffIds)
            {
                var staff = await _staffManager.FindByIdAsync(id);
                if (staff is not null)
                    if (!staff.IsDeleted)
                        app.Staffs.Add(staff);
            }

            _appRepository.Update(app);
            await _appRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> RemoveStaff(UpdateStaffAppModel model, CancellationToken cancellationToken = default)
        {
            var app = await _appRepository.FindAll()
                .Where(app => app.Id == model.AppId)
                .Include(app => app.Staffs)
                .FirstOrDefaultAsync(cancellationToken);
            if (app is null || app.IsDeleted)
                return BadRequest(new { message = "App not found or deleted" });

            foreach (var id in model.StaffIds)
            {
                var staff = await _staffManager.FindByIdAsync(id);
                if (staff is not null)
                    app.Staffs.Remove(staff);
            }

            _appRepository.Update(app);
            await _appRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AppDTO dto, CancellationToken cancellationToken = default)
        {
            var app = await _appRepository.FindByIdAsync(dto.Id, cancellationToken);
            if (app is null || app.IsDeleted)
                return NotFound();

            _mapper.Map(dto, app);
            _appRepository.Update(app);
            await _appRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateLeader([FromBody] UpdateLeaderModel model, CancellationToken cancellationToken = default)
        {
            var app = await _appRepository.FindByIdAsync(model.AppId);
            if(app is null || app.IsDeleted)
                return BadRequest(new
                {
                    message = "App not found or deleted"
                });

            app.LeaderId = model.LeaderId;

            _appRepository.Update(app);
            await _appRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var app = await _appRepository.FindByIdAsync(id, cancellationToken);
            if (app is null || app.IsDeleted)
                return NotFound();

            app.IsDeleted = true;
            _appRepository.Update(app);
            await _appRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
