using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Passageiro.Servicos;

namespace Passageiro.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PassageiroController : ControllerBase
    {
        private readonly PassageiroServicos _passageiroServicos;

        public PassageiroController(PassageiroServicos passageiroServicos)
        {
            _passageiroServicos = passageiroServicos;
        }

        [HttpGet]
        [Authorize(Roles = "funcionario,gerente")]
        public ActionResult<List<Model.Passageiro>> Get() =>
            _passageiroServicos.Get();

        [HttpGet("CPF", Name = "GetPassageiro")]
        [Authorize(Roles = "funcionario,gerente")]
        public ActionResult<Model.Passageiro> Get(string CPF)
        {
            var passageiro = _passageiroServicos.Get(CPF);

            if (passageiro == null)
                return NotFound("Passageiro não Encontrado.");

            return passageiro;
        }

        [HttpPost]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<Model.Passageiro>> Create(Model.Passageiro passageiro)
        {
            var checar = _passageiroServicos.ChecarCpf(passageiro.Cpf);
            var validar = _passageiroServicos.ValidarCpf(passageiro.Cpf);
        
            if (validar == true)
            {
                if (checar == null)
                {
                    passageiro = await _passageiroServicos.CreateAsync(passageiro);
                }
                else
                {
                    return Conflict("Passageiro já está cadastrado");
                }
            }
            else
            {
                return Conflict("CPF invalido");
            }

            return CreatedAtRoute("GetPassageiro", new { id = passageiro.Id.ToString() }, passageiro);
        }

        [HttpPut("{id:length(24)}")]
        [Authorize(Roles = "gerente")]
        public IActionResult Update(string id, Model.Passageiro passageiro)
        {
            if (passageiro == null)
                return NotFound();

            _passageiroServicos.Update(id, passageiro);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = "gerente")]
        public IActionResult Delete(string id)
        {
            var passageiro = _passageiroServicos.Get(id);

            if (passageiro == null)
                return NotFound();

            _passageiroServicos.Remove(passageiro.Id);

            return NoContent();
        }
    }
}
