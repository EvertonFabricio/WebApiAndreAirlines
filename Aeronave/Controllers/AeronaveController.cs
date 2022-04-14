using System.Collections.Generic;
using Aeronave.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Aeronave.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AeronaveController : ControllerBase
    {
        private readonly AeronaveServicos _aeronaveServicos;

        public AeronaveController(AeronaveServicos aeronaveServicos)
        {
            _aeronaveServicos = aeronaveServicos;
        }

        [HttpGet]
        [Authorize(Roles = "funcionario,gerente")]
        public ActionResult<List<Model.Aeronave>> Get() =>
            _aeronaveServicos.Get();

       // [HttpGet("{id:length(24)}", Name = "GetAeronave")]
        [HttpGet("{Registro}", Name = "GetAeronave")]
        [Authorize(Roles = "funcionario,gerente")]
        public ActionResult<Model.Aeronave> Get(string registro)
        {
            var aeronave = _aeronaveServicos.Get(registro.ToUpper());

            if (aeronave == null)
            {
                return NotFound("Aeronave não está cadastrada.");
            }

            return aeronave;
        }

        [HttpPost]
        [Authorize(Roles = "gerente")]
        public ActionResult<Model.Aeronave> Create(Model.Aeronave aeronave)
        {
            var registro = _aeronaveServicos.ChecarRegistro(aeronave.Registro);

            if (registro == null)
            {
                _aeronaveServicos.Create(aeronave);
            }
            else
            {
                return Conflict("Cadastro não concluído. Registro da Aeronave já encontra-se cadastrado. Tente novamente.");
            }

            return CreatedAtRoute("GetAeronave", new { registro = aeronave.Registro.ToString() }, aeronave);
        }

        [HttpPut("{id:length(24)}")]
        [Authorize(Roles = "gerente")]

        public IActionResult Update(string id, Model.Aeronave upAeronave)
        {
            var aeronave = _aeronaveServicos.Get(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            _aeronaveServicos.Update(id, upAeronave);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = "gerente")]
        public IActionResult Delete(string id)
        {
            var aeronave = _aeronaveServicos.Get(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            _aeronaveServicos.Remove(aeronave.Id);

            return NoContent();
        }
    }
}
