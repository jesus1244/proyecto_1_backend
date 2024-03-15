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
    public class ProgramasController : Controller
    {
        private ProgramasOperations _programasOperations;
        public ProgramasController(
            ProgramasOperations programasOperations
            )
        {
            _programasOperations = programasOperations;
        }

        [HttpGet("getProgram")]
        public async Task<IActionResult> getAnchor()
        {
            try
            {
                var result = await _programasOperations.getAll();

                var response = new ResponseStandar<List<Programa>>
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
        [HttpGet("getProgramBId")]
        public async Task<IActionResult> getAnchorBId(int id)
        {
            try
            {
                var result = await _programasOperations.getById(id);

                var response = new ResponseStandar<Programa>
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

        [HttpPost("createProgram")]
        public async Task<IActionResult> create(ProgramaDto programa)
        {
            try
            {
                var result = await _programasOperations.create(programa);

                var response = new ResponseStandar<Programa>
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
