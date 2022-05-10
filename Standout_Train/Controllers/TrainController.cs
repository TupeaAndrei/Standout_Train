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
        public async Task<ActionResult<TrainDTO>> GetTrainById(int id)
        {
            TrainDTO train = new();
            try
            {
                train = _mapper.Map<TrainDTO>(await unitOfWork.Trains.GetByIdAsync(id));
                await unitOfWork.Complete();
            }
            catch (DbUpdateException)
            {
                return NotFound();
            }
            return Json(train);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
