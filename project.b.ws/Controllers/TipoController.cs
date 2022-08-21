using Microsoft.AspNetCore.Mvc;
using project.b.entity.Entity;
using project.b.service.Service;
using project.b.support.SupportDto;

namespace project.b.ws.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoController : ControllerBase
    {
        #region "Variable"
        private readonly ITipoService _tipoService;
        public TipoController(ITipoService tipoService)
        {
            this._tipoService = tipoService;
        }
        #endregion

        #region "No Transaccionales"
        [HttpGet]
        [Route("ListarTipos")]
        public IActionResult ListarTipos()
        {
            var response = new Response<List<TipoEntity>>();
            response = _tipoService.ListarTipos();

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
