using Microsoft.AspNetCore.Mvc;
using tetris_api.Models;
using tetris_api.Repositories.Interfaces;

namespace tetris_api.Controllers
{
    [ApiController]
    [Route("api/results")]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository _repository;
        public ResultController(IResultRepository repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllResults()
        {
            var response = await _repository.findAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _repository.findOne(id);
            return response != null ? Ok(response) : NotFound("Result not found");
        }

        [HttpPost]
        public async Task<IActionResult> Post(ResultModel resultModel)
        {
            _repository.save(resultModel);
            return await _repository.SaveChangesAsync()
            ? Content("Result added succesfully!")
            : BadRequest("Save result error");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ResultModel resultModel)
        {
            var result = await _repository.findOne(id);
            if(result == null) return NotFound("Result not found");
            result.name = resultModel.name;
            result.score = resultModel.score;
            result.speed= resultModel.speed;
            _repository.update(result);
            return await _repository.SaveChangesAsync()
            ? Content("Result updated succesfully!")
            : BadRequest("Update result error");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.findOne(id);
            if(result == null) return NotFound("Result not found");
            _repository.delete(result);
            return await _repository.SaveChangesAsync()
            ? Content("Result deleted succesfully!")
            : BadRequest("Delete result error");
        }
    }
}