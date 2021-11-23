using AutoMapper;
using BugTracker.Api.DataObjects;
using BugTracker.Contracts;
using BugTracker.Core.Entities;
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
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public ReportController(IReportRepository reportRepository, IAppRepository appRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _appRepository = appRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var reports = await _reportRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<ReportDTO>>(reports));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            var report = await _reportRepository.FindByIdAsync(id, cancellationToken);
            if (report is null)
                return NotFound();

            return Ok(_mapper.Map<ReportDTO>(report));
        }


        [HttpGet("{appId}")]
        public async Task<IActionResult> GetByApp(int appId, CancellationToken cancellationToken = default)
        {
            var app = await _appRepository.FindByIdAsync(appId, cancellationToken);
            if (app is null)
                return BadRequest(new { message = "App not found" });

            var reports = await _reportRepository.FindByApp(appId).ToListAsync(cancellationToken);

            return Ok(_mapper.Map<IEnumerable<ReportDTO>>(reports));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReportDTO dto, CancellationToken cancellationToken = default)
        {
            var app = await _appRepository.FindByIdAsync(dto.AppId, cancellationToken);
            if (app is null)
                return BadRequest(new { message = "App not found" });

            var report = _mapper.Map<Report>(dto);

            _reportRepository.Add(report);
            await _appRepository.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(Get), new { report.Id }, _mapper.Map<ReportDTO>(report));
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ReportDTO dto, CancellationToken cancellationToken = default)
        {
            var report = await _reportRepository.FindByIdAsync(dto.Id, cancellationToken);
            if (report is null)
                return NotFound();

            _mapper.Map(dto, report);
            _reportRepository.Update(report);
            await _reportRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var report = await _reportRepository.FindByIdAsync(id, cancellationToken);
            if (report is null)
                return NotFound();

            _reportRepository.Delete(report);
            await _reportRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
