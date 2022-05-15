using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Standout_Train.BL.Interfaces;
using Standout_Train.DAL.Models;
using Standout_Train.TL.DTOs;

namespace Standout_Train.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public CountyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainById([FromRoute] int id)
        {
            CountyDTO county = new();
            try
            {
                county = _mapper.Map<CountyDTO>(await unitOfWork.County.GetByIdAsync(id));
                await unitOfWork.Complete();
                return Json(county);
            }
            catch (DbUpdateException)
            {
                return NotFound();
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                DAL.Models.County? county = await unitOfWork.County.GetByIdAsync(id);
                await unitOfWork.County.Remove(county);
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
                List<CountyDTO> dtos = new();
                dtos = _mapper.Map<List<CountyDTO>>(await unitOfWork.County.GetAllAsync());
                return Json(dtos);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CountyDTO countyDTO)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            try
            {
                County? county = await unitOfWork.County.GetByIdAsync(id);
                if (county == null)
                {
                    return NotFound();
                }
                County? entity = _mapper.Map<County>(countyDTO);
                await unitOfWork.County.Update(id, entity);
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
        public async Task<IActionResult> Create([FromBody] CountyDTO countyDTO)
        {
            try
            {
                if (countyDTO == null)
                {
                    return BadRequest();
                }
                var entity = _mapper.Map<County>(countyDTO);
                await unitOfWork.County.AddAsync(entity);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
