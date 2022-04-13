using System.Collections.Generic;
using Usuario.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServicos _usuarioServicos;

        public UsuarioController(UsuarioServicos usuarioServicos)
        {
            _usuarioServicos = usuarioServicos;
        }

        [HttpGet]
        public ActionResult<List<Model.Usuario>> Get() =>
            _usuarioServicos.Get();

        [HttpGet("{id:length(24)}", Name = "GetUsuario")]
        public ActionResult<Model.Usuario> Get(string id)
        {
            var usuario = _usuarioServicos.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

       
        [HttpPost]
        public ActionResult<Model.Usuario> Create(Model.Usuario usuario)
        {
            _usuarioServicos.Create(usuario);

            return CreatedAtRoute("GetUsuario", new { id = usuario.Id.ToString() }, usuario);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Model.Usuario upUsuario)
        {
            var usuario = _usuarioServicos.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioServicos.Update(id, upUsuario);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var usuario = _usuarioServicos.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioServicos.Remove(usuario.Id);

            return NoContent();
        }
    }
}
