using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Dto.Intput;
using proyecto.Dto.Out;
using proyecto.Services.DbcontextConnect;
using proyecto.Services.operations;

namespace proyecto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClaseController : Controller
    {
        private ClaseOperations _claseOperations;
        public ClaseController(
            ClaseOperations cursoOperations
            )
        {
            _claseOperations = cursoOperations;
        }

        [HttpGet("getClass")]
        public async Task<IActionResult> getAnchor()
        {
            try
            {
                var result = await _claseOperations.getAll();

                var response = new ResponseStandar<List<Clase>>
                {
                    Success = true,
                    Message = "Success",
                    Data = result
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("getClassBId")]
        public async Task<IActionResult> getAnchorBId(int id)
        {
            try
            {
                var result = await _claseOperations.getById(id);

                var response = new ResponseStandar<Clase>
                {
                    Success = true,
                    Message = "Success",
                    Data = result
                };

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost("createClass")]
        public async Task<IActionResult> create(ClaseDto dto)
        {
            try
            {
                var result = await _claseOperations.create(dto);

                var response = new ResponseStandar<Clase>
                {
                    Success = true,
                    Message = "Success",
                    Data = result
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
