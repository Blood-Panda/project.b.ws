using project.b.entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.repository.Repository
{
    public interface IProductoRepository
    {
        List<ProductoEntity> ListarProductos();
        string EliminarProducto(int idProducto);
        string EditarProducto(ProductoEntity producto);
        string RegistrarProducto(ProductoEntity producto);
    }
}
