using api1.Data;
using api1.modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api1.Controllers
{   [ApiController]
    [Route("[controller]")]// CONTROLE 
    public class filmecontrole : ControllerBase
    {
        private filmecontext _context;

        public  filmecontrole(filmecontext context)// contrutor 
        {
            _context = context;
        }
       

        [HttpPost]// PARA EVNIAR DADOS 
        public IActionResult adicionarfilme([FromBody] Filme filme)// FROMBODY PARA INFORMA QUE VAI SER ENVIADO DO BODY 
        {
            _context.filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(recuperarfilmeid), new { id = filme.Id }, filme);// mostra no cabeçalho em qual local(url) foi armazenado 
            
        }
        [HttpGet]// PEGAR DADOS 
        public IEnumerable<Filme> recuperarfilme()// IEnumerable APARENTEMENTE ELE GERA UM CONTADOR PARA UM OBJ OU CLASSE
        {
            return _context.filmes;
        }
        [HttpGet("{id}")]
        public IActionResult recuperarfilmeid(int id)// O TIPO É PARA DÁ RETORNO AO OK E NOT FOUND 
        {
         Filme filme = _context.filmes.FirstOrDefault(filme => filme.Id == id); //o primeiro a achar na lista de filmes=> compara o campo de filmes, com uma variavel;
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizarfilme(int id ,[FromBody]Filme filmenovo)
        {
            Filme filme = _context.filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            filme.Titulo = filmenovo.Titulo;
            filme.Diretor = filmenovo.Diretor;
            filme.Genero = filmenovo.Genero;
            filme.duracao = filmenovo.duracao;
            _context.SaveChanges();
            return NoContent();

        }
    }
}
