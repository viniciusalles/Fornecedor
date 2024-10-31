using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using tryitter.Interfaces;
using tryitter.Models;

namespace tryitter.Controllers
{
    [ApiController]
    [Route("fornecedor")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetFornecedores()
        {
            var fornecedores = await _fornecedorRepository.GetFornecedores();

            if (!(fornecedores?.Any() == true))
            {
                return NotFound("Fornecedor not found");
            }

            return Ok(fornecedores);
        }

        [Authorize]
        [HttpGet("posts")]
        public async Task<IActionResult> GetFornecedoresWithPosts()
        {
            var fornecedores = await _fornecedorRepository.GetFornecedoresWithPosts();

            if (!(fornecedores?.Any() == true))
            {
                return NotFound("Fornecedor not found");
            }

            return Ok(fornecedores);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFornecedorById(int id)
        {
            var fornecedor = await _fornecedorRepository.GetFornecedorById(id);

            if (fornecedor is null)
            {
                return NotFound("Fornecedor not found");
            }

            return Ok(fornecedor);
        }

        [Authorize]
        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetStudentByIdWithPost(int id)
        {
            var fornecedor = await _fornecedorRepository.GetFornecedorByIdWithPost(id);

            if (fornecedor is null)
            {
                return NotFound("Fornecedor not found");
            }

            return Ok(fornecedor);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateFornecedor([FromBody] Fornecedor fornecedor)
        {
            var fornecedorByRazaoSocial = await _fornecedorRepository.GetFornecedorByRazaoSocial(fornecedor.RazaoSocial);

            if (fornecedorByRazaoSocial is not null)
            {
                return NotFound("Fornecedor already exist");
            }

            var newFornecedor = await _fornecedorRepository.CreateFornecedor(fornecedor);

            return Created("", $"{newFornecedor.NomeFantasia} registered successfully!");
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromBody] Fornecedor fornecedor, int id)
        {
            var fornecedorById = await _fornecedorRepository.GetFornecedorById(id);

            if (fornecedorById is null)
            {
                return NotFound("Fornecedor not found");
            }

            var updatedFornecedor = await _fornecedorRepository.UpdateFornecedor(fornecedor, id);

            return Ok($"{updatedFornecedor.NomeFantasia} successfully updated!");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {          
            var fornecedorById = await _fornecedorRepository.GetFornecedorById(id);

            if (fornecedorById is null)
            {
                return NotFound("Fornecedor not found");
            }

            _fornecedorRepository.DeleteFornecedor(id);

            return NoContent();
        }
    }
}