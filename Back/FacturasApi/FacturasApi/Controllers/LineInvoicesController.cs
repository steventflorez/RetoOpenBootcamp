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
    public class LineInvoicesController : ControllerBase
    {
        private readonly FacturasApiDBContext _context;
        private readonly IMapper _mapper;

        public LineInvoicesController(FacturasApiDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/LineInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineInvoice>>> GetLineInvoices()
        {
          if (_context.LineInvoices == null)
          {
              return NotFound();
          }
            return await _context.LineInvoices.ToListAsync();
        }

        // GET: api/LineInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LineInvoice>> GetLineInvoice(int id)
        {
          if (_context.LineInvoices == null)
          {
              return NotFound();
          }
            var lineInvoice = await _context.LineInvoices.FindAsync(id);

            if (lineInvoice == null)
            {
                return NotFound();
            }

            return lineInvoice;
        }

        // PUT: api/LineInvoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineInvoice(int id, LineInvoice lineInvoice)
        {
            if (id != lineInvoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(lineInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineInvoiceExists(id))
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

        // POST: api/LineInvoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost ("{invoiceId}")]
        public async Task<ActionResult> PostLineInvoice(LineInvoiceCreationDTO lineInvoiceCreationDTO, int invoiceId)
        {
          if (_context.LineInvoices == null)
          {
              return Problem("Entity set 'FacturasApiDBContext.LineInvoices'  is null.");
          }
          var lineInvoice = _mapper.Map<LineInvoice>(lineInvoiceCreationDTO);
            lineInvoice.InvoiceId = invoiceId;
            _context.LineInvoices.Add(lineInvoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLineInvoice", new { id = lineInvoice.Id }, lineInvoice);
        }

        // DELETE: api/LineInvoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLineInvoice(int id)
        {
            if (_context.LineInvoices == null)
            {
                return NotFound();
            }
            var lineInvoice = await _context.LineInvoices.FindAsync(id);
            if (lineInvoice == null)
            {
                return NotFound();
            }

            _context.LineInvoices.Remove(lineInvoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LineInvoiceExists(int id)
        {
            return (_context.LineInvoices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
