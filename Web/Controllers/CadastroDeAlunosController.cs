using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route(template: "v1")]

    public class CadastroDeAlunosController : Controller
    {
        private readonly IAlunoBusiness _business;

        public CadastroDeAlunosController(IAlunoBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [Route(template: "alunos")]
        public async Task<IActionResult> GetListAsync()
        {
            var alunos = await _business.GetListAlunosAsync();

            if (alunos.Success == false)
                return BadRequest(alunos.Message);

            return Ok(alunos);
        }

        [HttpGet]
        [Route(template: "alunos/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var alunoId = await _business.GetAlunoByIdAsync(id);

            if (alunoId.Success == false)
                return BadRequest(alunoId.Message);

            return Ok(alunoId.Data);
        }

        [HttpGet("alunos/nome/{nome}")]
        public async Task<IActionResult> GetAlunoByNomeAsync(string nome)
        {
            var alunoNome = await _business.GetAlunoByNomeAsync(nome);

            if (alunoNome.Success == false)
                return BadRequest(alunoNome.Message);

            return Ok(alunoNome.Data);
        }

        [HttpGet("alunos/serie/{serie}")]
        public async Task<IActionResult> GetAlunoBySerieAsync(string serie)
        {
            var alunoSerie = await _business.GetAlunoBySerieAsync(serie);

            if (alunoSerie.Success == false)
                return BadRequest(alunoSerie.Message);

            return Ok(alunoSerie.Datas);
        }

        [HttpPost]
        [Route(template: "alunos")]
        public async Task<IActionResult> PostAsync([FromBody] Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                  .Select(e => e.ErrorMessage)
                                  .ToList();

                return BadRequest(errors);
            }

            var alunoCadastrar = await _business.PostAlunoAsync(aluno);

            if (alunoCadastrar.Success == false)
                return BadRequest(alunoCadastrar.Message);

            return Ok(alunoCadastrar.Message);
        }

        [HttpPut]
        [Route(template: "alunos/{id}")]
        public async Task<IActionResult> PutAsync(
                [FromBody] Aluno aluno,
                [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage)
                                   .ToList();

                return BadRequest(errors);
            }

            aluno.Matricula = id;

            var alunoEditar = await _business.PutAlunoAsync(aluno);

            if (alunoEditar.Success == false)
                return BadRequest(alunoEditar.Message);

            return Ok(alunoEditar.Message);
        }

        [HttpDelete]
        [Route(template: "alunos/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var alunoDeletar = await _business.DeleteAlunoAsync(id);

            if (alunoDeletar.Success == false)
                return BadRequest(alunoDeletar.Message);

            return Ok(alunoDeletar.Message);
        }
    }
}

