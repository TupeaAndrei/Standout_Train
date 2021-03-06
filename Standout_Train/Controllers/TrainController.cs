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
    public class TrainController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public TrainController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainById([FromRoute]int id)
        {
            TrainDTO train = new();
            try
            {
                train = _mapper.Map<TrainDTO>(await unitOfWork.Trains.GetByIdAsync(id));
                await unitOfWork.Complete();
                return Json(train);
            }
            catch (DbUpdateException)
            {
                return NotFound();
            }
        }

       

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrain([FromRoute]int id)
        {
            try
            {
                var train = await unitOfWork.Trains.GetByIdAsync(id);
                await unitOfWork.Trains.Remove(train);
            }
            catch(ArgumentException)
            {
                return NotFound();
            }
            catch(DbUpdateException)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetTrains()
        {
            List<TrainDTO> dtos = new();
            try
            {
                dtos = _mapper.Map<List<TrainDTO>>(await unitOfWork.Trains.GetAllAsync());
            }
            catch(DbUpdateException)
            {
                return BadRequest();
            }

            return Ok(dtos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrain([FromRoute]int id,[FromBody]TrainDTO trainDTO)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            try
            {
                var train = await unitOfWork.Trains.GetByIdAsync(id);
                if (train == null)
                {
                    return NotFound();
                }
                var entity = _mapper.Map<Train>(trainDTO);
                await unitOfWork.Trains.Update(id, entity);
            }
            catch(ArgumentException)
            {
                return NotFound();
            }
            catch(DbUpdateException)
            {
                return BadRequest();
            }
            return Json(trainDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrain([FromBody]TrainDTO trainDTO)
        {
            try
            {
                if (trainDTO == null)
                {
                    return BadRequest();
                }
                var entity = _mapper.Map<Train>(trainDTO);
                await unitOfWork.Trains.AddAsync(entity);
            }
            catch(DbUpdateException)
            {
                throw;
            }
            return Ok();
        }

        [HttpGet("/cities/{startCity}")]
        public async Task<IActionResult> StartInCity([FromRoute]string startCity)
        {
            try
            {
                if (startCity == null)
                {
                    return BadRequest();
                }
                IEnumerable<Train>? results = await unitOfWork.Trains.GetAllTrainsThatStartFromCity(startCity);
                List<TrainDTO> trains = _mapper.Map<List<TrainDTO>>(results);
                return Json(trains);
                
            }catch(DbUpdateException)
            {
                return BadRequest();
            }
        }

        [HttpGet("/cities/{endCity}")]
        public async Task<IActionResult> EndInCity([FromRoute]string endCity)
        {
            try
            {
                if (endCity == null)
                {
                    return BadRequest();
                }
                IEnumerable<Train>? results = await unitOfWork.Trains.GetAllTrainsThatStopInCity(endCity);
                List<TrainDTO> trains = _mapper.Map<List<TrainDTO>>(results);
                return Json(trains);
            }catch(DbUpdateException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
