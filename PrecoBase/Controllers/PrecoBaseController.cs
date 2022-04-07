﻿using System.Collections.Generic;
using PrecoBase.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace PrecoBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecoBaseController : ControllerBase
    {
        private readonly PrecoBaseServicos _precobaseServicos;

        public PrecoBaseController(PrecoBaseServicos precobaseservice)
        {
            _precobaseServicos = precobaseservice;
        }

        [HttpGet]
        public ActionResult<List<Model.PrecoBase>> Get() =>
            _precobaseServicos.Get();

        [HttpGet("{id:length(24)}", Name = "GetPrecoBase")]
        public ActionResult<Model.PrecoBase> Get(string id)
        {
            var precobase = _precobaseServicos.Get(id);

            if (precobase == null)
                return NotFound();

            return precobase;
        }

        [HttpPost]
        public ActionResult<Model.PrecoBase> Create(Model.PrecoBase precobase)
        {
            
            _precobaseServicos.Create(precobase);
            return CreatedAtRoute("GetPrecoBase", new { id = precobase.Id.ToString() }, precobase);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Model.PrecoBase putPrecoBase)
        {
            var precobase = _precobaseServicos.Get(id);

            if (precobase == null)
                return NotFound();

            _precobaseServicos.Update(id, putPrecoBase);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var precobase = _precobaseServicos.Get(id);

            if (precobase == null)
                return NotFound();

            _precobaseServicos.Remove(precobase.Id);

            return NoContent();
        }
    }
}
