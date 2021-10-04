using AutoMapper;
using CatalogoDeJogos.Api.Models;
using CatalogoDeJogos.Api.Entities;
using CatalogoDeJogos.Api.Interfaces.Services;
using CatalogoDeJogos.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CatalogoDeJogos.Api.Exceptions;

namespace CatalogoDeJogos.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/jogos")]
    public class JogosController : Controller
    {
        private IJogoService jogoService;

        public JogosController(IJogoService jogoService)
        {
            this.jogoService = jogoService;
        }

        [HttpGet]
        public ActionResult<List<JogoViewModel>> Get([FromQuery, Range(1, int.MaxValue)] int page = 1, [FromQuery, Range(1, 50)] int quantity = 5)
        {
            var result = jogoService.Get(page, quantity);

            if (result.Count < 1)
                return NoContent();

            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public ActionResult<JogoViewModel> Find([FromRoute] Guid id)
        {
            var result = jogoService.Find(id);
            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<JogoViewModel> Add([FromBody] JogoInputModel jogo)
        {
            try
            {
                var result = jogoService.Add(jogo);

                return Ok(result);
            }
            catch(JogoJaExisteException)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora.");
            }
        }

        [HttpPut("{id:guid}")]
        public ActionResult<JogoViewModel> Update([FromRoute]Guid id, [FromBody] JogoInputModel jogo)
        {
            try
            {
                var result = jogoService.Update(id, jogo);

                return Ok(result);
            }
            catch (JogoNaoExisteException)
            {
                return UnprocessableEntity("Este jogo não existe.");
            }
        }

        [HttpPatch("{id:guid}/preco/{preco:double}")]
        public ActionResult<JogoViewModel> UpdatePrice([FromRoute] Guid id, [FromRoute] double preco)
        {
            try
            {
                var result = jogoService.UpdatePrice(id, preco);

                return Ok(result);
            }
            catch (JogoNaoExisteException)
            {
                return UnprocessableEntity("Este jogo não existe.");
            }
        }

        [HttpDelete("{id:guid}")]
        public ActionResult<JogoViewModel> Delete([FromRoute] Guid id)
        {
            try
            {
                jogoService.Delete(id);

                return Ok();
            }
            catch (JogoNaoExisteException)
            {
                return UnprocessableEntity("Este jogo não existe.");
            }
        }
    }
}
