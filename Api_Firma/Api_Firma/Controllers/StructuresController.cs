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
    public class StructuresController : ControllerBase
    {
        private readonly IStructureRepository structureRepository;

        public StructuresController(IStructureRepository structureRepository)
        {
            this.structureRepository = structureRepository;
        }

        [HttpGet]
        public async Task<ActionResult> getStructures()
        {
            try
            {
                return Ok(await structureRepository.GetStructures());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<StructureBasic>> GetStructure(int id)
        {
            try
            {
                var result = await structureRepository.GetStructure(id);
                if (result == null)
                {
                    return NotFound("Structure with this ID doesnt exist");
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StructureBasic>> CreateStructure(StructureBasic structure)
        {
            try
            {
                if (structure == null)
                {
                    return BadRequest();
                }
                var newStructure = await structureRepository.AddStructure(structure);

                return CreatedAtAction(nameof(GetStructure),
                    new { id = newStructure.StructureCode}, StructureToBasic(newStructure));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new structure");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<StructureBasic>> UpdateStructure(int id, StructureBasic structure)
        {
            try
            {
                if (id != structure.StructureCode)
                {
                    return BadRequest("Structure ID mismatch");
                }
                var updatedStructure = await structureRepository.GetStructure(id);

                if (updatedStructure == null)
                {
                    return NotFound("Structure with this ID doesnt exist");
                }

                return await structureRepository.UpdateStructure(structure);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating structure");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStructure(int id)
        {
            try
            {
                var deletedStructure = await structureRepository.GetStructure(id);

                if (deletedStructure == null)
                {
                    return NotFound("Structure with this ID doesnt exist");
                }

                await structureRepository.DeleteStructure(id);
                return Ok($"Structure with ID {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting structure");
            }
        }

        private static StructureBasic StructureToBasic(Structure structure) =>
            new StructureBasic
            {
                StructureCode = structure.StructureCode,
                Name = structure.Name,
                Type = structure.Type,
                BossId = structure.BossId,
                UpperStructureId = structure.UpperStructureId
            };
    }
}
