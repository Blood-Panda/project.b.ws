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
    public class PaisService : IPaisService
    {
        #region "Variable"
        private readonly IPaisRepository _paisRepository;
        public PaisService(IPaisRepository paisRepository)
        {
            this._paisRepository = paisRepository;
        }
        #endregion
        public Response<List<PaisEntity>> ListarPaises()
        {
            var response = new Response<List<PaisEntity>>();
            response.IsSuccess = true;
            try
            {
                var lst = _paisRepository.ListarPaises();

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
