using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpGet("Iata", Name = "GetAeroporto")]
        public ActionResult<Model.Aeroporto> Get(string Iata)
        {
            var aeroporto = _aeroportoServicos.Get(Iata);

            if (aeroporto == null)
            {
                return NotFound("Aeroporto não encontrado.");
            }

            return aeroporto;
        }

        [HttpPost]
        public async Task<ActionResult<Model.Aeroporto>> Create(Model.Aeroporto aeroporto)
        {
            var verificacao = _aeroportoServicos.ChecarIata(aeroporto.Iata);

            if (verificacao == null)
            {
                aeroporto.Iata = aeroporto.Iata.ToUpper();
                aeroporto = await _aeroportoServicos.CreateAsync(aeroporto);
            }
            else
            {
                return Conflict("Não foi possível concluir o cadastro, pois o aeroporto informado já está cadastrado. Tente novamente.");
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
