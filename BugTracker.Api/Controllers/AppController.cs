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
        private readonly IStaffAppRepository _staffAppRepository;
        private readonly IMapper _mapper;

        public AppController(ICompanyRepository companyRepository, IAppRepository appRepository, StaffManager staffManager, IStaffAppRepository staffAppRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _appRepository = appRepository;
            _staffAppRepository = staffAppRepository;
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
                                    .Where(a => a.Id == staffId)
                                    .Include(a => a.StaffApps)
                                    .ThenInclude(sa => sa.App)
                                    .FirstOrDefaultAsync(cancellationToken);

            if (staff is null) return NotFound();

            var apps = staff.StaffApps.Select(sa => sa.App);

            return Ok(_mapper.Map<IEnumerable<AppDTO>>(apps));
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
            if (company is null)
                return BadRequest(new { message = "Company not found" });

            var app = _mapper.Map<App>(dto);

            _appRepository.Add(app);
            await _appRepository.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(Get), new { app.Id }, _mapper.Map<AppDTO>(app));
        }


        [HttpPost("{appId}")]
        public async Task<IActionResult> AssignStaff(int appId, List<string> staffIds, CancellationToken cancellationToken = default)
        {
            var app = await _appRepository.FindByIdAsync(appId, cancellationToken);
            if (app is null) return BadRequest(" App not found ");

            foreach(var staffId in staffIds)
            {
                var staff = await _staffManager.FindByIdAsync(staffId);

                if (app is not null && staff is not null)
                    _staffAppRepository.AssignStaff(app, staff);
            }
            
            await _staffAppRepository.SaveChangesAsync(cancellationToken);

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
        public async Task<IActionResult> UpdateLeader([FromBody] UpdateStaffAppModel model, CancellationToken cancellationToken = default)
        {
            var staffApp = await _staffAppRepository.FindByIdAsync(model.AppId, model.StaffId, cancellationToken);
            if (staffApp is null) return NotFound();

            staffApp.IsLeader = model.IsLeader;
            _staffAppRepository.Update(staffApp);
            await _staffAppRepository.SaveChangesAsync(cancellationToken);

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
