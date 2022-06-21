using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Standout_Train.BL.Interfaces;
using Standout_Train.DAL.Models;
using Standout_Train.TL.DTOs;

namespace Standout_Train.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public ReportController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            ReportDTO report = new();
            try
            {
                report = _mapper.Map<ReportDTO>(await unitOfWork.Reports.GetByIdAsync(id));
                await unitOfWork.Complete();
            }
            catch (DbUpdateException)
            {
                return NotFound();
            }
            return Json(report);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                DAL.Models.Report? reports = await unitOfWork.Reports.GetByIdAsync(id);
                await unitOfWork.Reports.Remove(reports);
                return Ok();
            }
            catch (ArgumentException ag)
            {
                return NotFound(ag.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<ReportDTO> dtos = new();
                dtos = _mapper.Map<List<ReportDTO>>(await unitOfWork.Reports.GetAllAsync());
                return Json(dtos);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ReportDTO reportDTO)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            try
            {
                DAL.Models.Report? report = await unitOfWork.Reports.GetByIdAsync(id);
                if (report == null)
                {
                    return NotFound();
                }
                Report? entity = _mapper.Map<Report>(reportDTO);
                await unitOfWork.Reports.Update(id, entity);
                return Json(entity);
            }
            catch (ArgumentException ag)
            {
                return NotFound(ag.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReportDTO reportDTO)
        {
            try
            {
                if (reportDTO == null)
                {
                    return BadRequest();
                }
                var entity = _mapper.Map<Report>(reportDTO);
                await unitOfWork.Reports.AddAsync(entity);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
