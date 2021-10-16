﻿using AutoMapper;
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
            var classes = await _companyRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(classes));
        }


        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(string guid, CancellationToken cancellationToken = default)
        {
            var company = await _companyRepository.FindByGuidAsync(guid, cancellationToken);
            if (company is null)
                return NotFound();

            return Ok(_mapper.Map<CompanyDTO>(company));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyDTO dto, CancellationToken cancellationToken = default)
        {
            var admin = await _adminManager.FindByIdAsync(dto.AdminId);
            if (admin is null)
                return BadRequest(new { message = "Course is not found" });

            var company = _mapper.Map<Company>(dto);

            _companyRepository.Add(company);
            await _companyRepository.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(Get), new { company.Guid }, _mapper.Map<CompanyDTO>(company));
        }

        private static string GenerateHashTag()
        {
            
                return string.Format("01");
        }
    }
}