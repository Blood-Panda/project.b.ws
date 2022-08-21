using Oracle.ManagedDataAccess.Client;
using project.b.entity.Entity;
using project.b.repository.Entity;
using project.b.support.SupportUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.repository.Repository.Impl
{
    public class TipoRepository: ITipoRepository
    {
        #region "Variable de Conexión"
        private readonly IConfiguractionOracleConnection _ConfiguractionOracle;
        public TipoRepository(IConfiguractionOracleConnection ConfiguractionOracle)
        {
            this._ConfiguractionOracle = ConfiguractionOracle;
        }
        #endregion
        public List<TipoEntity> ListarTipos()
        {
            List<TipoEntity> list = new List<TipoEntity>();

            try
            {
                using (OracleConnection conexion = new OracleConnection(_ConfiguractionOracle.strConexion()))
                {
                    conexion.Open();

                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = conexion;
                        cmd.CommandText = Constant.StoreProcedure.SP_LISTAR_TIPOS;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.SetParameter("oListado", "", OracleDbType.RefCursor);

                        list = new List<TipoEntity>();
                        using (OracleDataReader oDrd = cmd.ExecuteReader())
                        {
                            int posId = oDrd.GetOrdinal("ID");
                            int posDescripcion = oDrd.GetOrdinal("DESCRIPCION");

                            while (oDrd.Read())
                            {
                                TipoEntity oEntidad = new TipoEntity();

                                oEntidad.id = oDrd.GetInt32DBNull(posId);
                                oEntidad.descripcion = oDrd.GetStringDBNull(posDescripcion);

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
    }
}
