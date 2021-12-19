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
    public class CompanyController : ControllerBase
    {
        private readonly AdminManager _adminManager;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(AdminManager adminManager, ICompanyRepository companyRepository, IMapper mapper)
        {
            _adminManager = adminManager;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var companies = await _companyRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(companies));
        }


        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(Guid guid, CancellationToken cancellationToken = default)
        {
            var company = await _companyRepository.FindByGuidAsync(guid, cancellationToken);
            if (company is null)
                return NotFound();

            return Ok(_mapper.Map<CompanyDTO>(company));
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> SearchByName(string name, CancellationToken cancellationToken = default)
        {
            var companies = await _companyRepository.SearchByName(name).ToListAsync(cancellationToken);
            if (companies is null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(companies));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyDTO dto, CancellationToken cancellationToken = default)
        {
            var admin = await _adminManager.FindByIdAsync(dto.AdminId);
            if (admin is null || admin.IsDeleted)
                return BadRequest(new { message = "Admin not found or deleted" });

            var company = _mapper.Map<Company>(dto);
            company.IsDeleted = false;

            _companyRepository.Add(company);
            await _companyRepository.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(Get), new { company.Guid }, _mapper.Map<CompanyDTO>(company));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CompanyDTO dto, CancellationToken cancellationToken = default)
        {
            var company = await _companyRepository.FindByGuidAsync(dto.Guid, cancellationToken);
            if (company is null || company.IsDeleted)
                return BadRequest(new { message = "Company not found or deleted" });

            _mapper.Map(dto, company);
            _companyRepository.Update(company);
            await _companyRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }


        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(Guid guid, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.FindByGuidAsync(guid, cancellationToken);
            if (company is null || company.IsDeleted)
                return BadRequest(new { message = "Company not found or deleted" });

            company.IsDeleted = true;
            _companyRepository.Update(company);
            await _companyRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
