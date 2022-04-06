using System.Collections.Generic;
using Aeroporto.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aeroporto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeroportoController : ControllerBase
    {
        private readonly AeroportoServicos _aeroportoServicos;

        public AeroportoController(AeroportoServicos aeroportoServicos)
        {
            _aeroportoServicos = aeroportoServicos;
        }

        [HttpGet]
        public ActionResult<List<Model.Aeroporto>> Get() =>
            _aeroportoServicos.Get();

        [HttpGet("{id:length(24)}", Name = "GetAeroporto")]
        public ActionResult<Model.Aeroporto> Get(string id)
        {
            var aeroporto = _aeroportoServicos.Get(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            return aeroporto;
        }

        [HttpPost]
        public ActionResult<Model.Aeroporto> Create(Model.Aeroporto aeroporto)
        {
            var codigo = _aeroportoServicos.ChecarIata(aeroporto.Iata);

            if (codigo == null)
            {
                _aeroportoServicos.Create(aeroporto);
            }
            else
            {
                return NotFound();
            }


            return CreatedAtRoute("GetAeroporto", new { id = aeroporto.Id.ToString() }, aeroporto);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Model.Aeroporto upAeroporto)
        {
            var aeroporto = _aeroportoServicos.Get(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            _aeroportoServicos.Update(id, upAeroporto);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var aeroporto = _aeroportoServicos.Get(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            _aeroportoServicos.Remove(aeroporto.Id);

            return NoContent();
        }
    }
}
