using project.b.entity.Entity;
using project.b.repository.Repository;
using project.b.support.SupportDto;
using project.b.support.SupportUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.service.Service.Impl
{
    public class TipoService : ITipoService
    {
        #region "Variable"
        private readonly ITipoRepository _tipoRepository;
        public TipoService(ITipoRepository tipoRepository)
        {
            this._tipoRepository = tipoRepository;
        }
        #endregion
        public Response<List<TipoEntity>> ListarTipos()
        {
            var response = new Response<List<TipoEntity>>();
            response.IsSuccess = true;
            try
            {
                var lst = _tipoRepository.ListarTipos();

                if (lst.Count > 0)
                    response.Dato = lst;
                else response.Mensaje = Message.sinRegistros;
            }
            catch (Exception ex)
            {
                response.Mensaje = Message.ErrorSistema;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
