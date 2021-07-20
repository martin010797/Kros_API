using Api_Firma.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BelongsTosController : ControllerBase
    {
        private readonly IBelongsToRepository belongsToRepository;
        public BelongsTosController(IBelongsToRepository belongsToRepository)
        {
            this.belongsToRepository = belongsToRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBelongsTos()
        {
            try
            {
                return Ok(await belongsToRepository.GetBelongsTos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BelongsToBasic>> GetBelongsTo(int id)
        {
            try
            {
                var result = await belongsToRepository.GetBelongsTo(id);
                if (result == null)
                {
                    return NotFound("BelongsTo with this ID doesnt exist");
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<BelongsToBasic>> CreateBelongsTo(BelongsToBasic belongsTo)
        {
            try
            {
                if (belongsTo == null)
                {
                    return BadRequest();
                }
                var newBelongsTo = await belongsToRepository.AddBelonging(belongsTo);

                return CreatedAtAction(nameof(GetBelongsTo),
                    new { id = newBelongsTo.Id }, BelongsToToBasic(newBelongsTo));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new belongTo");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<BelongsToBasic>> UpdateBelongsTo(int id, BelongsToBasic belongsTo)
        {
            try
            {
                if (id != belongsTo.Id)
                {
                    return BadRequest("BelongsTo ID mismatch");
                }
                var updatedBelongsTo = await belongsToRepository.GetBelongsTo(id);

                if (updatedBelongsTo == null)
                {
                    return NotFound("BelongsTo with this ID doesnt exist");
                }

                return await belongsToRepository.UpdateBelonging(belongsTo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating belongsTo");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBelongsTo(int id)
        {
            try
            {
                var deletedBelongsTo = await belongsToRepository.GetBelongsTo(id);

                if (deletedBelongsTo == null)
                {
                    return NotFound("BelongsTo with this ID doesnt exist");
                }

                await belongsToRepository.DeleteBelonging(id);
                return Ok($"BelongsTo with ID {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting belongsTo");
            }
        }

        private static BelongsToBasic BelongsToToBasic(BelongsTo belongsTo) =>
           new BelongsToBasic
           {
               Id = belongsTo.Id,
               EmployeeId = belongsTo.EmployeeId,
               StructureId = belongsTo.StructureId
           };

    }
}
