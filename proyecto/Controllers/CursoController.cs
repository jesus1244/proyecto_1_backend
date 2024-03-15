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
    public class CursoController : Controller
    {
        private CursoOperations _cursoOperations;
        public CursoController(
            CursoOperations cursoOperations
            )
        {
            _cursoOperations = cursoOperations;
        }

        [HttpGet("getCourse")]
        public async Task<IActionResult> getAnchor()
        {
            try
            {
                var result = await _cursoOperations.getAll();

                var response = new ResponseStandar<List<Curso>>
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
        [HttpGet("getCourseBId")]
        public async Task<IActionResult> getAnchorBId(int id)
        {
            try
            {
                var result = await _cursoOperations.getById(id);

                var response = new ResponseStandar<Curso>
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

        [HttpPost("createCourse")]
        public async Task<IActionResult> create(CursoDto dto)
        {
            try
            {
                var result = await _cursoOperations.create(dto);

                var response = new ResponseStandar<Curso>
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
