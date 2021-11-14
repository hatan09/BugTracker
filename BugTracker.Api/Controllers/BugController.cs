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
    public class BugController : ControllerBase
    {
        private readonly IBugRepository _bugRepository;
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public BugController(IBugRepository bugRepository, IAppRepository appRepository, IMapper mapper)
        {
            _bugRepository = bugRepository;
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var bugs = await _bugRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<BugDTO>>(bugs));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            var bug = await _bugRepository.FindByIdAsync(id, cancellationToken);
            if (bug is null)
                return NotFound();

            return Ok(_mapper.Map<BugDTO>(bug));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BugDTO dto, CancellationToken cancellationToken = default)
        {
            var app = await _appRepository.FindByIdAsync(dto.AppId, cancellationToken);
            if (app is null)
                return BadRequest(new { message = "App not found" });

            var bug = _mapper.Map<Bug>(dto);

            _bugRepository.Add(bug);
            await _bugRepository.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(Get), new { bug.Id }, _mapper.Map<BugDTO>(bug));
        }
    }
}
