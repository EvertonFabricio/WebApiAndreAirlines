using System.Collections.Generic;
using Voo.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

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

        [HttpGet("{id:length(24)}", Name = "GetVoo")]
        public ActionResult<Model.Voo> get(string id)
        {
            var voo = _vooService.Get(id);

            if (voo == null)
                return NotFound();

            return voo;
        }

        [HttpPost]
        public ActionResult<Model.Voo> Create(Model.Voo Voo)
        {
            _vooService.Create(Voo);
            return CreatedAtRoute("GetVoo", new { id = Voo.Id.ToString() }, Voo);
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
