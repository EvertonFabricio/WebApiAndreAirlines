using System.Collections.Generic;
using Aeronave.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aeronave.Controllers
{
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
        public ActionResult<List<Model.Aeronave>> Get() =>
            _aeronaveServicos.Get();

        [HttpGet("{id:length(24)}", Name = "GetAeronave")]
        public ActionResult<Model.Aeronave> Get(string id)
        {
            var aeronave = _aeronaveServicos.Get(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            return aeronave;
        }

        [HttpPost]
        public ActionResult<Model.Aeronave> Create(Model.Aeronave aeronave)
        {
            _aeronaveServicos.Create(aeronave);

            return CreatedAtRoute("GetAeronave", new { id = aeronave.Id.ToString() }, aeronave);
        }

        [HttpPut("{id:length(24)}")]
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
