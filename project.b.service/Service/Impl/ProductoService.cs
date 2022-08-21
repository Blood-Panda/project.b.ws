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
    public class ProductoService : IProductoService
    {
        #region "Variable"
        private readonly IProductoRepository _productoRepository;
        public ProductoService(IProductoRepository productoRepository)
        {
            this._productoRepository = productoRepository;
        }
        #endregion
        public Response<List<ProductoEntity>> ListarProductos()
        {
            var response = new Response<List<ProductoEntity>>();
            response.IsSuccess = true;
            try
            {
                var lst = _productoRepository.ListarProductos();

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

        public Response<string> EliminarProducto(int idProducto)
        {
            var response = new Response<string>();
            try
            {
                var nroConsulta = _productoRepository.EliminarProducto(idProducto);
                if (!string.IsNullOrEmpty(nroConsulta))
                {
                    response.Dato = nroConsulta;
                    response.IsSuccess = true;
                    response.Mensaje = Message.correcto;
                }
                else
                {
                    response.Mensaje = Message.error;
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = Message.ErrorSistema;
                response.IsSuccess = false;
            }
            return response;
        }
        public Response<string> EditarProducto(ProductoEntity producto)
        {
            var response = new Response<string>();
            try
            {
                var nroConsulta = _productoRepository.EditarProducto(producto);
                if (!string.IsNullOrEmpty(nroConsulta))
                {
                    response.Dato = nroConsulta;
                    response.IsSuccess = true;
                    response.Mensaje = Message.correcto;
                }
                else
                {
                    response.Mensaje = Message.error;
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = Message.ErrorSistema;
                response.IsSuccess = false;
            }
            return response;
        }
        public Response<string> RegistrarProducto(ProductoEntity producto)
        {
            var response = new Response<string>();
            try
            {
                var nroConsulta = _productoRepository.RegistrarProducto(producto);
                if (!string.IsNullOrEmpty(nroConsulta))
                {
                    response.Dato = nroConsulta;
                    response.IsSuccess = true;
                    response.Mensaje = Message.correcto;
                }
                else
                {
                    response.Mensaje = Message.error;
                }
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
