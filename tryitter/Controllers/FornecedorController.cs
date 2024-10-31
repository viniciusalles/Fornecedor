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


        [AllowAnonymous]
        [HttpGet("search/{id}")]
        public async Task<IActionResult> GetFornecedorById(int id)
        {
            var fornecedor = await _fornecedorRepository.GetFornecedorById(id);

            if (fornecedor is null)
            {
                return NotFound("Fornecedor not found");
            }

            return Ok(fornecedor);
        }

        [AllowAnonymous]
        [HttpGet("search/all")]
        public async Task<IActionResult> GetFornecedores()
        {
            var fornecedores = await _fornecedorRepository.GetFornecedores();

            if (fornecedores is null)
            {
                return NotFound("Fornecedores not found");
            }

            return Ok(fornecedores);
        }



        [AllowAnonymous]
        [HttpPost("create")]
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

        [AllowAnonymous]
        [HttpPut("update/{id}")]
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

        [AllowAnonymous]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
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