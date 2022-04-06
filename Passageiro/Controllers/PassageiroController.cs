using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Passageiro.Servicos;

namespace Passageiro.Controllers
{
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
        public ActionResult<List<Model.Passageiro>> Get() =>
            _passageiroServicos.Get();

        [HttpGet("{id:length(24)}", Name = "GetPassageiro")]
        public ActionResult<Model.Passageiro> Get(string id)
        {
            var passageiro = _passageiroServicos.Get(id);

            if (passageiro == null)
                return NotFound();

            return passageiro;
        }

        [HttpPost]
        public ActionResult<Model.Passageiro> Create(Model.Passageiro passageiro)
        {
            var checar = _passageiroServicos.ChecarCpf(passageiro.Cpf);
            var validar = _passageiroServicos.ValidarCpf(passageiro.Cpf);

            if (validar == true)
            {
                if (checar == null)
                {
                    _passageiroServicos.Create(passageiro);
                }
                else
                {
                    return Conflict("CPF já esta cadastrado");
                }
            }
            else
            {
                return Conflict("CPF invalido");
            }

            return CreatedAtRoute("GetPassageiro", new { id = passageiro.Id.ToString() }, passageiro);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Model.Passageiro passageiro)
        {
            if (passageiro == null)
                return NotFound();

            _passageiroServicos.Update(id, passageiro);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
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
