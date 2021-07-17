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
    }
}
