using Microsoft.AspNetCore.Mvc;
using project.b.entity.Entity;
using project.b.service.Service;
using project.b.support.SupportDto;

namespace project.b.ws.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController : ControllerBase
    {
        #region "Variable"
        private readonly IPaisService _paisService;
        public PaisController(IPaisService paisService)
        {
            this._paisService = paisService;
        }
        #endregion

        #region "No Transaccionales"
        [HttpGet]
        [Route("ListarPaises")]
        public IActionResult ListarPaises()
        {
            var response = new Response<List<PaisEntity>>();
            response = _paisService.ListarPaises();

            if (!response.IsSuccess)
            {
                if (response.ErrorDetails.StatusCode == 404)
                    return NotFound(response);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }
        #endregion
    }
}
