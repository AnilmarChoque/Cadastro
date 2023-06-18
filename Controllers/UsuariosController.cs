using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cadastro.Data;
using Cadastro.Models;
using Cadastro.Models.Enuns;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Usuario p = await _context.Usuarios
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Usuario> lista = await _context.Usuarios.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Usuario novoUsuario)
        {
            try
            {
                await _context.Usuarios.AddAsync(novoUsuario);
                await _context.SaveChangesAsync();

                return Ok(novoUsuario.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Usuario novoUsuario)
        {
            try
            {
                _context.Usuarios.Update(novoUsuario);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Usuario pRemover = await _context.Usuarios
                    .FirstOrDefaultAsync(p => p.Id == id);
                _context.Usuarios.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}