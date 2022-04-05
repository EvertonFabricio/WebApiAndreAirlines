using System.Collections.Generic;
using Reserva.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Reserva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaServicos _reservaServicos;

        public ReservaController(ReservaServicos reservaServicos)
        {
            _reservaServicos = reservaServicos;
        }

        [HttpGet]
        public ActionResult<List<Model.Reserva>> Get() =>
            _reservaServicos.Get();

        [HttpGet("{id:length(24)}", Name = "GetReserva")]
        public ActionResult<Model.Reserva> Get(string id)
        {
            var reserva = _reservaServicos.Get(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        [HttpPost]
        public ActionResult<Model.Reserva> Create(Model.Reserva reserva)
        {
            _reservaServicos.Create(reserva);

            return CreatedAtRoute("GetReserva", new { id = reserva.Id.ToString() }, reserva);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Model.Reserva upReserva)
        {
            var reserva = _reservaServicos.Get(id);

            if (reserva == null)
            {
                return NotFound();
            }

            _reservaServicos.Update(id, upReserva);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var reserva = _reservaServicos.Get(id);

            if (reserva == null)
            {
                return NotFound();
            }

            _reservaServicos.Remove(reserva.Id);

            return NoContent();
        }
    }
}
