using System.Collections.Generic;
using Classe.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Classe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private readonly ClasseServicos _classeServicos;

        public ClasseController(ClasseServicos classeServicos)
        {
            _classeServicos = classeServicos;
        }

        [HttpGet]
        public ActionResult<List<Model.Classe>> Get() =>
            _classeServicos.Get();

        [HttpGet("{Codigo}", Name = "GetClasse")]
        public ActionResult<Model.Classe> Get(string Codigo)
        {
            var classe = _classeServicos.Get(Codigo);

            if (classe == null)
            {
                return NotFound("Classe não se encontra cadastrada.");
            }

            return classe;
        }

        [HttpPost]
        public ActionResult<Model.Classe> Create(Model.Classe classe)
        {
           _classeServicos.Create(classe);
            return CreatedAtRoute("GetClasse", new { codigo = classe.Codigo.ToString() }, classe);
        }

        [HttpPut("{Codigo}")]
        public IActionResult Update(string Codigo, Model.Classe upClasse)
        {
            var classe = _classeServicos.Get(Codigo);

            if (classe == null)
            {
                return NotFound();
            }

            _classeServicos.Update(Codigo, upClasse);

            return NoContent();
        }

        [HttpDelete("{Codigo}")]
        public IActionResult Delete(string Codigo)
        {
            var classe = _classeServicos.Get(Codigo);

            if (classe == null)
            {
                return NotFound();
            }

            _classeServicos.Remove(classe.Id);

            return NoContent();
        }
    }
}
