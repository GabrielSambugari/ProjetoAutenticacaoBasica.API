using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAutenticacaoBasica.API.Data;
using ProjetoAutenticacaoBasica.API.Models;
using ProjetoAutenticacaoBasica.API.Models.DTOs;

namespace ProjetoAutenticacaoBasica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageirosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PassageirosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CriarPassageiro(CriarPassageiroDto dto)
        {
            var novoPassageiro = new Passageiro
            {
                Codigo = dto.Cpf,
                Nome = dto.Nome
            };

            _context.Codigo.Add(novoPassageiro);
            await _context.SaveChangesAsync();

            return Ok("Passageiro criado com sucesso");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodigoInfoDto>>>
            GetPassageiros([FromQuery]string? nome)
        {
            var passageiros = await _context.Codigo
                .AsNoTracking()
                .Where(p => string.IsNullOrEmpty(nome) || p.Nome.Contains(nome))
                .OrderBy(p => p.Nome)
                .Select(p => new CodigoInfoDto
                {
                    Id = p.Id,
                    Nome = p.Nome
                }).ToListAsync();

            return Ok(passageiros);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<CodigoInfoDto>>
            GetPassageiroPorCpf(string cpf)
        {
            var passageiro = await _context.Codigo
                .AsNoTracking()
                .Where(p => p.Codigo == cpf)
                .Select(p => new CodigoInfoDto
                {
                    Id = p.Id,
                    Nome = p.Nome
                }).FirstOrDefaultAsync();

            if(passageiro is null)
            {
                return NotFound(new { mensagem = "Passageiro não encontrado" });
            }
            return Ok(passageiro);

        }

    }
}
