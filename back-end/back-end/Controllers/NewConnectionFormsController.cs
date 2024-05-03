using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.DatabaseContext;
using back_end.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using back_end.ServiceContracts.Repository;
using back_end.DTO;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NewConnectionFormsController : ControllerBase
    {
        private readonly INewConnectionFormRepository _repository;

        public NewConnectionFormsController(INewConnectionFormRepository repository)
        {
            _repository = repository;
        }

        // GET: api/NewConnectionForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewConnectionForm>>> GetNewConnectionForms()
        {
            var newConnectionForms = await _repository.GetAllNewConnectionFormsAsync();
            return Ok(newConnectionForms);
        }

        // GET: api/NewConnectionForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewConnectionFormDTO>> GetNewConnectionForm(int id)
        {
            var newConnectionForm = await _repository.GetNewConnectionFormByIdAsync(id);
            if (newConnectionForm == null)
            {
                return NotFound();
            }
            return Ok(newConnectionForm);
        }

        //// PUT: api/NewConnectionForms/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutNewConnectionForm(int id, NewConnectionForm newConnectionForm)
        //{
        //    if (id != newConnectionForm.ConnectionNo)
        //    {
        //        return BadRequest();
        //    }

        //    // Update the entity
        //    var updated = await _repository.UpdateNewConnectionFormAsync(id, newConnectionForm);
        //    if (!updated)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        // POST: api/NewConnectionForms 
        [HttpPost]
        public async Task<ActionResult<NewConnectionForm>> PostNewConnectionForm([FromForm] NewConnectionFormDTO newConnectionForm)
        {
            var newConnectionFormData = await _repository.AddNewConnectionFormAsync(newConnectionForm);
            return CreatedAtAction(nameof(GetNewConnectionForm), new { id = newConnectionFormData.ConnectionNo }, newConnectionFormData);
        }

        [HttpGet("CheckConnectionStatus")]
        public async Task<IActionResult> CheckConnectionStatus()
       {
            var hasapplied = await _repository.HasAppliedForConnection();
            if ( hasapplied )
            {
                return Ok(false);
            }
            return Ok(true);
        }

        // DELETE: api/NewConnectionForms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewConnectionForm(int id)
        {
            var deleted = await _repository.DeleteNewConnectionFormAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
