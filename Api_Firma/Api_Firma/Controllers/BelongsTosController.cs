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

    }
}
