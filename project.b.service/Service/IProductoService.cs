using project.b.entity.Entity;
using project.b.support.SupportDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.service.Service
{
    public interface IProductoService
    {
        Response<List<ProductoEntity>> ListarProductos();
        Response<string> EliminarProducto(int idProducto);
        Response<string> EditarProducto(ProductoEntity producto);
        Response<string> RegistrarProducto(ProductoEntity producto);
    }
}
