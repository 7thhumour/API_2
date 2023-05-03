using APIII.Models;
using APIII.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly IRepository _repository;

        public TripController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("AddTripGuide/{guideNum}")]
        public async Task<IActionResult> AddTripGuide(string guideNum, TripViewModel tvm)
        {
            var trip = new Trip { TripName = tvm.TripName, Startlocation = tvm.Startlocation, State = tvm.State, Distance = tvm.Distance, MaxGroupSize = tvm.MaxGroupSize, Type = tvm.Type, Season = tvm.Season };

            var guide = await _repository.GetGuideAsync(guideNum);
            if (guide == null) return NotFound($"The guide does not exist");

            try
            {
                trip.Guides.Add(guide);
                _repository.Add(trip);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Invalid transaction");
            }

            return Ok();
        }

        [HttpPut]
        [Route("EditTripGuide/{guideNum}/{tripId}")]
        public async Task<IActionResult> EditTripGuide(string guideNum, int tripId)
        {
            var trip = await _repository.GetTripAsync(tripId);
            if (trip == null) return NotFound($"The trip does not exist");

            var guide = await _repository.GetGuideAsync(guideNum);
            if (guide == null) return NotFound($"The guide does not exist");

            try
            {
                var guidesToRemove = trip.Guides.ToList();
                guidesToRemove.ForEach(g => trip.Guides.Remove(g));

                trip.Guides.Add(guide);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Invalid transaction");
            }

            return Ok();
        }
    }   
}

