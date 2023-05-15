using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FacturasApi.Context;
using FacturasApi.Models;
using AutoMapper;
using FacturasApi.DTOs;

namespace FacturasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterprisesController : ControllerBase
    {
        private readonly FacturasApiDBContext _context;
        private readonly IMapper _mapper;

        public EnterprisesController(FacturasApiDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Enterprises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enterprise>>> Getenterprises()
        {
          if (_context.enterprises == null)
          {
              return NotFound();
          }
            return await _context.enterprises.ToListAsync();
        }

        // GET: api/Enterprises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enterprise>> GetEnterprise(int id)
        {
          if (_context.enterprises == null)
          {
              return NotFound();
          }
            var enterprise = await _context.enterprises
                 .Include(p => p.Invoices).FirstOrDefaultAsync(p => p.Id == id);

            if (enterprise == null)
            {
                return NotFound();
            }

            return enterprise;
        }

        // PUT: api/Enterprises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnterprise(int id, Enterprise enterprise)
        {
            if (id != enterprise.Id)
            {
                return BadRequest();
            }

            _context.Entry(enterprise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnterpriseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Enterprises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{UsuarioId}")]
        public async Task<ActionResult> PostEnterprise(EnterpriseCreationDTO enterpriseCreationDTO, int UsuarioId)
        {
          if (_context.enterprises == null)
          {
              return Problem("Entity set 'FacturasApiDBContext.enterprises'  is null.");
          }
            var enterprise = _mapper.Map<Enterprise>(enterpriseCreationDTO);
            enterprise.UsuarioId = UsuarioId;
            _context.enterprises.Add(enterprise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnterprise", new { id = enterprise.Id }, enterprise);
        }

        // DELETE: api/Enterprises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnterprise(int id)
        {
            if (_context.enterprises == null)
            {
                return NotFound();
            }
            var enterprise = await _context.enterprises.FindAsync(id);
            if (enterprise == null)
            {
                return NotFound();
            }

            _context.enterprises.Remove(enterprise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnterpriseExists(int id)
        {
            return (_context.enterprises?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
