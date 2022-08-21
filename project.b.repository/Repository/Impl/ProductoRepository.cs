using Oracle.ManagedDataAccess.Client;
using project.b.entity.Entity;
using project.b.repository.Entity;
using project.b.support.SupportUtil;
using System;
using System.Collections.Generic;
using System.Data;

namespace project.b.repository.Repository.Impl
{
    public class ProductoRepository : IProductoRepository
    {
        #region "Variable de Conexión"
        private readonly IConfiguractionOracleConnection _ConfiguractionOracle;
        public ProductoRepository(IConfiguractionOracleConnection ConfiguractionOracle)
        {
            this._ConfiguractionOracle = ConfiguractionOracle;
        }
        #endregion

        public List<ProductoEntity> ListarProductos()
        {
            List<ProductoEntity> list = new List<ProductoEntity>();

            try
            {
                using (OracleConnection conexion = new OracleConnection(_ConfiguractionOracle.strConexion()))
                {
                    conexion.Open();

                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = conexion;
                        cmd.CommandText = Constant.StoreProcedure.SP_LISTAR_PRODUCTOS;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.SetParameter("oListado", "", OracleDbType.RefCursor);

                        list = new List<ProductoEntity>();
                        using (OracleDataReader oDrd = cmd.ExecuteReader())
                        {
                            int posId = oDrd.GetOrdinal("ID");
                            int posNombre = oDrd.GetOrdinal("NOMBRE");
                            int posIdTipo = oDrd.GetOrdinal("IDTIPO");
                            int posTipo = oDrd.GetOrdinal("TIPO");
                            int posIdPais = oDrd.GetOrdinal("IDPAIS");
                            int posPais = oDrd.GetOrdinal("PAIS");
                            int posPrecio = oDrd.GetOrdinal("PRECIO");

                            while (oDrd.Read())
                            {
                                ProductoEntity oEntidad = new ProductoEntity();

                                oEntidad.id = oDrd.GetInt32DBNull(posId);
                                oEntidad.nombre = oDrd.GetStringDBNull(posNombre);
                                oEntidad.tipo.id = oDrd.GetInt32DBNull(posIdTipo);
                                oEntidad.tipo.descripcion = oDrd.GetStringDBNull(posTipo);
                                oEntidad.pais.id = oDrd.GetInt32DBNull(posIdPais);
                                oEntidad.pais.descripcion = oDrd.GetStringDBNull(posPais);
                                oEntidad.precio = oDrd.GetDoubleDBNull(posPrecio);

                                list.Add(oEntidad);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }
        public string EliminarProducto(int idProducto)
        {
            {
                string sResult = string.Empty;
                int res = 0;
                try
                {
                    using (OracleConnection conexion = new OracleConnection(_ConfiguractionOracle.strConexion()))
                    {
                        conexion.Open();
                        using (OracleCommand cmd = new OracleCommand())
                        {
                            cmd.Connection = conexion;
                            cmd.CommandText = Constant.StoreProcedure.SP_ELIMINAR_PRODUCTO;
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.SetParameter("nIdProducto", idProducto);
                            cmd.SetParameter("pRetorno", "", OracleDbType.Int32, 0, ParameterDirection.Output);
                            cmd.SetParameter("pError", "", OracleDbType.Varchar2, 500, ParameterDirection.Output);

                            res = cmd.ExecuteNonQuery();
                            sResult = Convert.ToString(cmd.Parameters["pRetorno"].Value);
                            String pError = Convert.ToString(cmd.Parameters["pError"].Value);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return sResult;
            }
        }
        public string EditarProducto(ProductoEntity producto)
        {
            {
                string sResult = string.Empty;
                int res = 0;
                try
                {
                    using (OracleConnection conexion = new OracleConnection(_ConfiguractionOracle.strConexion()))
                    {
                        conexion.Open();
                        using (OracleCommand cmd = new OracleCommand())
                        {
                            cmd.Connection = conexion;
                            cmd.CommandText = Constant.StoreProcedure.SP_EDITAR_PRODUCTO;
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.SetParameter("nIdProducto", producto.id);
                            cmd.SetParameter("sNombre", producto.nombre);
                            cmd.SetParameter("nTipo", producto.tipo.id);
                            cmd.SetParameter("nPais", producto.pais.id);
                            cmd.SetParameter("nPrecio", producto.precio);
                            cmd.SetParameter("pRetorno", "", OracleDbType.Int32, 0, ParameterDirection.Output);
                            cmd.SetParameter("pError", "", OracleDbType.Varchar2, 500, ParameterDirection.Output);

                            res = cmd.ExecuteNonQuery();
                            sResult = Convert.ToString(cmd.Parameters["pRetorno"].Value);
                            String pError = Convert.ToString(cmd.Parameters["pError"].Value);                            
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return sResult;
            }

        }
        public string RegistrarProducto(ProductoEntity producto)
        {
            {
                string sResult = string.Empty;
                int res = 0;
                try
                {
                    using (OracleConnection conexion = new OracleConnection(_ConfiguractionOracle.strConexion()))
                    {
                        conexion.Open();
                        using (OracleCommand cmd = new OracleCommand())
                        {
                            cmd.Connection = conexion;
                            cmd.CommandText = Constant.StoreProcedure.SP_INSERTAR_PRODUCTO;
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.SetParameter("sNombre", producto.nombre);
                            cmd.SetParameter("nTipo", producto.tipo.id);
                            cmd.SetParameter("nPais", producto.pais.id);
                            cmd.SetParameter("nPrecio", producto.precio);
                            cmd.SetParameter("pRetorno", "", OracleDbType.Int32, 0, ParameterDirection.Output);
                            cmd.SetParameter("pError", "", OracleDbType.Varchar2, 500, ParameterDirection.Output);

                            res = cmd.ExecuteNonQuery();
                            sResult = Convert.ToString(cmd.Parameters["pRetorno"].Value);
                            String pError = Convert.ToString(cmd.Parameters["pError"].Value);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return sResult;
            }

        }
    }
}
