using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReflectionController(IReflectionService reflectionService) : ControllerBase
    {
        [HttpGet("importers")]
        public IActionResult GetImporters()
        {
            try
            {
                var assemblyNames = reflectionService.GetAssembliesWithImporter();
                return Ok(assemblyNames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An internal server error occurred.");
            }
        }
    }
}
