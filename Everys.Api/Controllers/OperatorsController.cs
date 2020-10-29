using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Everys.Infrastructure.Data;
using Everys.Infrastructure.Models;

namespace Everys.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private readonly OperatorContext _context;

        public OperatorsController(OperatorContext context)
        {
            _context = context;
        }

        // GET: api/Operators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operator>>> GetOperator()
        {
            return await _context.Operator.ToListAsync();
        }

        // GET: api/Operators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operator>> GetOperator(int id)
        {
            var @operator = await _context.Operator.FindAsync(id);

            if (@operator == null)
            {
                return NotFound();
            }

            return @operator;
        }

        // PUT: api/Operators/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperator(int id, Operator @operator)
        {
            if (id != @operator.Id)
            {
                return BadRequest();
            }

            _context.Entry(@operator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperatorExists(id))
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

        // POST: api/Operators
        [HttpPost]
        public async Task<ActionResult<Operator>> PostOperator(Operator @operator)
        {
            _context.Operator.Add(@operator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperator", new { id = @operator.Id }, @operator);
        }

        // DELETE: api/Operators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Operator>> DeleteOperator(int id)
        {
            var @operator = await _context.Operator.FindAsync(id);
            if (@operator == null)
            {
                return NotFound();
            }

            _context.Operator.Remove(@operator);
            await _context.SaveChangesAsync();

            return @operator;
        }

        private bool OperatorExists(int id)
        {
            return _context.Operator.Any(e => e.Id == id);
        }
    }
}
