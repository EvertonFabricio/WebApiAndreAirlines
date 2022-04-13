using System.Collections.Generic;
using Voo.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Threading.Tasks;

namespace Voo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VooController : ControllerBase
    {
        private readonly VooServicos _vooService;

        public VooController(VooServicos vooService)
        {
            _vooService = vooService;
        }

        [HttpGet]
        public ActionResult<List<Model.Voo>> Get() =>
            _vooService.Get();

        [HttpGet("{NumeroVoo}", Name = "GetVoo")]
        public ActionResult<Model.Voo> get(string NumeroVoo)
        {
            var voo = _vooService.Get(NumeroVoo);

            if (voo == null)
                return NotFound();

            return voo;
        }

     
        [HttpPost]
        public async Task<ActionResult<Model.Voo>> CreateAsync(Model.Voo voo)
        {
            voo = await _vooService.CreateAsync(voo);
            voo.Origem.Iata = voo.Origem.Iata.ToUpper();
            voo.Destino.Iata = voo.Destino.Iata.ToUpper();
            voo.Aeronave.Registro = voo.Aeronave.Registro.ToUpper();

            return CreatedAtRoute("GetVoo", new { numeroVoo = voo.NumeroVoo.ToString() }, voo);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Model.Voo voo)
        {
           // var voo = _vooService.Get(id);

            if (voo == null)
                return NotFound();

            _vooService.Update(id, voo);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var voo = _vooService.Get(id);

            if (voo == null)
                return NotFound();

            _vooService.Remove(voo.Id);

            return NoContent();
        }
    }
}
