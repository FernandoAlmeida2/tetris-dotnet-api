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

        [HttpGet]
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
            ? Ok("Usuário adicionado com sucesso!")
            : BadRequest("Erro ao salvar o usuário");
        }
    }
}