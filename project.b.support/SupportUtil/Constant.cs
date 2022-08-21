using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.support.SupportUtil
{
    public class Constant
    {
        public const string Conexion = "Database:PROJECT";

        public static class Aplicacion
        {
            public const string COMUN = "COMUN";
            public const string SU = "SU";
            public const string APLICACIONTOKEN = "SU";
        }

        public static class StoreProcedure
        {

            #region "Estructura - PROJECT"

            public const string SP_LISTAR_PRODUCTOS = "PKG_PRODUCTO.SP_LISTAR_PRODUCTOS"; 
            public const string SP_INSERTAR_PRODUCTO = "PKG_PRODUCTO.SP_INSERTAR_PRODUCTO"; 
            public const string SP_ELIMINAR_PRODUCTO = "PKG_PRODUCTO.SP_ELIMINAR_PRODUCTO"; 
            public const string SP_EDITAR_PRODUCTO = "PKG_PRODUCTO.SP_EDITAR_PRODUCTO";

            public const string SP_LISTAR_TIPOS = "PKG_PRODUCTO.SP_LISTAR_TIPOS";

            public const string SP_LISTAR_PAISES = "PKG_PRODUCTO.SP_LISTAR_PAISES";

            #endregion

        }
    }
}